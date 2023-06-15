import { User } from './User';

export class HashtagPostParams {
  pageNumber = 1;
  pageSize = 5;
  orderBy = 'CreatedAt';
  userId!: string;
  postId!: number;
  hashtagName!: string;
}
