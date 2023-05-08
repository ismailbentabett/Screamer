import { BaseModel } from "./BaseModel"
import { Post } from "./Post";
import { User } from "./User";


export interface Reaction extends BaseModel {
        Name: string;
        Color: string;
        Value: string;
        Icon: string;
        PostId: string;
        CommentId: string;
        UserId: number;
        User: User;
        Post: Post;
        Comment: Comment;
    }
