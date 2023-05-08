import { BaseModel } from './BaseModel';
import { User } from './User';

export interface Social extends BaseModel {
  Facebook: string;
  Twitter: string;
  Instagram: string;
  Youtube: string;
  Twitch: string;
  Tiktok: string;
  Snapchat: string;
  Pinterest: string;
  Reddit: string;
  Linkedin: string;
  Github: string;
  Website: string;
  UserId: number;
  User: User;
}
