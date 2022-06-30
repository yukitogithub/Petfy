import { Component, OnInit } from '@angular/core';
import { PetsService } from 'src/app/_services/pets.service';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-pet',
  templateUrl: './update-pet.component.html',
  styleUrls: ['./update-pet.component.css']
})
export class UpdatePetComponent implements OnInit {

  updatePetForm: FormGroup;
  petId: number;

  constructor(
    private petsService: PetsService,
    private formBuilder: FormBuilder,
    private router: Router,
    private activateRouterService: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.activateRouterService.queryParams.subscribe(
      param => {
        this.petId = param.petId
      }
    );

    console.log(this.petId);

    this.petsService.GetPetById(this.petId).subscribe({
        //next (paso exitoso)
        next: pet => this.updatePetForm = this.formBuilder.group({
          ownerID: ['3', Validators.required],
          name: [pet['name'], Validators.required],
          petNumber: [pet['petNumber'], Validators.required],
          description: [pet['description'], Validators.required],
          breed: [pet['breed'], Validators.required],
          dateOfBirth: [pet['dateOfBirth'], Validators.required],
          type: [pet['type'], Validators.required],
        }),
        //nombre | (nombre) | () => { line1; line2 }
        //error (paso erroneo)
        error: error => console.log(error),
        //complete (paso sí o sí)
        complete: () => console.log("complete")
    });

    this.updatePetForm = this.formBuilder.group({
      ownerID: ['3', Validators.required],
      name: ['', Validators.required],
      petNumber: ['', Validators.required],
      description: ['', Validators.required],
      breed: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      type: ['', Validators.required],
    });
  }

  submit(){
    const pet = this.updatePetForm.value;
    if(this.updatePetForm.valid) {
      console.log(pet);
      this.petsService.UpdatePet(this.petId, pet).subscribe({
        //next (paso exitoso)
        next: pet => this.router.navigate(['/pets']),
        //nombre | (nombre) | () => { line1; line2 }
        //error (paso erroneo)
        error: error => console.log(error),
        //complete (paso sí o sí)
        complete: () => console.log("complete")
      });
    }

  }
}
