import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TrikiRoutingModule } from './triki-routing.module';
import { TrikiGameComponent } from './triki-game/triki-game.component';


@NgModule({
  declarations: [
    TrikiGameComponent
  ],
  imports: [
    CommonModule,
    TrikiRoutingModule
  ]
})
export class TrikiModule {
  constructor() {
    alert("Routing");
  }
}
