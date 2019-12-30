import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatPaginator, MatTableDataSource } from '@angular/material';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import * as moment from 'moment';

@Component({
  selector: 'app-workoutmodal',
  templateUrl: './workoutmodal.component.html',
  styleUrls: ['./workoutmodal.component.css']
})
export class WorkoutmodalComponent implements OnInit {

    dataSource: any;
    columnHeaders: string[];
    workout: Workout495.Models.Workout = {
        id: null,
        name: null,
        userId: null,
        scheduledDate: null,
        active: null,
        exercises: []
    }

    originalData: any[];
    originalName: string;

    availableColumnHeaders: string[];
    availableData: any;
    available: Workout495.Models.Exercise[] = [];

    nameInput;

    newWorkout: boolean = false;

    workoutForm: FormGroup;
    minDate = moment(new Date()).add(-2).format('YYYY-MM-DD');

    @ViewChild('ExerciseTablePaginator', { static: true }) paginator: MatPaginator;
    @ViewChild('AvailablePaginator', { static: true }) availablePaginator: MatPaginator;

    constructor(
        public dialogRef: MatDialogRef<WorkoutmodalComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any) {

    }

    cancel(): void {
        this.dataSource = [];
        this.availableData = [];
        this.dialogRef.close();
    }

    ngOnInit() {

        this.createColumnHeaders();

        if (this.data.stuff) {
            this.workout = this.data.stuff as Workout495.Models.Workout;
            if (this.workout.active == null)
                this.newWorkout = true;
        }

        if (this.data.available)
            this.available = this.data.available as Workout495.Models.Exercise[];


        this.workoutForm = new FormGroup({
            name: new FormControl('', [Validators.required, Validators.maxLength(60)]),
            workoutDatePicker: new FormControl(this.workout.scheduledDate, [Validators.required, Validators.min(moment(new Date()).millisecond())])
        });

        this.workoutForm.controls['name'].setValue(this.workout.name);
        this.workoutForm.controls['workoutDatePicker'].setValue(this.workout.scheduledDate);
        console.log(this.workoutForm);

        this.populateExercises();

        this.originalDataCopy();
        this.originalName = this.data.stuff.name;

    }

    public hasError = (controlName: string, errorName: string) => {
        return this.workoutForm.controls[controlName].hasError(errorName);
    }
    createColumnHeaders(): void {
        this.columnHeaders = ['name', 'completedreps', 'reps', 'sets', 'weight', 'remove'];
        this.availableColumnHeaders = ['name', 'completedreps', 'reps', 'sets', 'weight', 'add'];
    }

    async populateExercises() {

        this.dataSource = new MatTableDataSource(this.workout.exercises);
        this.dataSource.paginator = this.paginator;

        this.availableData = new MatTableDataSource(this.available);
        this.availableData.paginator = this.availablePaginator;
    }

    async originalDataCopy() {
        this.originalData = await this.extractExercises();
    }

    async extractExercises() {

        let data = [];

        if (this.workout.exercises) {

            this.workout.exercises.forEach(e => {
                let exercise = {
                    id: e.id,
                    name: e.name,
                    numberOfCompletions: e.numberOfCompletions,
                    reps: e.reps,
                    sets: e.sets,
                    weight: e.weight,
                    userId: e.userId

                }

                data.push(exercise);
            });
        }        

        return data;
    }

    cancelEdits(): void {
        this.data.stuff.name = this.originalName;
        this.data.stuff.exercises = this.originalData;
        this.dialogRef.close();
    }

    //Finds and moves an exercise from source array to dest array by name
    findAndMove(name: string, source: Workout495.Models.Exercise[], dest: Workout495.Models.Exercise[]) {

        if (source) {

            let movedExercise: Workout495.Models.Exercise;

            for (let i = 0; i < source.length; i++) {
                if (source[i].name == name) {

                    movedExercise = {
                        id: source[i].id,
                        name: source[i].name,
                        sets: source[i].sets,
                        reps: source[i].reps,
                        weight: source[i].weight,
                        numberOfCompletions: source[i].numberOfCompletions,
                        workout: source[i].workout,
                        userId: source[i].userId


                    }
                    let editedExercises: Workout495.Models.Exercise[] = source.splice(i, 1);
                }
            }

            dest.push(movedExercise);

        }

    }

    addExercise(addedExerciseName: string): void {

        if (addedExerciseName) {
            if (!this.workout.exercises) {
                this.workout.exercises = [];
            }
            this.findAndMove(addedExerciseName, this.data.available, this.workout.exercises);
            this.populateExercises();

        }

    }

    removeExercise(removedExerciseName: string): void {

        this.findAndMove(removedExerciseName, this.workout.exercises, this.data.available);
        this.populateExercises();

    }

    saveEdits(name: string, date: Date): void {

        this.workout.name = name;
        this.workout.scheduledDate = date;

        if (!this.workout.id)
            this.workout.id = 0;

        this.workout.active = true;

        this.data.stuff = this.workout;

        this.dialogRef.close(this.data.stuff);

    }
}
