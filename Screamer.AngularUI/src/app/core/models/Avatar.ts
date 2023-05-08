import { BaseModel } from './BaseModel';
import { User } from './User';

export interface Avatar extends BaseModel {
  ImageUrl: string;
  UserId: number;
  User: User;
}
