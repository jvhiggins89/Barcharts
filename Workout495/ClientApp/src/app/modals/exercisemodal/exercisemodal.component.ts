import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormControl, Validators, FormGroup } from '@angular/forms';

@Component({
    selector: 'app-exercisemodal',
    templateUrl: './exercisemodal.component.html',
    styleUrls: ['./exercisemodal.component.css']
})
export class ExercisemodalComponent implements OnInit {
  exerciseForm: FormGroup;
  public cancelled: boolean = false;
    constructor(
        public dialogRef: MatDialogRef<ExercisemodalComponent>,
        @Inject(MAT_DIALOG_DATA) public data: Workout495.Models.Exercise) {
        
    }
   

  ngOnInit() {
    this.exerciseForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      reps: new FormControl('', [Validators.required, Validators.min(0), Validators.max(100)]),
      sets: new FormControl('', [Validators.required, Validators.min(0), Validators.max(100)]),
      weight: new FormControl('', [Validators.required, Validators.min(0), Validators.max(1000)]),
    });

    this.exerciseForm.controls['name'].setValue(this.data.name);
    this.exerciseForm.controls['reps'].setValue(this.data.reps);
    this.exerciseForm.controls['sets'].setValue(this.data.sets);
    this.exerciseForm.controls['weight'].setValue(this.data.weight);
    console.log(this.exerciseForm);
  }

  cancel(): void {
    this.dialogRef.close();
  }

  public loadData() {

  }

  public hasError = (controlName: string, errorName: string) => {
    return this.exerciseForm.controls[controlName].hasError(errorName);
  }

  public submit = (ef) => {
    if (this.exerciseForm.valid && !this.cancelled) {
      this.executeUpdate(ef);
    }
  }

  public executeUpdate = (ef) => {
    this.data.name = ef.name;
    this.data.reps = ef.reps;
    this.data.sets = ef.sets;
    this.data.weight = ef.weight;
    
    this.dialogRef.close(this.data as Workout495.Models.Exercise);
  }
}
