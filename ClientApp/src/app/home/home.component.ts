import { Component, Inject, OnInit, Output } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { WelcomeService } from '../welcome.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})


export class HomeComponent {
  public greetings: string;


  constructor(private welcomeService: WelcomeService) {
    welcomeService.getSalutation().subscribe((data: any) => this.greetings = data);
  }

}
