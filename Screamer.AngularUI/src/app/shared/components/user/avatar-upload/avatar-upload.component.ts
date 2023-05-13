import { Component, Input } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { take } from 'rxjs';
import { Avatar } from 'src/app/core/models/Avatar';
import { User } from 'src/app/core/models/User';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { UserService } from 'src/app/core/services/user.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-avatar-upload',
  templateUrl: './avatar-upload.component.html',
  styleUrls: ['./avatar-upload.component.scss']
})
export class AvatarUploadComponent {
  @Input() user: User | undefined;
  uploader: FileUploader | undefined;
  hasBaseDropZoneOver = false;
  baseUrl = environment.baseWebApiUrl;
  userData: User | undefined;

  constructor(private authService: AuthenticationService, private userService: UserService) {
    this.authService.currentUser$.pipe(take(1)).subscribe({
      next: userData => {
        if (userData) this.userData = userData
      }
    })
   }

  ngOnInit(): void {
    this.initializeUploader();
  }

  fileOverBase(e: any) {
    this.hasBaseDropZoneOver = e;
  }

  setMainAvatar(Avatar: Avatar) {
    this.userService.setMainAvatar(Avatar.Id).subscribe({
      next: () => {
        if (this.userData && this.user) {
          this.userData.AvatarUrl = Avatar.url;
          this.authService.setCurrentUser(this.userData);
          this.user.AvatarUrl = Avatar.url;
          this.user.Avatars.forEach(p => {
            if (p.isMain) p.isMain = false;
            if (p.Id === Avatar.Id) p.isMain = true;
          })
        }
      }
    })
  }

  deleteAvatar(AvatarId: number) {
    this.userService.deleteAvatar(AvatarId).subscribe({
      next: _ => {
        if (this.user) {
          this.user.Avatars = this.user.Avatars.filter(x => x.Id !== AvatarId);
        }
      }
    })
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + `User/add-avatar/${this.userData?.Id}`,
      authToken: 'Bearer ' + this.userData?.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false
    }

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        const Avatar = JSON.parse(response);
        this.user?.Avatars.push(Avatar);
        if (Avatar.isMain && this.userData && this.user) {
          this.userData.AvatarUrl = Avatar.url;
          this.user.AvatarUrl = Avatar.url;
          this.authService.setCurrentUser(this.userData);
        }
      }
    }
  }

}

