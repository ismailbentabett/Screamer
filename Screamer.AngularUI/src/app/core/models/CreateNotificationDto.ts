export interface CreateNotificationDto {
  message?: string;
  type?: string;
  chatRoomId?: number;
  notificationRoomId?: string;
  postId?: number;
  senderId?: string;
  recieverId?: string;
  commentId?: number;
  replyId?: number;
  reactionId?: number;
  tagId?: number;
  mentionId?: number;
  isRead?: boolean ;
}
