import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { WorkoutService } from '../../../services/workout.service';

@Component({
  selector: 'app-workout-details',
  templateUrl: './workout-details.component.html',
  styleUrls: ['./workout-details.component.css']
})
export class WorkoutDetailsComponent implements OnInit {

    exerciseAdded: boolean;
    workoutId: number;

    workout: Workout495.Models.Workout = {
        id: null,
        name: null,
        userId: null,
        scheduledDate: null,
        active: null,
        exercises: []
    }

    exercises: Workout495.Models.Exercise[] = [];

    dataSource: any[] = [];
    columnHeaders: string[];

    availableExercises: Workout495.Models.Exercise[] = [];


    constructor(private route: ActivatedRoute, private router: Router, private workoutService: WorkoutService) { }

    ngOnInit() {

        this.exerciseAdded = false;
        this.workoutId = +this.route.snapshot.paramMap.get('id');

        this.createColumnHeaders();
        //Display information on existing workout to be edited
        if (this.workoutId) {
            this.getWorkout();
            this.exerciseAdded = true;
            
        }

        //Get a list of available exercises from db
        this.getAvailableExercises();

    }

    createColumnHeaders(): void {
        this.columnHeaders = ['name', 'completedreps', 'reps', 'sets', 'weight', 'edit', 'remove'];
    }

    getWorkout(): void {

        this.workoutService.getUserWorkoutById("api/Workout", this.workoutId)
            .subscribe(workout => {
                this.workout = workout as Workout495.Models.Workout;
                this.populateExercises();
            })

    }

    async populateExercises() {
        this.dataSource = await this.extractExercises();
    }

    async extractExercises() {

        let data = [];

       this.workout.exercises.forEach( e => {
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

        return data;
    }

    getAvailableExercises(): void {
        this.workoutService.getAvailableExercises("api/Workout")
            .subscribe(exercises => {
                this.availableExercises = exercises as Workout495.Models.Exercise[];
            });

    }


    addExercise(addedExerciseName: string): void {

        this.findAndMove(addedExerciseName, this.availableExercises, this.workout.exercises);
        this.exerciseAdded = true;
        this.populateExercises();

    }

    //Finds and moves an exercise from source array to dest array by name
    findAndMove(name: string, source: Workout495.Models.Exercise[], dest: Workout495.Models.Exercise[]) {

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

    cancelEdits(): void {
        this.router.navigate(['/workout']);
    }

    saveEdits(name: string, date: Date): void {

        this.workout.name = name; 
        this.workout.scheduledDate = date;

        if (this.workoutId)
            this.workout.id = this.workoutId;
        else
            this.workout.id = 0;

        this.workout.active = true;

        console.log(this.workout);

        this.workoutService.saveWorkout(this.workout as Workout495.Models.Workout)
            .subscribe(re => {
                console.log(re);

            });

        this.router.navigate(['/workout']);

    }

    removeExercise(removedExerciseName: string): void {

        this.findAndMove(removedExerciseName, this.workout.exercises, this.availableExercises);

        if (this.workout.exercises.length > 0)
            this.populateExercises();
        else
            this.exerciseAdded = false;
        
    }

    toExerciseDetails(): void {
        this.router.navigate(['/exercise']);
    }

}
