import { BaseModel } from './BaseModel';
import { User } from './User';

export interface Cover extends BaseModel {
  userId: number;
  url: string;
  publicId: string;
  isMain: boolean;
  user: User;
}
