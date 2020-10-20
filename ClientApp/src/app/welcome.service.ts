import { Injectable, Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { getBaseUrl } from '../main';

export enum AuthenticationResultStatus {
  Success,
  Redirect,
  Fail
}

export interface IUser {
  name?: string;
}

@Injectable({
  providedIn: 'root'
})

export class WelcomeService {
  private headers: HttpHeaders;
  private accessPointUrl: string = getBaseUrl() + 'greetings';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public getSalutation() {
    // Get salutation data
    return this.http.get(this.accessPointUrl, { headers: this.headers });
  }
}
