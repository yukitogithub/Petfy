import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  users: any;
  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(){
    this.httpClient.get('https://localhost:7102/api/users').subscribe({
      //next (paso exitoso)
      next: r => { this.users = r; console.log(this.users); },
      //nombre | (nombre) | () => { line1; line2 }
      //error (paso erroneo)
      error: error => console.log(error),
      //complete (paso sí o sí)
      complete: () => console.log("complete")
    });
  }
}
