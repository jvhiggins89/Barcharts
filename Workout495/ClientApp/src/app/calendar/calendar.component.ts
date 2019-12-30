import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction';
import { MatDialog, MatSnackBar } from '@angular/material';
import { CalendarCreateItemModalComponent } from '../modals/calendarcreateitem-modal/calendarcreateitem-modal.component';
import { Router } from '@angular/router';
import { FullCalendarComponent } from '@fullcalendar/angular';
import { CalendareventModalComponent } from '../modals/calendarevent-modal/calendarevent-modal.component';
import { WorkoutService } from '../../services/workout.service';
import { GoalsService } from '../../services/goals.service';
import { ProgressPointsService } from '../../services/progresspoints.service';
import * as moment from 'moment';
import { GoalsmodalComponent } from '../modals/goalsmodal/goalsmodal.component';
import { ProgressPointsModalComponent } from '../modals/progresspointsmodal/progresspointsmodal.component';
import { Enums } from '../../models/Enums';
import { WorkoutmodalComponent } from '../modals/workoutmodal/workoutmodal.component';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent implements OnInit {
  calendarPlugins = [dayGridPlugin, interactionPlugin];
  calendarEvents: any[] = [{}];
  dialogRef: any;
  workouts: Workout495.Models.Workout[] = [];
  goals: Workout495.Models.Goals[] = [];
  progressPoints: Workout495.Models.ProgressPoints[] = [];
  calendarOptions = <any>[];
  itemType: Enums.CalendarItem;

  @ViewChild('calendar', null) calendarComponent: FullCalendarComponent;

  constructor(public dialog: MatDialog,
    private router: Router,
    private workoutService: WorkoutService,
    private goalsService: GoalsService,
    private progressPointsService: ProgressPointsService,
    public snackBar: MatSnackBar) { }

  ngOnInit() {
    this.getWorkouts();
    this.getGoals();
    this.getProgressPoints();

  }

  handleDateClick(arg): void {
    const dialogRef = this.dialog.open(CalendarCreateItemModalComponent, {
      data: { date: arg.dateStr }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
      if (result) {
        if (result.itemType == Enums.CalendarItem.workout) { this.createWorkoutModal(result); }
        if (result.itemType == Enums.CalendarItem.goal) { this.createGoalModal(result); }
        if (result.itemType == Enums.CalendarItem.progressPoint) { this.createProgressPointModal(result); }
      }

    });
  }

  createWorkoutModal(arg): void {
    let workout: Workout495.Models.Workout = {
      id: null,
      name: null,
      userId: null,
      scheduledDate: arg.date,
      active: null,
      exercises: []
    }
    this.workoutService.getAvailableExercises("api/Workout")
      .subscribe(exercises => {

        let availableExercises = exercises as Workout495.Models.Exercise[];

        let available = [] as Workout495.Models.Exercise[];
        available = availableExercises;

        const dialogRef = this.dialog.open(WorkoutmodalComponent, {
          width: '70%',
          data: { stuff: workout, available: available }
        });

        dialogRef.afterClosed().subscribe(result => {
          if (result) {

            //Save workout to db
            this.workoutService.saveWorkout(result as Workout495.Models.Workout).subscribe(result => {
              let temp = {
                id: result.id,
                title: result.name,
                userId: result.userId,
                date: moment(result.scheduledDate).format("YYYY-MM-DD"),
                description: 'none',
                isActive: result.active,
                exercises: <any>[],
                color: '#2C3E50',
                textColor: '#acdf87',
                eventType: Enums.CalendarItem.workout
              }
        
              let tempArray = this.calendarEvents.concat(temp);
              this.calendarEvents = tempArray;
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


  }

  createGoalModal(arg): void {
    let goal = {} as Workout495.Models.Goals;
    goal.goalDate = arg.date;
    const dialogRef = this.dialog.open(GoalsmodalComponent, {
      width: '50%',
      data: goal
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.goalsService.saveGoals(result as Workout495.Models.Goals).subscribe(result => {
          let temp = {
            id: result.id,
            title: result.title,
            userId: result.userId,
            date: moment(result.goalDate).format("YYYY-MM-DD"),
            description: result.description,
            bmi: result.bmi,
            weight: result.weight,
            color: '#503e2c',
            textColor: '#f5f5f5'
          };
          let tempArray = this.calendarEvents.concat(temp);
          this.calendarEvents = tempArray;
          this.snackBar.open(
            "goal Saved and now time to sweat!",
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
  }

  createProgressPointModal(arg): void {
    let progresspoint = {} as Workout495.Models.ProgressPoints;
    progresspoint.progressPointDate = arg.date;

    const dialogRef = this.dialog.open(ProgressPointsModalComponent, {
      width: '50%',
      data: { progresspoint: progresspoint }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.progressPointsService.saveProgressPoints(result.progresspoint as Workout495.Models.ProgressPoints).subscribe(result => {
          let temp = {
            id: result.id,
            title: result.title,
            userId: result.userId,
            date: moment(result.progressPointDate).format("YYYY-MM-DD"),
            description: result.description,
            bmi: result.bmi,
            weight: result.weight,
            color: '#597ea2',
            textColor: '#f5f5f5',
            icon: 'fa-clock-o'
          };
          let tempArray = this.calendarEvents.concat(temp);
          this.calendarEvents = tempArray;
          this.snackBar.open(
            "Progress Point Saved and now time to sweat!",
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
  }

  private getWorkouts() {
    this.workoutService.getUserWorkouts()
      .subscribe(res => {
        this.workouts = res as Workout495.Models.Workout[];
        this.populateWorkouts();
      });
  }

  private getGoals() {
    this.goalsService.getGoals()
      .subscribe(res => {
        this.goals = res as Workout495.Models.Goals[];
        this.populateGoals();

      });
  }

  private getProgressPoints() {
    this.progressPointsService.getProgressPoints()
      .subscribe(res => {
        this.progressPoints = res as Workout495.Models.ProgressPoints[];
        this.populateProgressPoints();
      });
  }

  private populateWorkouts() {
    let tempArray = <any>[];
    this.workouts.forEach(w => {
      let temp = {
        id: w.id,
        title: w.name,
        userId: w.userId,
        date: moment(w.scheduledDate).format("YYYY-MM-DD"),
        description: 'none',
        isActive: w.active,
        exercises: <any>[],
        color: '#2C3E50',
        textColor: '#acdf87',
        eventType: Enums.CalendarItem.workout
      }
      tempArray.push(temp);

    });
    this.calendarEvents = this.calendarEvents.concat(tempArray);
  }

  private populateGoals() {
    let tempArray = <any>[];
    this.goals.forEach(g => {
      let temp = {
        id: g.id,
        title: g.title,
        userId: g.userId,
        date: moment(g.goalDate).format("YYYY-MM-DD"),
        description: g.description,
        bmi: g.bmi,
        weight: g.weight,
        color: '#503e2c',
        textColor: '#f5f5f5',
        eventType: Enums.CalendarItem.goal
      }
      tempArray.push(temp);

    });
    this.calendarEvents = this.calendarEvents.concat(tempArray);
  }

  private populateProgressPoints() {
    let tempArray = <any>[];
    this.progressPoints.forEach(p => {
      let temp = {
        id: p.id,
        title: p.title,
        userId: p.userId,
        date: moment(p.progressPointDate).format("YYYY-MM-DD"),
        description: p.description,
        bmi: p.bmi,
        weight: p.weight,
        color: '#597ea2',
        textColor: '#f5f5f5',
        icon: 'fa-clock-o',
        eventType: Enums.CalendarItem.progressPoint
      }
      tempArray.push(temp);
      console.log(temp);
    });
    this.calendarEvents = this.calendarEvents.concat(tempArray);
  }

  createToolTip(element): void {
    console.log(this.calendarEvents);
    let pointer = element.el.getBoundingClientRect();
    this.dialogRef = this.dialog.open(CalendareventModalComponent, {
      data: {
        event: element.event,
        title: element.event.title,
        date: element.event.start,
        eventType: element.event.extendedProps.eventType
      },
      hasBackdrop: false,
      position: {
        top: (pointer.top - 275).toString() + 'px',
        left: (pointer.left + 30).toString() + 'px'
      }
    });
  }

  destroyToolTip(info) {
    this.dialogRef.close();
  }


}
