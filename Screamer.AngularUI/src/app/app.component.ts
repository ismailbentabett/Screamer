import { Component } from '@angular/core';
import { User } from './core/models/User';
import { AuthenticationService } from './core/services/authentication.service';
import { Router, NavigationEnd } from '@angular/router';
import { PresenceService } from './core/services/presence.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'Screamer.AngularUI';
  shouldShowNavAndFooterComponent: boolean | undefined;

  constructor(
    private authService: AuthenticationService,
    private router: Router,
    private presenceService : PresenceService
  ) {}

  ngOnInit(): void {
    this.setCurrentUser();
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.shouldShowNavAndFooterComponent = this.router.url !== '/';
      }
    });


  }

  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user: User = JSON.parse(userString);
    this.authService.setCurrentUser(user);
    this.presenceService.createHubConnection(user)
  }
}
