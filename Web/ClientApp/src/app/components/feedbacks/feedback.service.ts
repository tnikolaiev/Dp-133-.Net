import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { ActivatedRoute } from '@angular/router';
import { environment } from "../../../environments/environment";

@Injectable()
export class FeedbackService {
  private appUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.appUrl = baseUrl;
  }

  getTeacherInGroup(groupId: number): Observable<any> {
    console.log('FeedbackService.getAll:' + groupId + '/' + this.appUrl);
    return this.http.get(this.appUrl + 'api/Feedback/inGroup/' + groupId);
  }
}
