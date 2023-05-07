import { BaseModel } from './BaseModel';
import { Post } from './Post';
import { Reaction } from './Reaction';
import { User } from './User';

export interface Comment extends BaseModel {
  Content: string;
  UserId: number;
  User: User;
  PostId: string;
  Post: Post;
  ParentId: string;
  Comments: Comment[];
  CommentableId: string;
  CommentableType: string;
  Reactions: Reaction[];
}
