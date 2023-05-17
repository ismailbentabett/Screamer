import { User } from './User';

export class PostParams {
  pageNumber = 1;
  pageSize = 5;
  orderBy = 'CreatedAt';
  userId!: number;
  postId!: number;
}
