import { User } from './User';

export class RecommendationParams {
  pageNumber = 1;
  pageSize = 5;
  orderBy = 'CreatedAt';
  userId!: string;
  postId!: number;
  predicate = 'following';
}
