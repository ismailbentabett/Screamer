import { BaseModel } from './BaseModel';
import { User } from './User';

export interface Follow extends BaseModel {
  FollowingId: string;
  FollowerId: string;
  Follower: User;
  Following: User;
}
