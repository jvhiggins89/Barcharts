import { Component, OnInit, ViewChild } from '@angular/core';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, BaseChartDirective } from 'ng2-charts';
import * as pluginAnnotations from 'chartjs-plugin-annotation';
import * as moment from 'moment';
import { GoalsService } from '../../services/goals.service';
import { ProgressPointsService } from '../../services/progresspoints.service';

@Component({
  selector: 'app-metrics',
  templateUrl: './metrics.component.html',
  styleUrls: ['./metrics.component.css']
})
export class MetricsComponent implements OnInit {
    goals: Workout495.Models.Goals[] = [];
    progressPoints: Workout495.Models.ProgressPoints[] = [];
    goal: Workout495.Models.Goals;
    progressPoint: Workout495.Models.ProgressPoints;

    public lineChartData: ChartDataSets[] = [{}];
    public lineChartOptions: (ChartOptions & { annotation: any }) = {
        responsive: true,
        scales: {
            // We use this empty structure as a placeholder for dynamic theming.
            xAxes: [
                {
                    type: 'time',
                    time: {
                        unit: 'week'
                    },
                    distribution: 'series'
                }
            ],
            yAxes: [
                {
                    id: 'y-axis-0',
                    position: 'left',
                    gridLines: {
                        color: 'rgba(172, 223, 135,0.6)',
                    },
                    ticks: {
                        fontColor: 'green',
                        beginAtZero: true
                    }
                },
            ]
        },
       annotation: {
           /* annotations: [
                {
                    type: 'line',
                    mode: 'vertical',
                    scaleID: 'x-axis-0',
                    value: 'March',
                    borderColor: 'orange',
                    borderWidth: 2,
                    label: {
                        enabled: true,
                        fontColor: 'orange',
                        content: 'LineAnno'
                    }
                },
            ],*/
        },
    };
    public lineChartColors: Color[] = [{}];
    public lineChartLegend = true;
    public lineChartType = 'line';
    public lineChartPlugins = [pluginAnnotations];

    @ViewChild(BaseChartDirective, { static: true }) chart: BaseChartDirective;

    constructor(private goalsService: GoalsService, private progressPointService: ProgressPointsService) {
        this.getLineChartColors();
        this.getLineChartData();
    }

    ngOnInit() {
        this.getProgressReports();    
    }

    public getProgressReports() {
        this.progressPointService.getProgressPoints()
            .subscribe(res => {
                this.progressPoints = res as Workout495.Models.ProgressPoints[];
                this.addDataProgressPoints();
                this.getGoals();
            });
    }

    public getGoals() {
        this.goalsService.getGoals()
            .subscribe(res => {
                this.goals = res as Workout495.Models.Goals[];
                this.addDataGoals();
            });

    }

    public addDataGoals() {
        this.lineChartData.shift();//poor mans fix;
        this.goals.forEach(e => {
            let temp = {
                x: e.goalDate,
                y: e.weight
            }
            this.lineChartData.push({
                label: e.title,
                data: [temp]
            });
            this.lineChartColors.push({
                backgroundColor: this.getRandomColors(),
            });
        });
        this.updateTimeframeHelper();
        this.chart.chart.update();
    }

    public addDataProgressPoints() {
        let temp = [];
        temp.pop();
        this.progressPoints.forEach(e => {
            temp.push({ x: e.progressPointDate, y: e.weight });
        });
        console.log(temp);
        this.lineChartData.push({
            label: 'Progress Points',
            data: temp
        });
        this.lineChartColors[0] = ({
            backgroundColor: 'rgba(172, 223, 135,0.3)',
            borderColor: 'green',
            pointBackgroundColor: 'rgba(148,159,177,1)',
            pointBorderColor: '#999',
            pointHoverBackgroundColor: '#fff',
            pointHoverBorderColor: 'rgba(148,159,177,0.8)'
        });
        this.updateTimeframeHelper();
        this.chart.chart.update();
    }

    public randomize(): void {
        for (let i = 0; i < this.lineChartData.length; i++) {
            for (let j = 0; j < this.lineChartData[i].data.length; j++) {
                this.lineChartData[i].data[j] = this.generateNumber(i);
            }
        }
        this.chart.update();
    }

    private generateNumber(i: number) {
        return Math.floor((Math.random() * (i < 2 ? 100 : 1000)) + 1);
    }

    private getLineChartColors(): Color[] {
      return  [];
    }

    private getLineChartData(): ChartDataSets[] {
        return [
        ]
    }

    private getRandomColors() {
            var r = Math.floor(Math.random() * 255);
            var g = Math.floor(Math.random() * 255);
            var b = Math.floor(Math.random() * 255);
            return "rgb(" + r + "," + g + "," + b + ")";
    }

    // events
    public chartClicked({ event, active }: { event: MouseEvent, active: {}[] }): void {
        console.log(event, active);
    }

    public chartHovered({ event, active }: { event: MouseEvent, active: {}[] }): void {
        console.log(event, active);
    }

    public changeTimeframeDaily() {
        this.lineChartOptions.scales.xAxes = [{
            type: 'time',
            time: {
                unit: 'day'
            },
            distribution: 'linear',
        }];
        this.updateTimeframeHelper();
    }

    public changeTimeframeThreeMonth() {
        let now = moment().format('yyyy mm dd');
        let past = moment().subtract(3, 'months').format('yyyy mm dd');
        this.lineChartOptions.scales.xAxes = [{
            type: 'time',
            time: {
                unit: 'month'
            },
            distribution: 'linear',
            ticks: { min: past, max: now, }
        }];
        this.updateTimeframeHelper();
    }

    public changeTimeframeSixMonth() {
        let now = moment().format('yyyy mm dd');
        let past = moment().subtract(6, 'months').format('yyyy mm dd');
        this.lineChartOptions.scales.xAxes = [{
            type: 'time',
            time: {
                unit: 'month'
            },
            distribution: 'linear',
            ticks: { min: past, max: now }
        }];
        this.updateTimeframeHelper();
    }

    public changeTimeframeWeekly() {
        this.lineChartOptions.scales.xAxes = [{
            type: 'time',
            time: {
                unit: 'week'
            },
            distribution: 'linear'
        }];
        this.updateTimeframeHelper();
    }

    public changeTimeframeYearly() {
        this.lineChartOptions.scales.xAxes = [{
            type: 'time',
            time: {
                unit: 'year'
            },
            distribution: 'series'
        }];
        this.updateTimeframeHelper();
    }

    public changeTimeframeMonthly() {
        this.lineChartOptions.scales.xAxes = [{
            type: 'time',
            time: {
                unit: 'month'
            },
            distribution: 'linear'
        }];
        this.updateTimeframeHelper();
    }

    public updateTimeframeHelper() {
        this.chart.chart.options = this.lineChartOptions;
        this.chart.chart.update();
    }

    public changeMetrics() {

    }


    //public addDtatProgressPoints(progressPoints: Workout495.Models.ProgressPoints)
}
