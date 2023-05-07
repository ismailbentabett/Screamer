import { BaseModel } from "./BaseModel";
import { User } from "./User";

export interface Role extends BaseModel {

        Name: string;
        Description: string;
        UserId: number;
        User: User;
    }

