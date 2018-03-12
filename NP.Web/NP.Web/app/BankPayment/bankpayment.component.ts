import { Component, OnInit } from '@angular/core'
import { BankPaymentService } from './bankpayment.service'
import { NgForm } from '@angular/forms';
import { ToastyService, ToastyConfig, ToastOptions, ToastData } from 'ng2-toasty';

import { BankPayment } from './bankpayment.model'

@Component({
    selector: 'bankpayment',
    templateUrl: './bankpayment.component.html',
    providers: [BankPaymentService]
})
export class BankPaymentComponent implements OnInit {
    payment: BankPayment;

    constructor(private bankPaymentService: BankPaymentService, private toastyService: ToastyService, private toastyConfig: ToastyConfig) {
        this.toastyConfig.theme = 'material';
    }

    ngOnInit() {
        this.resetForm();
    }

    resetForm(form?: NgForm) {
        if (form != null)
            form.reset();
        this.payment = {
            BSB: null,
            AcountNumber: null,
            AccountName: '',
            ReferenceNumber: '',
            Amount: null
        }
    }

    onSubmit(form: NgForm) {
        console.log('Submitting the payment');
        this.bankPaymentService.processBankPayment(form.value)
            .subscribe(data => {
                this.resetForm(form);
                console.log('payment processed!')
                this.addToast('Payment processed succcessfully');
            })
    }

    addToast(message: string) {
        let toastOptions: ToastOptions = {
            title: "Bank Payment",
            msg: message,
            showClose: true,
            timeout: 5000,
            theme: 'default'
        };
        console.log('Preparing to show the toast!');
        this.toastyService.success(toastOptions);
        console.log('The toast was successful!');
	}
}