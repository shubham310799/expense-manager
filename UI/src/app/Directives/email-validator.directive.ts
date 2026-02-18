import { Directive } from '@angular/core';
import { AbstractControl, NG_VALIDATORS, ValidationErrors, Validator } from '@angular/forms';

@Directive({
  selector: '[appEmailValidator]',
  standalone: true,
  providers:[{provide:NG_VALIDATORS, useExisting:EmailValidatorDirective, multi:true}]
})
export class EmailValidatorDirective implements Validator {

  emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
  constructor() { }

  validate(control: AbstractControl): ValidationErrors | null {
    let currentVal = control.value; // gets the value of the field where it is applied
    return this.emailRegex.test(currentVal) ? null : {emailValid : {valid : false}}
  }
}
