import { Component, Output, EventEmitter, OnInit } from '@angular/core';
import { TaskGroupService } from '../taskgroup.service';
import { formatDate } from '@angular/common';
import { TaskService } from '../Task.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-checklist-component',
  templateUrl: './checklist.component.html'
})

export class ChecklistComponent implements OnInit {
  public groups: TaskGroup[];
  public tasks: Tasks[];
  public groupid: string = '';

  constructor(private taskGroupService: TaskGroupService) { }

  ngOnInit(): void {
    this.taskGroupService.getGroups().subscribe((data: any) => this.groups = data);
  }

  getTasks(groupid: string): void {
    this.groupid = groupid;
    this.taskGroupService.getTasks(this.groupid).subscribe((data: any) => this.tasks = data);
  }

}

interface TaskGroup {
  id: string;
  groupname: string;
  complete: boolean;
  adddate: string;
}

interface Tasks {
  id: string;
  taskGroup: TaskGroup;
  taskGroupId: string;
  taskcomplete: boolean;
  tasktitle: string;
  adddate: string;
}




