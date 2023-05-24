import { BaseModel } from './BaseModel';
import { User } from './User';

export interface PostImage extends BaseModel {
  postId: number;
  url: string;
  publicId: string;
  isMain: boolean;
}
