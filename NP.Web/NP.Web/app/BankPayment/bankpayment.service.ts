import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

import { BankPayment } from './bankpayment.model'

@Injectable()
export class BankPaymentService {

	constructor(private http: Http) { }

	processBankPayment(payment: BankPayment) {
		var body = JSON.stringify(payment);
		var headerOptions = new Headers({ 'Content-Type': 'application/json' });
		var requestOptions = new RequestOptions({ method: RequestMethod.Post, headers: headerOptions });
		console.log('Submitting the http request!');
		return this.http.post('http://localhost:53844/api/BankPayment', body, requestOptions).map(x => x.json());
	}
}