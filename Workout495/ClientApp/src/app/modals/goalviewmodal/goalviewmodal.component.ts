import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatSliderChange } from '@angular/material';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import * as moment from 'moment';


@Component({
  selector: 'app-goalviewmodal',
  templateUrl: './goalviewmodal.component.html',
  styleUrls: ['./goalviewmodal.component.css']
})
export class GoalViewModalComponent implements OnInit {


  constructor(
    public dialogRef: MatDialogRef<GoalViewModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Workout495.Models.Goals) {
  }

  cancel(): void {   
    this.dialogRef.close();
  }

  ngOnInit() {
    
  }
}

