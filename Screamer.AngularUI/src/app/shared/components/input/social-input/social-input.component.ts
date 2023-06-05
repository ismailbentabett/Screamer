import { Component, Input } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ValidationService } from 'src/app/core/services/validation.service';

@Component({
  selector: 'app-social-input',
  templateUrl: './social-input.component.html',
  styleUrls: ['./social-input.component.scss'],
})
export class SocialInputComponent {
  @Input() public form!: FormGroup;

  @Input() data!: string;
  isFocused: boolean = false;
  constructor(private validationService: ValidationService) {
    console.log(this.data)
  }
  control!: FormControl;
  controlFun(name: string) {
    this.control = this.form!.get(name) as FormControl;
  }

  public get firstErrorMessage(): string {
    return this.validationService.getFirstErrorMessage(this.control);
  }

  public onFocus(): void {
    this.isFocused = true;
  }

  public onBlur(): void {
    this.isFocused = false;
    // Trigger validation on blur
    this.control.markAsTouched();
  }

  public showError(): boolean {
    return this.control.invalid && (this.control.touched || this.isFocused);
  }
}
