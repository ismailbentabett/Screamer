import { Adress } from "./Adress";
import { BaseModel } from "./BaseModel";
import { Social } from "./Social";

export interface UserUpdateInput extends BaseModel {

  userName: string;
  firstName: string;
  lastName: string;
  bio: string;
  website: string;
  adress: Adress;
  birthday: string;
  gender: string;
  phone: string;
  social: Social;

}
