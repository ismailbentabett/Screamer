import { User } from './User';

export class CommentParams {
  pageNumber = 1;
  pageSize = 5;
  orderBy = 'CreatedAt';
  postId!: number;
  parentCommentId!: number | null;
  commentId : any;
}
