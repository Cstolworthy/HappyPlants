import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, tap } from 'rxjs';
import { Plant } from '../../defs/plant';

@Injectable({
  providedIn: 'root'
})
export class PlantService {
  constructor(private http: HttpClient) {
    this._plants = [];
    this.plantSubject$ = new Subject<Plant[]>();
    this.Plants = this.plantSubject$;
  }
  private _plants: Plant[];
  private plantSubject$;
  Plants: Observable<Plant[]>;

  getPlants(): void {
    this.http.get<Plant[]>('/api/plant').subscribe((plants: Plant[]) => {
      this._plants.splice(0, this._plants.length);
      this._plants = plants;
      this.plantSubject$.next(this._plants);
    });
  }


  addPlant(): void {
    this._plants.push(new Plant());
    this.plantSubject$.next(this._plants);
  }

  savePlant(plant: Plant): void {
    this.http.put<Plant>("/api/plant/", plant)
      .subscribe((_) => { this.getPlants(); }, (err) => { });
  }
}
