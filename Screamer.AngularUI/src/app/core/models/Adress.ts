import { BaseModel } from './BaseModel';
import { User } from './User';

export interface Adress extends BaseModel {
  Street: string;
  City: string;
  Country: string;
  UserId: number;
  User: User;
}
