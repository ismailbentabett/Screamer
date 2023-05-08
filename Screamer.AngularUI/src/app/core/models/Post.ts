import { BaseModel } from './BaseModel';
import { Reaction } from './Reaction';
import { User } from './User';

export interface Post extends BaseModel {
  Title: string;
  Content: string;
  ImageUrl: string;
  UserId: number;
  User: User;
  Comments: Comment[];
  Reactions: Reaction[];
  Views: number;
}
