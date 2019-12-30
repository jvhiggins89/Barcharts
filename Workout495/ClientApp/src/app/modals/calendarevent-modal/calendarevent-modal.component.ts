import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Enums } from '../../../models/Enums';

@Component({
  selector: 'app-calendarevent-modal',
  templateUrl: './calendarevent-modal.component.html',
  styleUrls: ['./calendarevent-modal.component.css']
})
export class CalendareventModalComponent implements OnInit {
  isWorkout: boolean = false;
  isGoal: boolean = false;
  isProgressPoint = false;
  constructor(
    public dialogRef: MatDialogRef<CalendareventModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
  }


  ngOnInit() {
    if (this.data.eventType == Enums.CalendarItem.workout) {
      this.isWorkout = true;
    } else if (this.data.eventType == Enums.CalendarItem.goal) {
      this.isGoal = true;
    } else if (this.data.eventType == Enums.CalendarItem.progressPoint) {
      this.isProgressPoint = true;
    }
    console.log(this.data);
  }
 
}
