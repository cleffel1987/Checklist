import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { getBaseUrl } from '../main';

@Injectable()
export class TaskService {
  private headers: HttpHeaders;
  private accessPointUrl: string = getBaseUrl() + 'tasks';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public getTasks(model) {
    return this.http.get(this.accessPointUrl + '/' + model.taskgroupid, { headers: this.headers });
  }

  public addTask(model) {
    return this.http.post(this.accessPointUrl, model, { headers: this.headers });
  }

  public removeTask(model) {
    return this.http.delete(this.accessPointUrl + '/' + model.id, { headers: this.headers });
  }

  public updateTask(model) {
    return this.http.put(this.accessPointUrl + '/' + model.id, model, { headers: this.headers });
  }
}