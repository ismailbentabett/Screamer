import { Injectable } from '@angular/core';
import { FormControl, ValidationErrors } from '@angular/forms';

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
      minlength: `Minimum length is ${errorValue.requiredLength} characters.`,
      maxlength: `Maximum length is ${errorValue.requiredLength} characters.`,

      // Pattern
      pattern: 'Invalid format.',

      // Custom Validators
      nospecialCharacters: 'Special characters are not allowed.',
      specialCharacters: 'at least one Special character.',

      noNumbers: 'Numbers are not allowed.',
      Numbers: 'at least one Number.',
      noWhitespace: 'Whitespace characters are not allowed.',
      // Add more custom validators and their error messages as needed
    };

    return errorMessages[errorKey] || 'Invalid value.';
  }

  public getFirstErrorMessage(control: FormControl): string {
    const errors: string[] = this.getValidationErrors(control);
    return errors.length > 0 ? errors[0] : '';
  }

  public noNumbers(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /\d/;

    if (regex.test(value)) {
      return { noNumbers: true };
    }

    return null;
  }

  public Numbers
  (control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /\d/;
    if (regex.test(value)) {
      return null;
    }
    return { Numbers: true };
  }

  public noWhitespace(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /\s/;
    if (regex.test(value)) {
      return { noWhitespace: true };
    }
    return null;
  }
  public nospecialCharactersValidator(
    control: FormControl
  ): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /[!@#$%^&*()_+\-=[\]{};':"\\|,.<>/?]+/;

    if (value && !regex.test(value)) {
      return null; // Return null if the value does not contain special characters
    }

    return { nospecialCharacters: true }; // Return the error if the value contains special characters
  }
  public specialCharactersValidator(
    control: FormControl
  ): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /[!@#$%^&*()_+\-=[\]{};':"\\|,.<>/?]+/;

    if (value && regex.test(value)) {
      return null; // Return null if the value does not contain special characters
    }

    return { specialCharacters: true }; // Return the error if the value contains special characters
  }
}
