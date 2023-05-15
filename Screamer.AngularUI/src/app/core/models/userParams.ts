import { User } from './User';

export class UserParams {
  pageNumber = 1;
  pageSize = 5;
  orderBy = 'CreatedAt';
  userId!: number;
}
