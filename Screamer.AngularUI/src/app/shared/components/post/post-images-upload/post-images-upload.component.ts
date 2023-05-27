import { Component, Input, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { first } from 'lodash';
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
  styleUrls: ['./post-images-upload.component.scss'],
})
export class PostImagesUploadComponent {
  uploader!: FileUploader;
  hasBaseDropZoneOver = false;
  baseUrl = environment.baseWebApiUrl;
  @Input() postId: any;
  @Input() postImageUrl: any = false;

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
        items: 1,
      },
      400: {
        items: 2,
      },
      740: {
        items: 3,
      },
      940: {
        items: 4,
      },
    },
    nav: true,
  };

  constructor(
    private postService: PostService,
    private busyService: BusyService,
    private router: Router,
    private authService: AuthenticationService
  ) {
    this.authService.currentUser$.pipe(take(1)).subscribe({
      next: (user) => {
        if (user) this.user = user;
      },
    });
  }

  /*   ngOnChanges(changes: SimpleChanges): void {
    if (changes['postImageUrl']) {
      console.log(this.postImageUrl);
      if (this.postImageUrl) {
        this.initializeUploader();
      }
    }
  } */
  ngOnInit(): void {
    this.initializeUploader();
  }

  upload() {
    this.uploader.setOptions(
      {
        url: this.postImageUrl,
        authToken: 'Bearer ' + this.user?.token,
        isHTML5: true,
        allowedFileType: ['image'],
        removeAfterUpload: true,
        autoUpload: false,
        maxFileSize: 10 * 1024 * 1024,
      }
    )
    this.uploader.onCompleteAll = () => {
      this.busyService.idle();
    }
    console.log(this.uploader);
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

  initializeUploader() {
    console.log('PostImagesUploadComponent.initializeUploader()');
    this.uploader = new FileUploader({
      url: this.baseUrl,

    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    };

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        const postImage = JSON.parse(response);
        console.log(postImage);
      }
    };
  }
}
