import { User } from './User';

export class NotificationParams {
  orderBy = 'CreatedAt';
  senderId!: string;
  pageNumber = 1;
  pageSize = 5;
}
