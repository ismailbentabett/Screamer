import { Component, ElementRef, ViewChild } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { PostService } from 'src/app/core/services/post.service';
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

  constructor(private postService: PostService) { }

  ngAfterViewInit() {
    this.initializeUploader();
  }

  private initializeUploader() {
    this.uploader = new FileUploader({
      url: 'https://example.com/upload', // Replace with your server-side upload endpoint
      itemAlias: 'file',
      autoUpload: false
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
      const reader = new FileReader();

      reader.onload = (e) => {
        const image = new Image();
        image.src = e.target?.result as string;

        image.onload = () => {
          this.uploadedImageUrl = image.src;
          this.initializeImageEditor();
        };
      };

      reader.readAsDataURL(file._file);
    };

    this.uploader.onCompleteItem = (item: any, response: any, status: any, headers: any) => {
      // Handle the server response after the image upload is complete
      console.log('Upload complete:', response);
    };
  }

  private initializeImageEditor() {
    this._tuiImageEditor = new ImageEditor(this.imageEditorContainer.nativeElement, {
      includeUI: {
        loadImage: {
          path: this.uploadedImageUrl,
          name: 'SampleImage'
        },
        theme: {
          // Customize the theme if needed
        }
      },
      cssMaxWidth: 700,
      cssMaxHeight: 500,
      selectionStyle: {
        cornerSize: 20,
        rotatingPointOffset: 70
      }
    });
  }

  applyChanges() {
    // Get the edited image data
    const editedImageData = this._tuiImageEditor.toDataURL();

    // Upload the edited image
    this.uploader.setOptions({
      additionalParameter: { data: editedImageData },
      url: ''
    });
    this.uploader.uploadAll();
  }
}
