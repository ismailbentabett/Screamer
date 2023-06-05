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
      website: 'Invalid website address.',
      phone: 'Invalid phone number.',
      zipCode: 'Invalid zip code.',
      date: 'Invalid date.',
      time: 'Invalid time.',
      street: 'Invalid street address.',
      city: 'Invalid city.',
      state: 'Invalid state.',
      country: 'Invalid country.',
      postalCode: 'Invalid postal code.',
      socialMediaUsername: 'Invalid social media username.',
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

  public Numbers(control: FormControl): ValidationErrors | null {
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

  public website(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp =
      /^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}$/;

    if (value && regex.test(value)) {
      return null; // Return null if the value does not contain special characters
    }

    return { website: true }; // Return the error if the value contains special characters
  }

  public phone(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /^\d{10}$/;

    if (value && regex.test(value)) {
      return null; // Return null if the value does not contain special characters
    }

    return { phone: true }; // Return the error if the value contains special characters
  }

  public street(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /^[a-zA-Z0-9\s,'-]*$/;

    if (value && regex.test(value)) {
      return null; // Return null if the value does not contain special characters
    }

    return { street: true }; // Return the error if the value contains special characters
  }
  public city(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /^[a-zA-Z\s,'-]*$/;

    if (value && regex.test(value)) {
      return null; // Return null if the value does not contain special characters
    }

    return { city: true }; // Return the error if the value contains special characters
  }
  public state(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /^[a-zA-Z\s,'-]*$/;

    if (value && regex.test(value)) {
      return null; // Return null if the value does not contain special characters
    }

    return { state: true }; // Return the error if the value contains special characters
  }
  public postalCode(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /^[0-9]*$/;

    if (value && regex.test(value)) {
      return null; // Return null if the value does not contain special characters
    }

    return { postalCode: true }; // Return the error if the value contains special characters
  }

  //social media username as do not write url just username or id
  public socialMediaUsername(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp =
      /^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}$/;

    if (value && !regex.test(value)) {
      return null; // Return null if the value does not contain special characters
    }

    return { socialMediaUsername: true }; // Return the error if the value contains special characters
  }
}
