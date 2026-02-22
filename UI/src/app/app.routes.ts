import { Routes } from '@angular/router';
import { LoginComponent } from './Components/login/login.component';
import { HomeComponent } from './Components/home/home.component';
import { AboutComponent } from './Components/about/about.component';
import { ContactUsComponent } from './Components/contact-us/contact-us.component';
import { CanActivateGuardService } from './Services/can-activate-guard.service';
import { LoginPageGuardService } from './Services/login-page-guard.service';

export const routes: Routes = [
    {path:'login', component:LoginComponent, canActivate:[LoginPageGuardService]},
    {path:'home', component:HomeComponent, canActivate:[CanActivateGuardService]},
    {path:'about', component:AboutComponent},
    {path:'contact-us', component:ContactUsComponent}
];
