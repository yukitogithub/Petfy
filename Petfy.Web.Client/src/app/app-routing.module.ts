import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { CreatePetComponent } from './components/pets/create-pet/create-pet.component';
import { PetsComponent } from './components/pets/pets.component';
import { UpdatePetComponent } from './components/pets/update-pet/update-pet.component';
import { RegisterComponent } from './components/register/register.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: '', runGuardsAndResolvers: 'always', canActivate: [AuthGuard], children: [
    { path: '', component: HomeComponent },
    { path: 'pets', component: PetsComponent },
    { path: 'pets/add', component: CreatePetComponent },
    { path: 'pets/update', component: UpdatePetComponent },
  ]},
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
