import { Component } from '@angular/core';
import { TaskGroupService } from '../taskgroup.service';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-checklist-component',
  templateUrl: './checklist.component.html'
})

export class ChecklistComponent {
  public groups: TaskGroup[];


  constructor(private welcomeService: TaskGroupService) {
    welcomeService.getGroups().subscribe((data: any) => this.groups = data);
  }
}

interface TaskGroup {
  id: string;
  groupname: string;
  complete: boolean;
  adddate: string;
}




