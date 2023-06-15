import { HttpClient, HttpParams } from '@angular/common/http';
import { map } from 'rxjs';
import { PaginatedResult } from '../models/Pagination';

export function getPaginatedResult<T>(
  url: string,
  params: HttpParams,
  http: HttpClient
) {
  const paginatedResult: PaginatedResult<T> = new PaginatedResult<T>();
  return http.get<T>(url, { observe: 'response', params }).pipe(
    map((response) => {
      if (response.body) {
        paginatedResult.result = response.body;
      }
      const pagination = response.headers.get('Pagination');
      if (pagination) {
        paginatedResult.pagination = JSON.parse(pagination);
      }
      return paginatedResult;
    })
  );
}

export function getPaginationHeaders(
  orderBy: string,
  userId: string,
  pageNumber: number,
  pageSize: number
) {
  let params = new HttpParams();
  if (userId) {
    params = params.append('userId', userId);
  }

  params = params.append('orderBy', orderBy);

  params = params.append('pageNumber', pageNumber);
  params = params.append('pageSize', pageSize);

  return params;
}
export function getCategoryPaginationHeaders(
  orderBy: string,
  userId: string,
  pageNumber: number,
  pageSize: number,
  category: string
) {
  let params = new HttpParams();
  if (userId) {
    params = params.append('userId', userId);
  }
  params = params.append('orderBy', orderBy);

  params = params.append('category', category);

  params = params.append('pageNumber', pageNumber);
  params = params.append('pageSize', pageSize);

  return params;
}
export function getHashtagPaginationHeaders(
  orderBy: string,
  userId: string,
  pageNumber: number,
  pageSize: number,
  hashtagName: string
) {
  let params = new HttpParams();
  if (userId) {
    params = params.append('userId', userId);
  }
  params = params.append('orderBy', orderBy);

  params = params.append('hashtagName', hashtagName);

  params = params.append('pageNumber', pageNumber);
  params = params.append('pageSize', pageSize);

  return params;
}
export function getCommentPaginationHeaders(
  orderBy: string,
  postId: number,
  parentCommentId: number | null,
  pageNumber: number,
  pageSize: number,
  commentId: any
) {
  let params = new HttpParams();
  if (postId) {
    params = params.append('postId', postId);
  }
  if (parentCommentId) {
    params = params.append('parentCommentId', parentCommentId);
  }
  if (commentId) {
    params = params.append('commentId', commentId);
  }

  params = params.append('orderBy', orderBy);

  params = params.append('pageNumber', pageNumber);
  params = params.append('pageSize', pageSize);

  return params;
}
export function getPaginationHeadersMessages(
  orderBy: string,
  userId: string,
  pageNumber: number,
  pageSize: number,
  currentUserId: string
) {
  let params = new HttpParams();
  if (userId) {
    params = params.append('userId', userId);
  }
  if (currentUserId) {
    params = params.append('currentUserId', currentUserId);
  }
  params = params.append('orderBy', orderBy);

  params = params.append('pageNumber', pageNumber);
  params = params.append('pageSize', pageSize);

  return params;
}
export function getThePaginationHeaders(pageNumber: number, pageSize: number) {
  let params = new HttpParams();

  params = params.append('pageNumber', pageNumber);
  params = params.append('pageSize', pageSize);

  return params;
}
