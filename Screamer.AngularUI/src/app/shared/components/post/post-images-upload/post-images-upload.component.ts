import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { FileUploader } from 'ng2-file-upload';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { take } from 'rxjs';
import { PostImage } from 'src/app/core/models/PostImage';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { BusyService } from 'src/app/core/services/busy.service';
import { PostService } from 'src/app/core/services/post.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-post-images-upload',
  templateUrl: './post-images-upload.component.html',
  styleUrls: ['./post-images-upload.component.scss']
})
export class PostImagesUploadComponent {

  uploader!: FileUploader;
  hasBaseDropZoneOver = false;
  baseUrl = environment.baseWebApiUrl;
  @Input () postData: any;
   postImageUrl?: string;
  public ImgUrl: any;
  domSanitizer: any;
  user!: any;
  customOptions: OwlOptions = {
    loop: false,
    mouseDrag: true,
    touchDrag: true,
    pullDrag: true,
    dots: false,
    navSpeed: 700,
    navText: ['', ''],
    responsive: {
      0: {
        items: 1
      },
      400: {
        items: 2
      },
      740: {
        items: 3
      },
      940: {
        items: 4
      }
    },
    nav: true
  }


  constructor(
    private postService: PostService,
    private busyService : BusyService,
    private router : Router,
    private authService: AuthenticationService

  ) {
    this.authService.currentUser$.pipe(take(1)).subscribe({
      next: (user) => {
        if (user) this.user = user;
      },
    });
  }

  ngOnInit(): void {
    this.initializeUploader();
    if (this.postImageUrl) {
      this.ImgUrl = this.domSanitizer.bypassSecurityTrustStyle(
        `url(${this.postImageUrl})`
      );
    }
  }

  upload() {
    this.busyService.busy();

    this.uploader?.uploadAll();


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

/*   setMainpostImage(postImage: PostImage) {
    this.userService.setMainpostImage(postImage.id).subscribe({
      next: () => {
        if (this.userData && this.user) {
          this.userData.postImageUrl = postImage.url;
          this.authService.setCurrentUser(this.userData);
          this.user.postImageUrl = postImage.url;
          this.user.postImages.forEach((p) => {
            if (p.isMain) p.isMain = false;
            if (p.id === postImage.id) p.isMain = true;
          });
        }
      },
    });
  } */

/*   deletepostImage(postImageId: number) {
    this.userService.deletepostImage(postImageId).subscribe({
      next: (_) => {
        if (this.user) {
          this.user.postImages = this.user.postImages.filter(
            (x) => x.id !== postImageId
          );
        }
      },
    });
  } */

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + `Post/add-post-image/${this.postData?.id}`,
      authToken: 'Bearer ' + this.user?.token,
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
        const postImage = JSON.parse(response);
        this.user?.postImages.push(postImage);
        if (postImage.isMain && this.user && this.user) {
          this.postData.postImageUrl = postImage.url;
          this.postData.postImageUrl = postImage.url;
        }
      }
      this.busyService.idle();
    };
  }
}

