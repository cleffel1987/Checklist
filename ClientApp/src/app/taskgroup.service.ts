import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { getBaseUrl } from '../main';

@Injectable()
export class TaskGroupService {
  private headers: HttpHeaders;
  private accessPointUrl: string = getBaseUrl() + 'taskgroups';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public getGroups() {
    return this.http.get(this.accessPointUrl , { headers: this.headers });
  }

  public addGroup(model) {
    return this.http.post(this.accessPointUrl, model, { headers: this.headers });
  }

  public removeGroup(model) {
    return this.http.delete(this.accessPointUrl + '/' + model.id, { headers: this.headers });
  }

  public updateGroup(model) {
    return this.http.put(this.accessPointUrl + '/' + model.id, model, { headers: this.headers });
  }
}
