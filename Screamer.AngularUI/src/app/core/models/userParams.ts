import { User } from './User';

export class UserParams {
  pageNumber = 1;
  pageSize = 10;
  orderBy = 'CreatedAt';
  userId!: number;
}
