import { ChangeDetectorRef, Component, Input } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { take } from 'rxjs';
import { Avatar } from 'src/app/core/models/Avatar';
import { User } from 'src/app/core/models/User';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { BusyService } from 'src/app/core/services/busy.service';
import { UserService } from 'src/app/core/services/user.service';
import { environment } from 'src/environments/environment';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { NgProgress, NgProgressRef } from 'ngx-progressbar';

@Component({
  selector: 'app-avatar-upload',
  templateUrl: './avatar-upload.component.html',
  styleUrls: ['./avatar-upload.component.scss'],
})
export class AvatarUploadComponent {
  @Input() user: User | undefined;
  uploader!: FileUploader;
  hasBaseDropZoneOver = false;
  baseUrl = environment.baseWebApiUrl;
  userData: any;
  @Input() avatarUrl?: string;
  public ImgUrl: any;
  progressRef!: NgProgressRef;

  constructor(
    private authService: AuthenticationService,
    private userService: UserService,
    private busyService: BusyService,
    public domSanitizer: DomSanitizer,
    private changeDetector: ChangeDetectorRef,
    private router: Router,
    private progress: NgProgress
  ) {
    this.authService.currentUser$.pipe(take(1)).subscribe({
      next: (userData) => {
        if (userData) this.userData = userData;
      },
    });
  }

  ngOnInit(): void {
    this.progressRef = this.progress.ref('myProgress');

    this.initializeUploader();
    if (this.avatarUrl) {
      this.ImgUrl = this.domSanitizer.bypassSecurityTrustStyle(
        `url(${this.avatarUrl})`
      );
    }
  }

  upload() {
    this.uploader?.uploadAll();

    this.router.navigateByUrl(`/v/user/${this.userData?.id}`);
  }
  async Cancel() {
    await this.uploader?.cancelAll();
  }
  async Clear() {
    await this.uploader?.clearQueue();
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
      autoUpload: true,
      maxFileSize: 10 * 1024 * 1024,
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    };
    this.uploader.onProgressItem = (fileItem, progress) => {
      this.progressRef.start();
    };

    this.uploader.onCompleteAll = () => {
      this.progressRef?.complete();
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
