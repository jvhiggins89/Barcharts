import { Component, OnInit } from '@angular/core';
import { ProgressPointsService } from '../../services/progresspoints.service';
import { faDumbbell, faPlus } from '@fortawesome/free-solid-svg-icons';
import { MatDialog } from '@angular/material';
import { ProgressPointsModalComponent } from '../modals/progresspointsmodal/progresspointsmodal.component';
import { PPViewModalComponenent } from '../modals/ppviewmodal/ppviewmodal.component';
import { MatSnackBar } from '@angular/material';
import * as moment from 'moment';

@Component({
  selector: 'app-progresspoint',
  templateUrl: './progresspoint.component.html',
  styleUrls: ['./progresspoint.component.css']
})
export class ProgressPointComponent implements OnInit {
  progressPoints: Workout495.Models.ProgressPoints[] = [];
  faDumbbell = faDumbbell;
  faPlus = faPlus;
  progressPoint: Workout495.Models.ProgressPoints;
  //columnHeaders: string[];
  columnHeadersProgressPoints: string[];
  //dataSource: any[];
  dataSourceProgressPoints: any[];
  objForEdit: any;

  constructor(private progressPointService: ProgressPointsService, public dialog: MatDialog, public snackBar: MatSnackBar) {
  }

  ngOnInit() {
    this.createHeaders();
    this.getAllData();
  }

  //material table load
  createHeaders() {
    this.columnHeadersProgressPoints = ['title', 'weight', 'bmi', 'progressPointDate','view', 'edit', 'delete'];
  }

  getAllData() {
    this.progressPointService.getProgressPoints()
      .subscribe(res => {
        this.progressPoints = res as Workout495.Models.ProgressPoints[];
        this.populatePPDataSet();
      });
  }


  async populatePPDataSet() {
    this.dataSourceProgressPoints = await this.getProgressPointData();
  }

  async getProgressPointData() {

    let data = [];
    await this.progressPoints.forEach(e => {
      let temp = {
        id: e.id,
        title: e.title,
        description: e.description,
        weight: e.weight,
        bmi: e.bmi,
        progressPointDate: e.progressPointDate

      }
      data.push(temp);
    });
    return data;
  };



  //methods for progress point modal
  openView(): void {
    let progresspoint = {} as Workout495.Models.ProgressPoints;
    if (this.objForEdit) {
      progresspoint = this.objForEdit;
    }

    const dialogRef = this.dialog.open(PPViewModalComponenent, {
      width: '50%',
      data: progresspoint
    });

    dialogRef.afterClosed();
    this.objForEdit = null;
  }

  openModalPP(): void {
    let progresspoint = {} as Workout495.Models.ProgressPoints;
    if (this.objForEdit) {
      progresspoint = this.objForEdit;
    }

    const dialogRef = this.dialog.open(ProgressPointsModalComponent, {
      width: '50%',
      data: progresspoint
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        //var r = result as Workout495.Models.ProgressPoints;
        this.progressPointService.saveProgressPoints(result as Workout495.Models.ProgressPoints).subscribe(result => {
          this.addItemPP(result);
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
    this.objForEdit = null;
  }


  async addItemPP(pp: Workout495.Models.ProgressPoints) {
    let temp = {
      id: pp.id,
      title: pp.title,
      description: pp.description,
      weight: pp.weight,
      bmi: pp.bmi,
      progressPointDate: pp.progressPointDate
    } as Workout495.Models.ProgressPoints;

    this.deletePP(pp);
    this.progressPoints.push(temp);
    await this.refreshTablePP();
  }

  async onClickDeletePP(data) {
    console.log(data);
    this.progressPointService.deletePP(data.id).subscribe(() => {
      this.deletePP(data);
      this.snackBar.open(
        "Progress Point deleted..was it to hard?",
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

  onClickEditPP(data): void {
    this.objForEdit = data;
    this.openModalPP();

  }

  onClickView(data): void {
    this.objForEdit = data;
    this.openView();
  }

  deletePP(data) {
    this.progressPoints = this.progressPoints.filter((e) => e.id != data.id);
    this.refreshTablePP();
  }

  async refreshTablePP() {
    this.dataSourceProgressPoints = await this.getProgressPointData();
  }
}
