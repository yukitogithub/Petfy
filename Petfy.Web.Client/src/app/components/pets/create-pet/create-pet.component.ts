import { Component, OnInit } from '@angular/core';
import { PetsService } from 'src/app/_services/pets.service';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-pet',
  templateUrl: './create-pet.component.html',
  styleUrls: ['./create-pet.component.css']
})
export class CreatePetComponent implements OnInit {

  createPetForm: FormGroup;

  constructor(
    private petsService: PetsService,
    private formBuilder: FormBuilder,
    private router: Router
    ) { }

  ngOnInit(): void {
    /*
    public string Name { get; set; }
        public int? PetNumber { get; set; }
        public string Description { get; set; }
        public string Breed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Type { get; set; }
        public int OwnerID { get; set; }
    */
    this.createPetForm = this.formBuilder.group({
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
    const pet = this.createPetForm.value;
    if(this.createPetForm.valid) {
      console.log(pet);
      this.petsService.AddPet(pet).subscribe({
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
