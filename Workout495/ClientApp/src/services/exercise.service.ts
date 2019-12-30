import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';
import { throwError, Observable } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class ExerciseService {
    public response: Workout495.Models.Exercise[];
    myAppUrl: string;
    myApiUrl: string;
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json; charset=utf-8'
        })
    };
    constructor(private http: HttpClient) {
        this.myAppUrl = environment.appUrl;
        this.myApiUrl = 'api/Exercise';
    }
    private generateHeaders() {
        return {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }
    }

    private createCompleteRoute(route: string, envAddress: string) {
        return `${envAddress}/${route}`;
    }

    public getExercises() {
        return this.http.get(this.createCompleteRoute(this.myApiUrl, this.myAppUrl));
    }

    public saveExercise(exercise): Observable<Workout495.Models.Exercise> {
        return this.http.post<Workout495.Models.Exercise>(this.createCompleteRoute(this.myApiUrl, this.myAppUrl), JSON.stringify(exercise), this.generateHeaders())
            .pipe(retry(1), catchError(this.errorHandler));
    }

    public deleteExercise(id): Observable<boolean> {
        return this.http.delete<boolean>(`${this.myAppUrl}/${this.myApiUrl}/${id}`);
    }

    errorHandler(error) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            // Get client-side error
            errorMessage = error.error.message;
        } else {
            // Get server-side error
            errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        console.log(errorMessage);
        return throwError(errorMessage);
    }
}
