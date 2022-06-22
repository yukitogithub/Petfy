import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PetsService {
  baseUrl = "https://localhost:7102/api/pets/";
  
  constructor() { }
}
