import { Component, HostBinding, HostListener, NgZone } from '@angular/core';
import { IndividualConfig, ToastPackage, ToastrService } from 'ngx-toastr';
import {
  animate,
  keyframes,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';
import { SafeHtml } from '@angular/platform-browser';
import { Subscription } from 'rxjs';
@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.scss'],
  animations: [
    trigger('flyInOut', [
      state(
        'inactive',
        style({
          opacity: 0,
        })
      ),
      transition(
        'inactive => active',
        animate(
          '400ms ease-out',
          keyframes([
            style({
              transform: 'translate3d(100%, 0, 0) skewX(-30deg)',
              opacity: 0,
            }),
            style({
              transform: 'skewX(20deg)',
              opacity: 1,
            }),
            style({
              transform: 'skewX(-5deg)',
              opacity: 1,
            }),
            style({
              transform: 'none',
              opacity: 1,
            }),
          ])
        )
      ),
      transition(
        'active => removed',
        animate(
          '400ms ease-out',
          keyframes([
            style({
              opacity: 1,
            }),
            style({
              transform: 'translate3d(100%, 0, 0) skewX(30deg)',
              opacity: 0,
            }),
          ])
        )
      ),
    ]),
  ],
  preserveWhitespaces: false,
})
export class NotificationComponent {
  message?: string | SafeHtml | null;
  title?: string;
  options: IndividualConfig;
  originalTimeout: number;
  /** width of progress bar */
  width = -1;
  /** a combination of toast type and options.toastClass */
  @HostBinding('class') toastClasses = '';
  /** controls animation */
  @HostBinding('@flyInOut')
  state = {
    value: 'inactive',
    params: {
      easeTime: this.toastPackage.config.easeTime,
      easing: 'ease-in'
    }
  };
  private timeout: any;
  private intervalId: any;
  private hideTime!: number;
  private sub: Subscription;
  private sub1: Subscription;
  private sub2: Subscription;

  constructor(
    protected toastrService: ToastrService,
    public toastPackage: ToastPackage,
    protected ngZone?: NgZone
  ) {
    this.message = toastPackage.message;
    this.title = toastPackage.title;
    this.options = toastPackage.config;
    this.originalTimeout = toastPackage.config.timeOut;
    this.toastClasses = `${toastPackage.toastType} ${
      toastPackage.config.toastClass
    }`;
    this.sub = toastPackage.toastRef.afterActivate().subscribe(() => {
      this.activateToast();
    });
    this.sub1 = toastPackage.toastRef.manualClosed().subscribe(() => {
      this.remove();
    });
    this.sub2 = toastPackage.toastRef.timeoutReset().subscribe(() => {
      this.resetTimeout();
    });
  }
  ngOnDestroy() {
    this.sub.unsubscribe();
    this.sub1.unsubscribe();
    this.sub2.unsubscribe();
    clearInterval(this.intervalId);
    clearTimeout(this.timeout);
  }
  /**
   * activates toast and sets timeout
   */
  activateToast() {
    this.state = { ...this.state, value: 'active' };
    if (!this.options.disableTimeOut && this.options.timeOut) {
      this.outsideTimeout(() => this.remove(), this.options.timeOut);
      this.hideTime = new Date().getTime() + this.options.timeOut;
      if (this.options.progressBar) {
        this.outsideInterval(() => this.updateProgress(), 10);
      }
    }
  }
  /**
   * updates progress bar width
   */
  updateProgress() {
    if (this.width === 0 || this.width === 100 || !this.options.timeOut) {
      return;
    }
    const now = new Date().getTime();
    const remaining = this.hideTime - now;
    this.width = (remaining / this.options.timeOut) * 100;
    if (this.options.progressAnimation === 'increasing') {
      this.width = 100 - this.width;
    }
    if (this.width <= 0) {
      this.width = 0;
    }
    if (this.width >= 100) {
      this.width = 100;
    }
  }

  resetTimeout() {
    clearTimeout(this.timeout);
    clearInterval(this.intervalId);
    this.state = { ...this.state, value: 'active' };

    this.outsideTimeout(() => this.remove(), this.originalTimeout);
    this.options.timeOut = this.originalTimeout;
    this.hideTime = new Date().getTime() + (this.options.timeOut || 0);
    this.width = -1;
    if (this.options.progressBar) {
      this.outsideInterval(() => this.updateProgress(), 10);
    }
  }

  /**
   * tells toastrService to remove this toast after animation time
   */
  remove() {
    if (this.state.value === 'removed') {
      return;
    }
    clearTimeout(this.timeout);
    this.state = { ...this.state, value: 'removed' };
    this.outsideTimeout(
      () => this.toastrService.remove(this.toastPackage.toastId),
      +this.toastPackage.config.easeTime
    );
  }
  @HostListener('click')
  tapToast() {
    if (this.state.value === 'removed') {
      return;
    }
    this.toastPackage.triggerTap();
    if (this.options.tapToDismiss) {
      this.remove();
    }
  }
  @HostListener('mouseenter')
  stickAround() {
    if (this.state.value === 'removed') {
      return;
    }
    clearTimeout(this.timeout);
    this.options.timeOut = 0;
    this.hideTime = 0;

    // disable progressBar
    clearInterval(this.intervalId);
    this.width = 0;
  }
  @HostListener('mouseleave')
  delayedHideToast() {
    if (
      this.options.disableTimeOut ||
      this.options.extendedTimeOut === 0 ||
      this.state.value === 'removed'
    ) {
      return;
    }
    this.outsideTimeout(() => this.remove(), this.options.extendedTimeOut);
    this.options.timeOut = this.options.extendedTimeOut;
    this.hideTime = new Date().getTime() + (this.options.timeOut || 0);
    this.width = -1;
    if (this.options.progressBar) {
      this.outsideInterval(() => this.updateProgress(), 10);
    }
  }

  outsideTimeout(func: Function, timeout: number) {
    if (this.ngZone) {
      this.ngZone.runOutsideAngular(
        () =>
          (this.timeout = setTimeout(
            () => this.runInsideAngular(func),
            timeout
          ))
      );
    } else {
      this.timeout = setTimeout(() => func(), timeout);
    }
  }

  outsideInterval(func: Function, timeout: number) {
    if (this.ngZone) {
      this.ngZone.runOutsideAngular(
        () =>
          (this.intervalId = setInterval(
            () => this.runInsideAngular(func),
            timeout
          ))
      );
    } else {
      this.intervalId = setInterval(() => func(), timeout);
    }
  }

  private runInsideAngular(func: Function) {
    if (this.ngZone) {
      this.ngZone.run(() => func());
    } else {
      func();
    }
  }



}
