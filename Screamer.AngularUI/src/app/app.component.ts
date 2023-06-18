import { Component, HostListener, VERSION, ViewChild } from '@angular/core';
import { User } from './core/models/User';
import { AuthenticationService } from './core/services/authentication.service';
import { Router, NavigationEnd } from '@angular/router';
import { PresenceService } from './core/services/presence.service';
import { SearchService } from './core/services/search.service';
import { StoryService } from './core/services/story.service';
import { NgProgressComponent } from 'ngx-progressbar';
import { NotificationService } from './core/services/notification.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'Screamer.AngularUI';
  shouldShowNavAndFooterComponent: boolean | undefined;
  ShoudShowSearchModal: boolean | undefined;
  showSideContent!: boolean;
  showFloatingButton!: boolean;

  constructor(
    private authService: AuthenticationService,
    private router: Router,
    private presenceService: PresenceService,
    public searchService: SearchService,
    public storyService: StoryService,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.showSideContent =
          this.router.url !== '/' &&
          this.router.url !== '/v/settings/profile' &&
          this.router.url !== '/v/settings/account' &&
          this.router.url !== '/v/settings/auth' &&
          this.router.url !== '/auth/login' &&
          this.router.url !== '/auth/signup' &&
          this.router.url !== '/v/list/users' &&
          this.router.url !== '/v/trending/users' &&
          !this.router.url.includes('/v/chat') &&
          !this.router.url.includes('/v/settings') &&
          !this.router.url.includes('/auth/');
      }
    });
    this.setCurrentUser();
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.shouldShowNavAndFooterComponent = this.router.url !== '/';
      }
    });
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.ShoudShowSearchModal =
          this.router.url !== '/v/search/users' &&
          this.router.url !== '/v/search/posts';

        this.showFloatingButton =
          this.router.url !== '/' &&
          this.router.url !== '/auth/login' &&
          this.router.url !== '/auth/signup';
      }
    });
  }

  @HostListener('window:keydown.control.k', ['$event'])
  handleCtrlK(event: KeyboardEvent) {
    event.preventDefault(); // Prevent default browser behavior (e.g., opening browser's search)
    this.openSearchModal();
  }

  openSearchModal() {
    this.searchService.openPopup();
  }

  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user: User = JSON.parse(userString);
    this.authService.setCurrentUser(user);
    this.presenceService.createHubConnection(user);
    this.notificationService.notificationRecieved$.subscribe({
      next: (message: any) => {
        console.log(message);
      },
    });
  }
}
