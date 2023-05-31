import { Component, HostListener } from '@angular/core';
import { User } from './core/models/User';
import { AuthenticationService } from './core/services/authentication.service';
import { Router, NavigationEnd } from '@angular/router';
import { PresenceService } from './core/services/presence.service';
import { SearchService } from './core/services/search.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'Screamer.AngularUI';
  shouldShowNavAndFooterComponent: boolean | undefined;
  ShoudShowSearchModal: boolean | undefined;

  constructor(
    private authService: AuthenticationService,
    private router: Router,
    private presenceService: PresenceService,
    public searchService: SearchService
  ) {}

  ngOnInit(): void {
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
  }
}
