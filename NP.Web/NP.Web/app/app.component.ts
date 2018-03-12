import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  template: `<bankpayment></bankpayment><ng2-toasty [position]="top-left"></ng2-toasty>`,
})
export class AppComponent  { name = 'Angular'; }
