import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { PlantsComponent } from './plants.component';
import { PlantService } from './services/plant.service';
import { FormsModule } from '@angular/forms';
import { PlantComponent } from './plant/plant.component';


const routes: Routes = [
  { path: '', component: PlantsComponent }
];

@NgModule({
  declarations: [
    PlantsComponent,
    PlantComponent
  ],
  imports: [
    CommonModule,    
    FormsModule,
    RouterModule.forChild(routes)
  ]  
})
export class PlantsModule {

  constructor() {

  }
}
