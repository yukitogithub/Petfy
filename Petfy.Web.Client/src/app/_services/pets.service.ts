import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PetsService {
  baseUrl = environment.baseUrl + "pets/";
  
  constructor(private httpClient: HttpClient) { }

  //GetPets GET
  GetPets() {
    return this.httpClient.get(this.baseUrl);
  }
  
  //GetPetsByBreed GET Breed
  //GetPetsByBreedAndOwnerId GET Breed,OwnerID
  //GetPetsVaccine GET PetID
  //GetPetsByOwnerId GET OwnerID
  //GetPetById GET PetID

  //AddPet POST Pet
  //EditPet PUT Pet, PetID
  //DeletePet DELETE PetID
}
