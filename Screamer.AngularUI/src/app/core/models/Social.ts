import { BaseModel } from './BaseModel';
import { User } from './User';

export interface Social extends BaseModel {
  facebook: string;
  twitter: string;
  instagram: string;
  youtube: string;
  twitch: string;
  tiktok: string;
  snapchat: string;
  pinterest: string;
  reddit: string;
  linkedin: string;
  github: string;
  discord: string;
  whatsapp: string;
  telegram: string;
  skype: string;
  viber: string;
  signal: string;
  slack: string;
  wechat: string;
  onlyfans: string;
  patreon: string;
  medium: string;
  tumblr: string;
}
