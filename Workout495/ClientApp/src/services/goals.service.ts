import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';
import { throwError, Observable } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class GoalsService {
    public response: Workout495.Models.Goals[];
    myAppUrl: string;
    myApiUrl: string;
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json; charset=utf-8'
        })
    };
    constructor(private http: HttpClient) {
        this.myAppUrl = environment.appUrl;
        this.myApiUrl = 'api/Goals';
    }
    private generateHeaders() {
        return {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }
    }

    private createCompleteRoute(route: string, envAddress: string) {
        return `${envAddress}/${route}`;
    }

    public getGoals() {
        return this.http.get(this.createCompleteRoute(this.myApiUrl, this.myAppUrl));
    }

    public saveGoals(goals): Observable<Workout495.Models.Goals> {
        return this.http.post<Workout495.Models.Goals>(this.createCompleteRoute(this.myApiUrl, this.myAppUrl), JSON.stringify(goals), this.generateHeaders())
            .pipe(retry(1), catchError(this.errorHandler));
    }

    public deleteGoal(id): Observable<boolean> {
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

