import { Directive, ElementRef, Input, OnChanges, SimpleChanges } from '@angular/core';

@Directive({
  selector: 'img[thumbnail]'
})
export class ThumbnailDirective {

  @Input() public image: any;

  constructor(private el: ElementRef) { }

  public ngOnChanges(changes: SimpleChanges) {

    let reader = new FileReader();
    let el = this.el;

    reader.onloadend = (readerEvent) => {
      let image = new Image();
      image.onload = (imageEvent) => {
          // Resize the image
          let canvas = document.createElement('canvas');
          let maxSize = 70;
          let width = image.width;
          let height = image.height;
          if (width > height) {
              if (width > maxSize) {
                  height *= maxSize / width;
                  width = maxSize;
              }
          } else {
              if (height > maxSize) {
                  width *= maxSize / height;
                  height = maxSize;
              }
          }
          canvas.width = width;
          canvas.height = height;
          canvas.getContext('2d')!.drawImage(image, 0, 0, width, height);
          el.nativeElement.src = canvas.toDataURL('image/jpeg');
      };
      image.src = reader.result as any;
    };

    if (this.image) {
      return reader.readAsDataURL(this.image);
    }

  }

}
