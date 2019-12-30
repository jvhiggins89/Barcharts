import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatSliderChange } from '@angular/material';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import * as moment from 'moment';


@Component({
  selector: 'app-ppviewmodal',
  templateUrl: './ppviewmodal.component.html',
  styleUrls: ['./ppviewmodal.component.css']
})
export class PPViewModalComponenent implements OnInit {


  constructor(
    public dialogRef: MatDialogRef<PPViewModalComponenent>,
    @Inject(MAT_DIALOG_DATA) public data: Workout495.Models.ProgressPoints) {
  }

  cancel(): void {   
    this.dialogRef.close();
  }

  ngOnInit() {
    
  }
}

