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
  GetPetById(id: number){
    return this.httpClient.get(this.baseUrl + id);
  }

  //AddPet POST Pet
  AddPet(pet: any){
    var data: {};
    console.log(pet);
    return this.httpClient.post(this.baseUrl, pet);
  }
  //EditPet PUT Pet, PetID
  UpdatePet(petId: number, pet: any){
    return this.httpClient.put(this.baseUrl + petId, pet);
  }
  //DeletePet DELETE PetID
}
