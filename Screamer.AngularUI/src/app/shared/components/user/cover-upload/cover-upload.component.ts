import { ChangeDetectorRef, Component, Input } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { take } from 'rxjs';
import { Cover } from 'src/app/core/models/Cover';
import { User } from 'src/app/core/models/User';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { BusyService } from 'src/app/core/services/busy.service';
import { UserService } from 'src/app/core/services/user.service';
import { environment } from 'src/environments/environment';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { NgProgress, NgProgressRef } from 'ngx-progressbar';
@Component({
  selector: 'app-cover-upload',
  templateUrl: './cover-upload.component.html',
  styleUrls: ['./cover-upload.component.scss']
})
export class CoverUploadComponent {
  @Input() user: User | undefined;
  uploader!: FileUploader;
  hasBaseDropZoneOver = false;
  baseUrl = environment.baseWebApiUrl;
  userData: any;
  @Input() coverUrl?: string;
  public ImgUrl: any;
  progressRef!: NgProgressRef;

  constructor(
    private authService: AuthenticationService,
    private userService: UserService,
    private busyService: BusyService,
    public domSanitizer: DomSanitizer,
    private changeDetector: ChangeDetectorRef,
    private router : Router,
    private route: ActivatedRoute,
    private progress: NgProgress

  ) {
    this.authService.currentUser$.pipe(take(1)).subscribe({
      next: (userData) => {
        if (userData) this.userData = userData;
      },
    });
  }

  canChangeCover(user : any){
    let userId = this.route.snapshot.paramMap.get('id')

    return userId == user.id

  }

  ngOnInit(): void {
    this.progressRef = this.progress.ref('myProgress');

    this.initializeUploader();
    if (this.coverUrl) {
      this.ImgUrl = this.domSanitizer.bypassSecurityTrustStyle(
        `url(${this.coverUrl})`
      );
    }
  }

  upload() {


    this.uploader?.uploadAll();

      this.router.navigateByUrl(
        `/v/user/${this.userData?.id}`
      )
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

  setMainCover(Cover: Cover) {
    this.userService.setMainCover(Cover.id).subscribe({
      next: () => {
        if (this.userData && this.user) {
          this.userData.CoverUrl = Cover.url;
          this.authService.setCurrentUser(this.userData);
          this.user.coverUrl = Cover.url;
          this.user.covers.forEach((p) => {
            if (p.isMain) p.isMain = false;
            if (p.id === Cover.id) p.isMain = true;
          });
        }
      },
    });
  }

  deleteCover(CoverId: number) {
    this.userService.deleteCover(CoverId).subscribe({
      next: (_) => {
        if (this.user) {
          this.user.covers = this.user.covers.filter(
            (x) => x.id !== CoverId
          );
        }
      },
    });
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + `User/add-cover/${this.userData?.id}`,
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
        const Cover = JSON.parse(response);
        this.user?.covers.push(Cover);
        if (Cover.isMain && this.userData && this.user) {
          this.userData.CoverUrl = Cover.url;
          this.user.coverUrl = Cover.url;
          this.authService.setCurrentUser(this.userData);
        }
      }
      ;
    };
  }
}

