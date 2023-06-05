import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.scss'],
})
export class InputComponent {
  @Input() form: FormGroup | null = null;
  @Input() formControlNameText: string = '';
  @Input() name: string = '';
  @Input() label: string = '';
  @Input() inputType: string = 'text';
  @Input() placeholder: string = '';
  @Input() classStyle: string = '';
  @Input() error: string = '';
}
