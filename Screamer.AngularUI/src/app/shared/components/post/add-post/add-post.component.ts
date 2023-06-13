import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.scss'],
})
export class AddPostComponent {
  @Input() edit: boolean = false;
  @Input() post: any = null;
  @Output() editEvent = new EventEmitter<boolean>();

  getEditData(data: boolean) {
    console.log(data)
    this.edit = data;
    this.editEvent.emit(this.edit);
  }
}
