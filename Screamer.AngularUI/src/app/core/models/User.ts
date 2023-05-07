import { Adress } from './Adress';
import { Avatar } from './Avatar';
import { BaseModel } from './BaseModel';
import { Follow } from './Follow';
import { Post } from './Post';
import { Role } from './Role';
import { Social } from './Social';

export interface User extends BaseModel {
  Username: string;
  Password: string;
  Email: string;
  Roles: Role[];
  FirstName: string;
  LastName: string;
  Cover: string;
  Bio: string;
  Website: string;
  Adress: Adress;
  Birthday: string;
  Gender: string;
  Phone: string;
  Social: Social;
  Avatars: Avatar[];
  Posts: Post[];
  Followers: Follow[];
  Followings: Follow[];
}
