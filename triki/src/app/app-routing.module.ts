import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TrikiGameComponent } from './triki/triki-game/triki-game.component';

const routes: Routes = [
  {
    path: 'triki',
    component: TrikiGameComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
