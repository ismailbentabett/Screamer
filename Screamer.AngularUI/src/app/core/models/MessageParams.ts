export class MessageParams {
  pageNumber = 1;
  pageSize = 5;
  orderBy = 'CreatedAt';
  userId!: string;
  currentUserId!: string;
  container!: string;

}
