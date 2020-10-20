import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { getBaseUrl } from '../main';

@Injectable()
export class TaskGroupService {
  private headers: HttpHeaders;
  private accessPointUrl: string = getBaseUrl();

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public getTasks(model) {
    return this.http.get(this.accessPointUrl + 'tasks' + '/' + model, { headers: this.headers });
  }

  public addTask(model) {
    return this.http.post(this.accessPointUrl + 'tasks', model, { headers: this.headers });
  }

  public removeTask(model) {
    return this.http.delete(this.accessPointUrl + 'tasks'  + '/' + model.id, { headers: this.headers });
  }

  public updateTask(model) {
    return this.http.put(this.accessPointUrl + 'tasks'  + '/' + model.id, model, { headers: this.headers });
  }


  public getGroups() {
    return this.http.get(this.accessPointUrl + 'taskgroups', { headers: this.headers });
  }

  public addGroup(model) {
    return this.http.post(this.accessPointUrl + 'taskgroups', model, { headers: this.headers });
  }

  public removeGroup(model) {
    return this.http.delete(this.accessPointUrl + 'taskgroups' + '/' + model.id, { headers: this.headers });
  }

  public updateGroup(model) {
    return this.http.put(this.accessPointUrl + 'taskgroups' + '/' + model.id, model, { headers: this.headers });
  }
}
