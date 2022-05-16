import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CidadeComponent } from './cidade/cidade.component';
import { PessoaComponent } from './pessoa/pessoa.component';
import { DataService } from './data.service';  

import { FormsModule, ReactiveFormsModule } from '@angular/forms';  

import { HttpClientModule, HttpClient } from '@angular/common/http';  
import {  MatButtonModule} from '@angular/material/button';  
import {  MatMenuModule} from '@angular/material/menu';  
import {  MatCardModule} from '@angular/material/card';  
import {  MatIconModule} from '@angular/material/icon';  
import {  MatFormFieldModule} from '@angular/material/form-field';  
import { MatInputModule} from '@angular/material/input';  
import { MatToolbarModule  } from '@angular/material/toolbar';  
import { MatTooltipModule} from '@angular/material/tooltip';  

import { MatRadioModule } from '@angular/material/radio';  
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';  

@NgModule({
  declarations: [
    AppComponent,
    CidadeComponent,
    PessoaComponent
  ],
  imports: [
    BrowserModule,  
    FormsModule,  
    ReactiveFormsModule,  
    HttpClientModule,  
    BrowserAnimationsModule,  
    MatButtonModule,  
    MatMenuModule,  
    MatIconModule,  
    MatRadioModule,  
    MatCardModule,  
    MatFormFieldModule,  
    MatInputModule,  
    MatTooltipModule,  
    MatToolbarModule
  ],
  providers: [HttpClientModule, DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }