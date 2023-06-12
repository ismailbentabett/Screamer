import { Component, ElementRef, ViewChild } from '@angular/core';
import { FileItem, FileUploader } from 'ng2-file-upload';
import { take } from 'rxjs';
import { PostService } from 'src/app/core/services/post.service';
import { StoryService } from 'src/app/core/services/story.service';
import { UserService } from 'src/app/core/services/user.service';
import { environment } from 'src/environments/environment';
import ImageEditor from 'tui-image-editor';

@Component({
  selector: 'app-story-editor',
  templateUrl: './story-editor.component.html',
  styleUrls: ['./story-editor.component.scss'],
})
export class StoryEditorComponent {
  baseUrl = environment.baseWebApiUrl;

  @ViewChild('imageEditorContainer')
  private imageEditorContainer!: ElementRef<HTMLDivElement>;

  private _tuiImageEditor!: ImageEditor;
  public uploader!: FileUploader;
  private uploadedImageUrl: string = '';
  currentUser: any;

  constructor(
    private storyService: StoryService,
    private userService : UserService
  ) {
    this.userService
    .getCurrentUserData()
    .pipe(take(1))
    .subscribe({
      next: (user: any) => {
        this.currentUser = user;
      },
    });
  }

  ngAfterViewInit() {
    this.initializeUploader();
  }

  private initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl,

    });

    this.uploader.onAfterAddingFile = (fileItem: FileItem) => {
      const file = fileItem._file;
      const reader = new FileReader();

      reader.onload = (e) => {
        const image = new Image();
        image.src = e.target?.result as string;

        image.onload = () => {
          this.uploadedImageUrl = image.src;
          this.initializeImageEditor();
        };
      };

      reader.readAsDataURL(file);
    };

    this.uploader.onCompleteItem = (
      item: any,
      response: any,
      status: any,
      headers: any
    ) => {
      // Handle the server response after the image upload is complete
      console.log('Upload complete:', response);
    };
  }

  private initializeImageEditor() {
    this._tuiImageEditor = new ImageEditor(
      this.imageEditorContainer.nativeElement,
      {
        includeUI: {
          loadImage: {
            path: this.uploadedImageUrl,
            name: 'SampleImage',
          },
          theme: {
            // Customize the theme if needed
          },
        },
        cssMaxWidth: 1000,
        cssMaxHeight: 1000,
      }
    );
  }

  applyChanges() {
this.storyService.AddStory({
  title: "string",
  content: "string",
  imageUrl: "string",
  userId:this.currentUser.id

}).subscribe({
  next: (response : any) => {
    console.log(response)
    console.log(this.currentUser)
    this.uploader.setOptions({
      url: this.baseUrl + `Story/add-story-image/${response}`,
      authToken: 'Bearer ' + this.currentUser?.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024,
    });
    if (this._tuiImageEditor) {
      // Get the edited image data
      const editedImageData = this._tuiImageEditor.toDataURL();

      // Create a new Blob object from the edited image data
      const blob = this.dataURLToBlob(editedImageData);

      // Create a new File object with the edited image blob
      const editedImageFile = new File([blob], 'edited-image.png', { type: 'image/png' });

      // Remove the original image from the uploader's queue
      this.uploader.clearQueue();

      // Add the edited image file to the uploader's queue
      this.uploader.addToQueue([editedImageFile]);

      // Upload the edited image
      this.uploader.uploadAll();
    }
  }
  });
  }

  private dataURLToBlob(dataURL: string): Blob {
    const arr = dataURL.split(',');
    const mime = arr[0].match(/:(.*?);/)![1];
    const bstr = atob(arr[1]);
    let n = bstr.length;
    const u8arr = new Uint8Array(n);

    while (n--) {
      u8arr[n] = bstr.charCodeAt(n);
    }

    return new Blob([u8arr], { type: mime });
  }

}
