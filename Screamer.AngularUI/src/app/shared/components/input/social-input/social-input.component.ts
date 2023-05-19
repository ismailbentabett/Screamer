import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-social-input',
  templateUrl: './social-input.component.html',
  styleUrls: ['./social-input.component.scss'],
})
export class SocialInputComponent {
  @Input() public form!: FormGroup;

  @Input() data!: string;

}
