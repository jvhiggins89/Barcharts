import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WorkoutService {

    private appUrl: string;
    private apiUrl: string;
    httpOptions = {
        headers: new HttpHeaders({ 'Content Type': 'application/json' })
    }

    constructor(private http: HttpClient) {

        this.appUrl = environment.appUrl;
        this.apiUrl = 'api/Workout';

    }

    public getUserWorkouts() {
        return this.http.get(this.createCompleteRoute(this.apiUrl, this.appUrl));
    }

    public getUserWorkoutById(route: string, id: number) {
        let url: string = this.createCompleteRoute(this.apiUrl, this.appUrl) + `/${id}`;
        return this.http.get(url);
    }

    public getAvailableExercises(route: string) {
        return this.http.get(this.createCompleteRoute(this.apiUrl, this.appUrl) + `/available`)
    }

    public saveWorkout(workout): Observable<Workout495.Models.Workout> {
        return this.http.post<Workout495.Models.Workout>(this.createCompleteRoute(this.apiUrl, this.appUrl), JSON.stringify(workout), this.generateHeaders());
    }

    private generateHeaders() {
        return {
            headers: new HttpHeaders({ 'Content-Type' : 'application/json' })
        }
    }

    private createCompleteRoute(route: string, envAddress: string) {
        return `${envAddress}/${route}`;
    }
}

