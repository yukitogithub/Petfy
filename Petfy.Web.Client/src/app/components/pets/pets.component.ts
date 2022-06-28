import { Component, OnInit } from '@angular/core';
import { PetsService } from 'src/app/_services/pets.service';

@Component({
  selector: 'app-pets',
  templateUrl: './pets.component.html',
  styleUrls: ['./pets.component.css']
})
export class PetsComponent implements OnInit {

  pets: any;

  constructor(private petsService: PetsService) { }

  ngOnInit(): void {
    this.GetPets();
  }

  GetPets(){
    this.petsService.GetPets().subscribe({
      //next (paso exitoso)
      next: (pets) => { console.log(pets); this.pets = pets; console.log(this.pets) },
      //nombre | (nombre) | () => { line1; line2 }
      //error (paso erroneo)
      error: (error) => { console.log(error); },
      //complete (paso sí o sí)
      complete: () => console.log("complete")
    });
  }
}
