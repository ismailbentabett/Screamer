import { Component, Input } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { take } from 'rxjs';
import { Avatar } from 'src/app/core/models/Avatar';
import { User } from 'src/app/core/models/User';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { BusyService } from 'src/app/core/services/busy.service';
import { UserService } from 'src/app/core/services/user.service';
import { environment } from 'src/environments/environment';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-avatar-upload',
  templateUrl: './avatar-upload.component.html',
  styleUrls: ['./avatar-upload.component.scss'],
})
export class AvatarUploadComponent {
  @Input() user: User | undefined;
  uploader: FileUploader | undefined;
  hasBaseDropZoneOver = false;
  baseUrl = environment.baseWebApiUrl;
  userData: any;
  @Input() avatarUrl?: string;
  public ImgUrl : any;

  constructor(
    private authService: AuthenticationService,
    private userService: UserService,
    private busyService: BusyService,
    public domSanitizer: DomSanitizer
  ) {
    this.authService.currentUser$.pipe(take(1)).subscribe({
      next: (userData) => {
        if (userData) this.userData = userData;
      },
    });
  }

  ngOnInit(): void {
    this.initializeUploader();
    console.log(this.avatarUrl);
    if (this.avatarUrl) {
      this.ImgUrl =this.domSanitizer.bypassSecurityTrustStyle(`url(${this.avatarUrl})`);
    }
  }

  upload() {
    this.busyService.busy();

    this.uploader?.uploadAll();

    this.busyService.idle();
  }
  async Cancel() {
    this.busyService.busy();

    await this.uploader?.cancelAll();
    this.busyService.idle();
  }
  async Clear() {
    this.busyService.busy();

    await this.uploader?.clearQueue();
    this.busyService.idle();
  }

  fileOverBase(e: any) {
    this.hasBaseDropZoneOver = e;
  }

  setMainAvatar(Avatar: Avatar) {
    this.userService.setMainAvatar(Avatar.id).subscribe({
      next: () => {
        if (this.userData && this.user) {
          this.userData.AvatarUrl = Avatar.url;
          this.authService.setCurrentUser(this.userData);
          this.user.avatarUrl = Avatar.url;
          this.user.avatars.forEach((p) => {
            if (p.isMain) p.isMain = false;
            if (p.id === Avatar.id) p.isMain = true;
          });
        }
      },
    });
  }

  deleteAvatar(AvatarId: number) {
    this.userService.deleteAvatar(AvatarId).subscribe({
      next: (_) => {
        if (this.user) {
          this.user.avatars = this.user.avatars.filter(
            (x) => x.id !== AvatarId
          );
        }
      },
    });
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + `User/add-avatar/${this.userData?.id}`,
      authToken: 'Bearer ' + this.userData?.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024,
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    };

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        const Avatar = JSON.parse(response);
        this.user?.avatars.push(Avatar);
        if (Avatar.isMain && this.userData && this.user) {
          this.userData.AvatarUrl = Avatar.url;
          this.user.avatarUrl = Avatar.url;
          this.authService.setCurrentUser(this.userData);
        }
      }
    };
  }
}
