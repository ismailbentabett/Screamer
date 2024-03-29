import { Component, Input } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ValidationService } from 'src/app/core/services/validation.service';

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
  @Input() autocomplete: string = '';
  @Input() classStyle: string = '';
  @Input() error: string = '';
  @Input() special: boolean = false;
  @Input() formGroupName: string | null = null;
  private isFocused: boolean = false;

  constructor(private validationService: ValidationService) {}

  public get control(): FormControl {
    if (this.formGroupName) {
      const formGroup = this.form?.get(this.formGroupName) as FormGroup;
      return formGroup.get(this.formControlNameText) as FormControl;
    } else {
      return this.form?.get(this.formControlNameText) as FormControl;
    }
  }

  public get firstErrorMessage(): string | null {
    return this.validationService.getFirstErrorMessage(this.control);
  }

  public onFocus(): void {
    this.isFocused = true;
  }

  public onBlur(): void {
    this.isFocused = false;
    // Trigger validation on blur
    if (this.control) {
      this.control.markAsTouched();
    }
  }

  public showError(): boolean {
    if (this.formGroupName) {
      const formGroup = this.form?.get(this.formGroupName) as FormGroup;
      const formControl = formGroup?.get(
        this.formControlNameText
      ) as FormControl;
      return (
        formControl &&
        formControl.invalid &&
        (formControl.touched || this.isFocused)
      );
    } else {
      return (
        this.control &&
        this.control.invalid &&
        (this.control.touched || this.isFocused)
      );
    }
  }

  inputClass() {
    return this.showError()
      ?  'shadow-sm ring-red-500 border-red-500 focus:ring-red-500 focus:border-red-500 block w-full sm:text-sm border-gray-300 rounded-md'
      : this.classStyle;
  }
  textareaClass() {
    return this.showError()
      ?  'shadow-sm focus:ring-red-500 focus:border-red-500 mt-1 block w-full sm:text-sm border border-red-300 rounded-md'
      : 'shadow-sm focus:ring-dodger-blue-500 focus:border-dodger-blue-500 mt-1 block w-full sm:text-sm border border-gray-300 rounded-md';
  }



}
