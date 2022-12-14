import { AfterViewInit, Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Plant } from '../defs/plant';
import { Observable } from 'rxjs';
import { PlantService } from './services/plant.service';
import { CRUDOperationsEnum } from '../enums/CRUDOperationsEnum';

@Component({
  selector: 'app-plants',
  templateUrl: './plants.component.html',
  styleUrls: ['./plants.component.css']
})
export class PlantsComponent implements OnInit, AfterViewInit {

  constructor(private plantService: PlantService) {

  }

  ngAfterViewInit(): void {
    this.plantService.getPlants();
  }

  plants: Observable<Plant[]> | undefined;
  showAddNewPlant: Boolean | undefined;
  addNewPlant(): void {
    this.plantService.addPlant();
  }
  get operationType() {
    return CRUDOperationsEnum;
  }
  ngOnInit(): void {
    this.plants = this.plantService.Plants;
  }
}
