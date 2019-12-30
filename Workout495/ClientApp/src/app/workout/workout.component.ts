import { Component, OnInit, ViewChild } from '@angular/core';
import { WorkoutService } from '../../services/workout.service';
import { faDumbbell, faPlus } from '@fortawesome/free-solid-svg-icons';
import { MatDialog } from '@angular/material';
import { MatSnackBar } from '@angular/material';
import { WorkoutmodalComponent } from '../modals/workoutmodal/workoutmodal.component';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material';


@Component({
  selector: 'app-workout',
  templateUrl: './workout.component.html',
  styleUrls: ['./workout.component.css']
})
export class WorkoutComponent implements OnInit {

    faDumbbell = faDumbbell;
    faPlus = faPlus;

    workouts: Workout495.Models.Workout[];

    dataSource: any; 
    columnHeaders: string[];

    toDeleteWorkout: Workout495.Models.Workout = { id: null, name: "", active: false, scheduledDate: null, exercises: null, userId: null };

    toEditWorkout: any;
    availableExercises: Workout495.Models.Exercise[];

    @ViewChild(MatPaginator, { static : true}) paginator: MatPaginator;

    constructor(
        private workoutService: WorkoutService,
        public dialog: MatDialog,
        public snackBar: MatSnackBar) { }

    ngOnInit() {
        this.workouts = [];
        this.availableExercises = [];
//        this.dataSource = [];
        this.createColumnHeaders();
        this.getWorkouts();
    }

    createColumnHeaders(): void {
        this.columnHeaders = ['name', 'date', 'edit', 'delete'];
    } 

    createWorkout(): void {
        this.openModal();
    }

    openModal(): void {

        let workout: Workout495.Models.Workout = {
            id: null,
            name: null,
            userId: null,
            scheduledDate: null,
            active: null,
            exercises: []
        }

        if (this.toEditWorkout) {
            workout = this.toEditWorkout;
        }

        //Get available exercises
        this.workoutService.getAvailableExercises("api/Workout")
            .subscribe(exercises => {

                this.availableExercises = exercises as Workout495.Models.Exercise[];

                let available = [] as Workout495.Models.Exercise[];
                available = this.availableExercises;

                const dialogRef = this.dialog.open(WorkoutmodalComponent, {
                    width: '70%',
                    data: { stuff: workout, available: available }
                });

                dialogRef.afterClosed().subscribe(result => {
                    if (result) {

                        //Save workout to db
                        this.workoutService.saveWorkout(result as Workout495.Models.Workout).subscribe(result => {

                            //UPDATE WORKOUTS TABLE AND REFRESH
                            this.addItem(result);

                            this.snackBar.open(
                                "Workout Saved and now time to sweat!",
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

            });

        this.toEditWorkout = {};
    }

    async addItem(workout: Workout495.Models.Workout) {
        let temp = {
            id: workout.id,
            name: workout.name,
            active: workout.active,
            scheduledDate: workout.scheduledDate,
            userId: workout.userId,
            exercises: workout.exercises
        } as Workout495.Models.Workout;
        this.removeWorkout(workout);
        this.workouts.push(temp);
        this.populateTable();
    }

    removeWorkout(workout: Workout495.Models.Workout) {
        this.workouts = this.workouts.filter((e) => e.id != workout.id);
        this.populateTable();
    }


    //method to get all of the users workouts from server
    getWorkouts(): void {

        this.workoutService.getUserWorkouts()
            .subscribe(workouts => {
                this.workouts = workouts as Workout495.Models.Workout[];
                this.populateTable();
                
            })

    }

    async populateTable() {
 //       this.dataSource = await this.extractData();
        this.dataSource = new MatTableDataSource(this.workouts);
        this.dataSource.paginator = this.paginator;

    }

    editWorkout(data): void {
        this.toEditWorkout = data;
        this.openModal();
    }

    deleteWorkout(workout: Workout495.Models.Workout): void {

        workout.exercises = [];
        workout.active = false;

        this.workoutService.saveWorkout(workout)
            .subscribe();

        //remove workout from workouts
        for (let i = 0; i < this.workouts.length; i++) {
            if (this.workouts[i].id == workout.id) {
                this.workouts.splice(i, 1);
                break;
            }
        }

        //refresh table
        this.populateTable()

    }
}
