import { Component, OnInit } from '@angular/core';
import { GoalsService } from '../../services/goals.service';
import { faDumbbell, faPlus } from '@fortawesome/free-solid-svg-icons';
import { MatDialog } from '@angular/material';
import { GoalsmodalComponent } from '../modals/goalsmodal/goalsmodal.component';
import { GoalViewModalComponent } from '../modals/goalviewmodal/goalviewmodal.component';
import { MatSnackBar } from '@angular/material';
import * as moment from 'moment';

@Component({
  selector: 'app-goal',
  templateUrl: './goal.component.html',
  styleUrls: ['./goal.component.css']
})
export class GoalComponent implements OnInit {
  goals: Workout495.Models.Goals[] = [];
  faDumbbell = faDumbbell;
  faPlus = faPlus;
  goal: Workout495.Models.Goals;
  columnHeaders: string[];
  dataSource: any[];
  objForEdit: Workout495.Models.Goals;

  constructor(private goalsService: GoalsService,  public dialog: MatDialog, public snackBar: MatSnackBar) {
  }

  ngOnInit() {
    this.createHeaders();
    this.getAllData();
  }

  //material table load
  createHeaders() {
    this.columnHeaders = ['title',  'weight', 'bmi', 'goalDate','view', 'edit', 'delete'];
  }

  getAllData() {
    this.goalsService.getGoals()
      .subscribe(res => {
        this.goals = res as Workout495.Models.Goals[];
        this.populateDataSet();
      });
  }


  async populateDataSet() {
    this.dataSource = await this.getGoalData();
  }
   
  async getGoalData() {

    let data = [];
    await this.goals.forEach(e => {
      let temp = {
        id: e.id,
        title: e.title,
        description: e.description,
        weight: e.weight,
        bmi: e.bmi,
        goalDate: e.goalDate

      }
      data.push(temp);
    });
    return data;
  };

  

  //goal modal edits
openView(): void {
    let goal = {} as Workout495.Models.Goals;
    if (this.objForEdit) {
      goal = this.objForEdit;
    }

  const dialogRef = this.dialog.open(GoalViewModalComponent, {
      width: '50%',
      data: goal
    });

    dialogRef.afterClosed();
    this.objForEdit = null;
  }  

openModal(): void {
    let goal = {} as Workout495.Models.Goals;
    if (this.objForEdit) {
      goal = this.objForEdit;
    }
      const dialogRef = this.dialog.open(GoalsmodalComponent, {
        width: '50%',
        data: goal
      });

      dialogRef.afterClosed().subscribe(result => {
        if (result) {
          //var r = result as Workout495.Models.Goals;
          this.goalsService.saveGoals(result as Workout495.Models.Goals).subscribe(result => {
            this.addItem(result);
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
      this.objForEdit = null;
    }

  async addItem(goal: Workout495.Models.Goals) {
    let temp = {
      id: goal.id,
      title: goal.title,
      description: goal.description,
      weight: goal.weight,
      bmi: goal.bmi,
      goalDate: goal.goalDate
    } as Workout495.Models.Goals;

    this.deleteGoal(goal);
    this.goals.push(temp);
    await this.refreshTable();
  }

  async onClickDelete(data) {
    console.log(data);
    this.goalsService.deleteGoal(data.id).subscribe(() => {
      this.deleteGoal(data);
      this.snackBar.open(
        "Goal deleted..was it to hard?",
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
    this.objForEdit = data;
    this.openModal();

  }

  onClickView(data): void {
    this.objForEdit = data;
    this.openView();

  }

  deleteGoal(data) {
    this.goals = this.goals.filter((e) => e.id != data.id);
    this.refreshTable();
  }

  async refreshTable() {
    this.dataSource = await this.getGoalData();
  }

  
}
