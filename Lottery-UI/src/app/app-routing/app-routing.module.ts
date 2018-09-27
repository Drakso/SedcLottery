// Importing angular common modules, router module and the components that we are going to use to route to
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { WinnersListComponent } from '../winners-list/winners-list.component';
import { SubmitCodeComponent } from '../submit-code/submit-code.component';

// the router routes, /submit-code leads to the SubmitCodeComponent, /winners leads to WinnersListComponent and default page is WinnersListComponent
const routes: Routes = [
  { path: 'submit-code', component: SubmitCodeComponent },
  { path: 'winners', component: WinnersListComponent },
  { path: '', component: WinnersListComponent }
];

// Exporting the router module so it can be used in other components
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ],
  declarations: []
})
export class AppRoutingModule { }
