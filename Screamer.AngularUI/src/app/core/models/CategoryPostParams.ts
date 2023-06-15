import { User } from './User';

export class CategoryPostParams {
  pageNumber = 1;
  pageSize = 5;
  orderBy = 'CreatedAt';
  userId!: string;
  postId!: number;
  category!: string;
}
