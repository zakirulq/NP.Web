import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http'
import { ToastyModule } from 'ng2-toasty';

import { AppComponent } from './app.component';
import { BankPaymentComponent } from './BankPayment/bankpayment.component'

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        ToastyModule.forRoot()
    ],
    declarations: [
        AppComponent,
        BankPaymentComponent
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }
