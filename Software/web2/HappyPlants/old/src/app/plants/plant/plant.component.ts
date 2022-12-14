import { Component, Input, OnInit } from '@angular/core';
import { Plant } from '../../defs/plant';
import { CRUDOperationsEnum } from '../../enums/CRUDOperationsEnum';
import { PlantService } from '../services/plant.service';


@Component({
  selector: 'plant',
  templateUrl: './plant.component.html',
  styleUrls: ['./plant.component.css']
})
export class PlantComponent implements OnInit {
  @Input() plantFriend: Plant | undefined;
  @Input() operation: CRUDOperationsEnum = CRUDOperationsEnum.View;
  viewButtonText: string | undefined;
  

  constructor(private svc: PlantService) {
    this.assignViewButtonText();
  }



  private assignViewButtonText() {

  }

  get operationType() {
    return CRUDOperationsEnum;
  }

  saveChanges(): void {
    if (this.plantFriend)
      this.svc.savePlant(this.plantFriend);
  }

  discardChanges(): void {

  }

  toggleEdit(): void {

  }

  ngOnInit(): void {
  }

}
