import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudioRoutingModule } from './studio-routing.module';
import { MovieComponent } from './movie/movie.component';
import { HttpClientModule } from '@angular/common/http';
import { MovieService } from './movie/movie.service';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [MovieComponent],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    StudioRoutingModule
  ],
  providers: [MovieService]
})
export class StudioModule { }
