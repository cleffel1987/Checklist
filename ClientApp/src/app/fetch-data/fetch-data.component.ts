import { Component, Inject } from '@angular/core';
import { WelcomeService } from '../welcome.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})

export class FetchDataComponent {
  public greetings: string;


  constructor(private welcomeService: WelcomeService) {
    welcomeService.getSalutation().subscribe((data: any) => this.greetings = data);
  }
}
