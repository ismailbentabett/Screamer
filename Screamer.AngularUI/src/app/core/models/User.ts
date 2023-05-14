import { Adress } from './Adress';
import { Avatar } from './Avatar';
import { BaseModel } from './BaseModel';
import { Follow } from './Follow';
import { Post } from './Post';
import { Role } from './Role';
import { Social } from './Social';

export interface User extends BaseModel {
  avatarUrl: string;
  username: string;
  password: string;
  email: string;
  roles: Role[];
  firstName: string;
  lastName: string;
  cover: string;
  bio: string;
  website: string;
  adress: Adress;
  birthday: string;
  gender: string;
  phone: string;
  social: Social;
  avatars: Avatar[];
  posts: Post[];
  followers: Follow[];
  followings: Follow[];
  token: string;

}
