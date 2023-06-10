import { Injectable } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  ValidationErrors,
} from '@angular/forms';

@Injectable({
  providedIn: 'root',
})
export class ValidationService {
  constructor() {}

  public getValidationErrors(
    control: AbstractControl,
    controlPath: string = ''
  ): string[] {
    const errors: string[] = [];

    if (control instanceof FormGroup) {
      const formGroup = control as FormGroup;
      Object.keys(formGroup.controls).forEach((key) => {
        const nestedControlPath = controlPath ? `${controlPath}.${key}` : key;
        const nestedControl = formGroup.controls[key];
        const nestedErrors = this.getValidationErrors(
          nestedControl,
          nestedControlPath
        );
        errors.push(...nestedErrors);
      });
    } else if (control instanceof FormControl && control.errors) {
      Object.keys(control.errors).forEach((errorKey) => {
        const errorMessage = this.getErrorMessage(
          errorKey,
          control.errors![errorKey],
          controlPath
        );
        errors.push(errorMessage);
      });
    }

    return errors;
  }

  public getErrorMessage(
    errorKey: string,
    errorValue: any,
    controlPath: string = ''
  ): string {
    const errorMessages: any = {
      // Required
      required: 'This field is required.',
      // Email
      email: 'Invalid email address.',
      // Min/Max Length
      minlength: `Minimum length is ${errorValue?.requiredLength}.`,
      maxlength: `Maximum length is ${errorValue?.requiredLength}.`,
      // Pattern
      pattern: 'Invalid format.',
      // Custom Validators
      nospecialCharacters: 'Special characters are not allowed.',
      specialCharacters: 'At least one special character is required.',
      noNumbers: 'Numbers are not allowed.',
      Numbers: 'At least one number is required.',
      noWhitespace: 'Whitespace characters are not allowed.',
      // Add more custom validators and their error messages as needed

      // Default
      socialMediaUsername: 'Value Not Valid.',
      postalCode: 'Invalid postal code.',
      phoneNumber: 'Invalid phone number.',
      state: 'Invalid state.',
      city: 'Invalid city.',
      address: 'Invalid address.',
      country: 'Invalid country.',
      date: 'Invalid date.',
      time: 'Invalid time.',
      url: 'Invalid url.',
      website: 'Invalid website.',
      birthday: 'Invalid birthday.',
      mismatch: 'Password mismatch.',

      sameAsOld: 'New password cannot be the same as old password.',
    };

    const controlName = controlPath.split('.').pop();
    const controlLabel = controlName ? `${controlName} ` : '';
    const errorMessage = errorMessages[errorKey] || 'Invalid value.';
    return `${controlLabel}${errorMessage}`;
  }
  public getFirstErrorMessage(control: FormControl): string {
    const errors: string[] = this.getValidationErrors(control);
    return errors.length > 0 ? errors[0] : '';
  }

  // Custom Validators
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
      return null;
    }

    return { nospecialCharacters: true };
  }

  public specialCharactersValidator(
    control: FormControl
  ): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /[!@#$%^&*()_+\-=[\]{};':"\\|,.<>/?]+/;
    if (value && regex.test(value)) {
      return null;
    }
    return { specialCharacters: true };
  }

  //socialMediaUsername
  public socialMediaUsername(control: FormControl): ValidationErrors | null {
    //social media username style no url
    const value: string = control.value;
    const regex: RegExp = /[A-Za-z0-9_]{1,15}/;

    if (value && regex.test(value)) {
      return null;
    }
    return { socialMediaUsername: true };
  }
  //postalCode
  public postalCode(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /[0-9]{5}/;

    if (value && regex.test(value)) {
      return null;
    }

    return { postalCode: true };
  }
  //phoneNumber
  public phone(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /[0-9]{10}/;

    if (value && regex.test(value)) {
      return null;
    }

    return { phoneNumber: true };
  }
  //noNumbers
  public noNumbersValidator(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /[0-9]/;

    if (value && !regex.test(value)) {
      return null;
    }

    return { noNumbers: true };
  }
  //state

  public state(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /[A-Z]{2}/;

    if (value && regex.test(value)) {
      return null;
    }

    return { state: true };
  }
  //city
  public city(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /[A-Z]{2}/;

    if (value && regex.test(value)) {
      return null;
    }

    return { city: true };
  }
  //country
  public country(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /[A-Z]{2}/;

    if (value && regex.test(value)) {
      return null;
    }

    return { country: true };
  }
  //address
  public address(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /[A-Z]{2}/;

    if (value && regex.test(value)) {
      return null;
    }

    return { address: true };
  }
  //street
  public street(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /[A-Z]{2}/;

    if (value && regex.test(value)) {
      return null;
    }

    return { street: true };
  }
  //website
  public website(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp =
      /((https?|ftp|smtp):\/\/)?(www.)?[a-z0-9]+\.[a-z]+(\/[a-zA-Z0-9#]+\/?)*$/;

    if (value && regex.test(value)) {
      return null;
    }

    return { website: true };
  }
  //birthday
  public birthday(control: FormControl): ValidationErrors | null {
    const value: string = control.value;
    const regex: RegExp = /[0-9]{4}-[0-9]{2}-[0-9]{2}/;

    if (value && regex.test(value)) {
      return null;
    }

    return { birthday: true };
  }
}

//specialCharactersValidator
