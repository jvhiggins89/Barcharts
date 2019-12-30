import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatSliderChange } from '@angular/material';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import * as moment from 'moment';


@Component({
  selector: 'app-goalsmodal',
  templateUrl: './goalsmodal.component.html',
  styleUrls: ['./goalsmodal.component.css']
})


export class GoalsmodalComponent implements OnInit {
  public goalForm: FormGroup;
  public cancelled: boolean = false;
  minDate = moment(new Date()).add(-2).format('YYYY-MM-DD');

  constructor(
    public dialogRef: MatDialogRef<GoalsmodalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Workout495.Models.Goals) { }


  cancel(): void {
    this.cancelled = true;
    this.dialogRef.close();
  }

  ngOnInit() {

    this.goalForm = new FormGroup({
      title: new FormControl('', [Validators.required, Validators.maxLength(30)]),
      description: new FormControl('', [Validators.maxLength(100)]),
      bmi: new FormControl('', [Validators.min(0), Validators.max(99)]),
      weight: new FormControl('', [Validators.min(0), Validators.max(1000)]),
      goalDatePicker: new FormControl(this.data.goalDate, [Validators.required, Validators.min(moment(new Date()).millisecond())]),
      weightSlider: new FormControl(''),
      bmiSlider: new FormControl('')
    });

    //update values
    this.goalForm.controls['title'].setValue(this.data.title);
    this.goalForm.controls['description'].setValue(this.data.description);
    this.goalForm.controls['bmi'].setValue(this.data.bmi);
    this.goalForm.controls['weight'].setValue(this.data.weight);
    this.goalForm.controls['goalDatePicker'].setValue(this.data.goalDate);
    this.goalForm.controls['bmiSlider'].setValue(this.data.bmi);
    this.goalForm.controls['weightSlider'].setValue(this.data.weight);
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.goalForm.controls[controlName].hasError(errorName);
  }

  public UpdateGoal = (gf) => {
    if (this.goalForm.valid && !this.cancelled) {
      this.ExecuteUpdate(gf);
    }
  }
  public ExecuteUpdate = (gf) => {
    this.data.title = gf.title || 0;
    this.data.description = gf.description || "";
    this.data.bmi = gf.bmi || 0;
    this.data.weight = gf.weight || 0;
    this.data.goalDate = gf.goalDatePicker;
    this.dialogRef.close(this.data as Workout495.Models.Goals);
  }

  public onInputChange(event: MatSliderChange, target: string) {
    this.goalForm.controls[target].setValue(event.value);
  }
}



