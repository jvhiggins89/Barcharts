import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatSliderChange } from '@angular/material';
import { FormControl, Validators, FormGroup, ValidatorFn, AbstractControl } from '@angular/forms';
import * as moment from 'moment';


@Component({
  selector: 'app-progresspointsmodal',
  templateUrl: './progresspointsmodal.component.html',
  styleUrls: ['./progresspointsmodal.component.css']
})
export class ProgressPointsModalComponent implements OnInit {
  public ppForm: FormGroup;
  public cancelled: boolean = false;
  minDate = moment(new Date()).add(-2).format('YYYY-MM-DD');


  constructor(
    public dialogRef: MatDialogRef<ProgressPointsModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Workout495.Models.ProgressPoints) {

  }

  cancel(): void {
    this.cancelled = true;
    this.dialogRef.close();
  }

  ngOnInit() {

    this.ppForm = new FormGroup({
      title: new FormControl('', [Validators.required, Validators.maxLength(30)]),
      description: new FormControl('', [Validators.maxLength(100)]),
      bmi: new FormControl('', [Validators.min(0), Validators.max(99)]),
      weight: new FormControl('', [Validators.min(0), Validators.max(1000)]),
      ppDatePicker: new FormControl(this.data.progressPointDate, [Validators.required, Validators.min(moment(new Date()).millisecond())]),
      weightSlider: new FormControl(''),
      bmiSlider: new FormControl('')
    });

    //update values
    this.ppForm.controls['title'].setValue(this.data.title);
    this.ppForm.controls['description'].setValue(this.data.description);
    this.ppForm.controls['bmi'].setValue(this.data.bmi);
    this.ppForm.controls['weight'].setValue(this.data.weight);
    this.ppForm.controls['ppDatePicker'].setValue(this.data.progressPointDate);
    this.ppForm.controls['bmiSlider'].setValue(this.data.bmi);
    this.ppForm.controls['weightSlider'].setValue(this.data.weight);
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.ppForm.controls[controlName].hasError(errorName);
  }

  public UpdatePP = (gf) => {
    if (this.ppForm.valid && !this.cancelled) {
      this.ExecuteUpdate(gf);
    }
  }
  public ExecuteUpdate = (gf) => {
    this.data.title = gf.title || 0;
    this.data.description = gf.description || "";
    this.data.bmi = gf.bmi || 0;
    this.data.weight = gf.weight || 0;
    this.data.progressPointDate = gf.ppDatePicker;
    this.dialogRef.close(this.data as Workout495.Models.ProgressPoints);
  }

  public onInputChange(event: MatSliderChange, target: string) {
    this.ppForm.controls[target].setValue(event.value);

  }


}

