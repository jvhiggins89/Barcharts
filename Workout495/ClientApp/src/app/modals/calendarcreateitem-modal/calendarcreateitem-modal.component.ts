import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Enums } from '../../../models/Enums'

@Component({
  selector: 'app-calendarcreateworkoutmodal',
  templateUrl: './calendarcreateitem-modal.component.html',
  styleUrls: ['./calendarcreateitem-modal.component.css']
})
export class CalendarCreateItemModalComponent implements OnInit {
  itemType: Enums.CalendarItem;
    constructor(
        public dialogRef: MatDialogRef<CalendarCreateItemModalComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any) {
    }

    closeModal(data): void {
        this.dialogRef.close(data);
    }

  addWorkout() {
   
    this.data = {
      date: this.data.date,
      itemType: Enums.CalendarItem.workout //move to enum
    }
    this.closeModal(this.data);
  }

  addGoal() {
    this.data = {
      date: this.data.date,
      itemType: Enums.CalendarItem.goal //move to enum
    }
    this.closeModal(this.data);
  }

  addProgressPoint() {
    this.data = {
      date: this.data.date,
      itemType: Enums.CalendarItem.progressPoint//move to enum
    }
    this.closeModal(this.data);
  }

    ngOnInit() {
    }
}
