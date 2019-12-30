import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AngularSlickgridModule } from 'angular-slickgrid';
import { ChartsModule } from 'ng2-charts';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { ExerciseService } from 'src/services/exercise.service';
import { WorkoutService } from 'src/services/workout.service';
import { AppComponent } from './app.component';
import { ExerciseComponent } from './exercise/exercise.component';
import { ExercisemodalComponent } from './modals/exercisemodal/exercisemodal.component';
import { GoalComponent } from './goal/goal.component';
import { ProgressPointComponent } from './progresspoint/progresspoint.component';
import { HomeComponent } from './home/home.component';
import { MaterialModule } from './material.module';
import { MetricsComponent } from './metrics/metrics.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { WorkoutDetailsComponent } from './workout/workout-details/workout-details.component';
import { WorkoutComponent } from './workout/workout.component';
import { FullCalendarModule } from '@fullcalendar/angular';
import { CalendarCreateItemModalComponent } from './modals/calendarcreateitem-modal/calendarcreateitem-modal.component';
import { GoalsmodalComponent } from './modals/goalsmodal/goalsmodal.component';
import { GoalViewModalComponent } from './modals/goalviewmodal/goalviewmodal.component';
import { ProgressPointsModalComponent } from './modals/progresspointsmodal/progresspointsmodal.component';
import { PPViewModalComponenent } from './modals/ppviewmodal/ppviewmodal.component';
import { GoalsService } from '../services/goals.service';
import { ProgressPointsService } from '../services/progresspoints.service';
import { CalendareventModalComponent } from './modals/calendarevent-modal/calendarevent-modal.component';
import { CalendarComponent } from './calendar/calendar.component';
import { WorkoutmodalComponent } from './modals/workoutmodal/workoutmodal.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    WorkoutComponent,
    GoalComponent,
    ProgressPointComponent,
    MetricsComponent,
    ExerciseComponent,
    WorkoutDetailsComponent,
    ExercisemodalComponent,
    GoalsmodalComponent,
    ProgressPointsModalComponent,
    PPViewModalComponenent,
    GoalViewModalComponent,
    CalendarCreateItemModalComponent,
    CalendareventModalComponent,
    CalendarComponent,
    WorkoutmodalComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        MaterialModule,
        ChartsModule,
        ApiAuthorizationModule,
        FontAwesomeModule,
        BrowserAnimationsModule,
        FullCalendarModule,
        AngularSlickgridModule.forRoot(),
        RouterModule.forRoot([
          { path: '', component: HomeComponent, pathMatch: 'full' },
          { path: 'calendar', component: CalendarComponent, canActivate: [AuthorizeGuard] },
            { path: 'workout', component: WorkoutComponent, canActivate: [AuthorizeGuard] },
            { path: 'workout/detail/:id', component: WorkoutDetailsComponent, canActivate: [AuthorizeGuard] },
            { path: 'workout/detail/new', component: WorkoutDetailsComponent, canActivate: [AuthorizeGuard] },
          { path: 'goal', component: GoalComponent, canActivate: [AuthorizeGuard] },
          { path: 'progresspoint', component: ProgressPointComponent, canActivate: [AuthorizeGuard] },
            { path: 'metrics', component: MetricsComponent, canActivate: [AuthorizeGuard] },
            { path: 'exercise', component: ExerciseComponent, canActivate: [AuthorizeGuard] }
        ])
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
        { provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: { hasBackdrop: true } },
        WorkoutService,
        ExerciseService,
        GoalsService,
    ProgressPointsService
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    ExercisemodalComponent,
    GoalsmodalComponent,
    PPViewModalComponenent,
    ProgressPointsModalComponent,
    CalendarCreateItemModalComponent,
    CalendareventModalComponent,
    WorkoutmodalComponent,
    GoalViewModalComponent
  ],

})
export class AppModule { }
