import { Component, OnInit } from '@angular/core';
import { ExerciseService } from '../../services/exercise.service';
import { faDumbbell, faPlus } from '@fortawesome/free-solid-svg-icons';
import { MatDialog } from '@angular/material';
import { MatSnackBar } from '@angular/material';
import { ExercisemodalComponent } from '../modals/exercisemodal/exercisemodal.component';

@Component({
    selector: 'app-exercise',
    templateUrl: './exercise.component.html',
    styleUrls: ['./exercise.component.css']
})
export class ExerciseComponent implements OnInit {
    exercises: Workout495.Models.Exercise[] = [];
    faDumbbell = faDumbbell;
    faPlus = faPlus;
    exercise: Workout495.Models.Exercise;
    columnHeaders: string[];
    dataSource: any[];
    exerciseForEdit: any;

    constructor(private exerciseService: ExerciseService,
        public dialog: MatDialog,
        public snackBar: MatSnackBar) {
    }

    ngOnInit() {
        this.createHeaders();
        this.getExercises();
    }

    createHeaders() {
        this.columnHeaders = ['name', 'reps', 'sets', 'weight', 'workoutName', 'edit', 'delete'];
    }

    getExercises() {
        this.exerciseService.getExercises()
            .subscribe(res => {
                this.exercises = res as Workout495.Models.Exercise[];
                this.populateDataSet();
            });
    }

    async populateDataSet() {
        this.dataSource = await this.getData();
    }

    async getData() {
        let data = [];
        await this.exercises.forEach(e => {
            let temp = {
                id: e.id,
                name: e.name,
                numberOfCompletions: e.numberOfCompletions,
                reps: e.reps,
                sets: e.sets,
                weight: e.weight,
                userId: e.userId,
                workoutName: e.workout != null ? e.workout.name : "None"
            }
            data.push(temp);
        });
        return data;
    };

    openModal(): void {
        let exercise = {} as Workout495.Models.Exercise;
        if (this.exerciseForEdit) {
            exercise = this.exerciseForEdit;
        }

        const dialogRef = this.dialog.open(ExercisemodalComponent, {
            width: '50%',
            data:  exercise 
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result) {
                this.exerciseService.saveExercise(result as Workout495.Models.Exercise).subscribe(result => {
                    this.updateExerciseTable(result);
                    this.snackBar.open(
                        "Exercise Saved and now time to sweat!",
                        null,
                        {
                            duration: 3000,
                            panelClass: ['success-snackbar'],
                            verticalPosition: "top"
                        });
                }, (error) => {
                    console.log(error);
                    this.snackBar.open(
                        "Save Failed Try again",
                        null,
                        {
                            duration: 3000,
                            panelClass: ['error-snackbar'],
                            verticalPosition: "top"
                        });
                });
            }
        });
        this.exerciseForEdit = null;
    }

    async updateExerciseTable(exercise: Workout495.Models.Exercise) {
        let temp = {
            id: exercise.id,
            name: exercise.name,
            reps: exercise.reps,
            sets: exercise.sets,
            userId: exercise.userId,
            numberOfCompletions: 4,
            weight: exercise.weight,
            workout: null
        } as Workout495.Models.Exercise;
        this.deleteExercise(exercise);
        this.exercises.push(temp);
        await this.refreshTable();
    }

    async onClickDelete(data) {
        console.log(data);
        this.exerciseService.deleteExercise(data.id).subscribe(() => {
            this.deleteExercise(data);
            this.snackBar.open(
                "Exercise deleted..was it to hard?",
                null,
                {
                    duration: 3000,
                    panelClass: ['success-snackbar'],
                    verticalPosition: "top"
                });

        }, (error) => {
            this.snackBar.open(
                "Delete Failed Try again",
                null,
                {
                    duration: 3000,
                    panelClass: ['error-snackbar'],
                    verticalPosition: "top"
                });
        });
    }
    onClickEdit(data): void {
        this.exerciseForEdit = data;
        this.openModal();
    }

    deleteExercise(data) {
        this.exercises = this.exercises.filter((e) => e.id != data.id);
        this.refreshTable();
    }
    async refreshTable() {
        this.dataSource = await this.getData();
    }
}
