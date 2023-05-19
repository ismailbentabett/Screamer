import { BaseModel } from './BaseModel';
import { User } from './User';

export interface Adress extends BaseModel {
  street: string;
  city: string;
  state: string;
  country: string;
  postalCode: string;
}
