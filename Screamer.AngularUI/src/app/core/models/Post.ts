import { BaseModel } from './BaseModel';
import { Reaction } from './Reaction';
import { User } from './User';

export interface Post extends BaseModel {
  title: string;
  content: string;
  imageUrl: string;
  userId: number;
  user: User;
  comments: Comment[];
  reactions: Reaction[];
  views: number;
}
