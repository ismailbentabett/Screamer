import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.scss']
})
export class AddPostComponent {
@Input () edit : boolean = false;
@Input () post : any = null;
}
