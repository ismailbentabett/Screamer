import { Injectable } from '@angular/core';
import { FormControl } from '@angular/forms';

@Injectable({
  providedIn: 'root',
})
export class ValidationService {
  constructor() {}

  public getValidationErrors(control: FormControl): string[] {
    const errors: string[] = [];

    if (control.errors) {
      for (const errorKey in control.errors) {
        if (control.errors.hasOwnProperty(errorKey)) {
          const errorMessage = this.getErrorMessage(
            errorKey,
            control.errors[errorKey]
          );
          errors.push(errorMessage);
        }
      }
    }

    return errors;
  }

  public getErrorMessage(errorKey: string, errorValue: any): string {
    const errorMessages: any = {
      // Required
      required: 'This field is required.',

      // Email
      email: 'Invalid email address.',

      // Min/Max Length
      minlength: `Minimum length is ${errorValue.requiredLength}.`,
      maxlength: `Maximum length is ${errorValue.requiredLength}.`,

      // Pattern
      pattern: 'Invalid format.',

      // Custom Validators
      specialCharacters: 'Special characters are not allowed.',
      noNumbers: 'Numbers are not allowed.',
      noWhitespace: 'Whitespace characters are not allowed.',
      // Add more custom validators and their error messages as needed

    };

    return errorMessages[errorKey] || 'Invalid value.';
  }
}
