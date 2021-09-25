import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TrikiGameComponent } from './triki-game/triki-game.component';

const routes: Routes = [
  {
    path: 'play',
    //component: LayoutComponent,
    children: [
      { path: '', component: TrikiGameComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TrikiRoutingModule {
  constructor(){
    alert("Routing");
  }

 }
