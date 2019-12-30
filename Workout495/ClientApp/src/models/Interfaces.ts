declare module Workout495.Models {
  export interface Exercise {
    id: number;
    name: string;
    sets: number;
    reps: number;
    numberOfCompletions: number;
    weight: number;
    userId: number;
    workout: Workout;
  }

  export interface Workout {
    id: number;
    name: string;
    userId: string;
    scheduledDate: Date;
    active: boolean;
    exercises: Exercise[];
  }

  export interface Goals {
    id: number;
    title: string;
    userId: number;
    description: string;
    goalDate: Date;
    changeDate: Date;
    created: Date;
    bmi: number;
    weight: number;
  }

  export interface ProgressPoints {
    id: number;
    title: string;
    description: string;
    progressPointDate: Date;
    changeDate: Date;
    created: Date;
    bmi: number;
    weight: number;
    goalID: number;
    userId: number;

  }
}
