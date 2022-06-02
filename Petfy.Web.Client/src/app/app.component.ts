import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Petfy.Web.Client';
  text = 'Un texto';
  users: any;

  constructor(private httpClient: HttpClient) { }
  
  ngOnInit() {
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
