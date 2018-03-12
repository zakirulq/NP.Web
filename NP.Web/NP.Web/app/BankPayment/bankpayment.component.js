"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var bankpayment_service_1 = require("./bankpayment.service");
var ng2_toasty_1 = require("ng2-toasty");
var BankPaymentComponent = (function () {
    function BankPaymentComponent(bankPaymentService, toastyService, toastyConfig) {
        this.bankPaymentService = bankPaymentService;
        this.toastyService = toastyService;
        this.toastyConfig = toastyConfig;
        this.toastyConfig.theme = 'material';
    }
    BankPaymentComponent.prototype.ngOnInit = function () {
        this.resetForm();
    };
    BankPaymentComponent.prototype.resetForm = function (form) {
        if (form != null)
            form.reset();
        this.payment = {
            BSB: null,
            AcountNumber: null,
            AccountName: '',
            ReferenceNumber: '',
            Amount: null
        };
    };
    BankPaymentComponent.prototype.onSubmit = function (form) {
        var _this = this;
        this.bankPaymentService.processBankPayment(form.value)
            .subscribe(function (data) {
            _this.resetForm(form);
            console.log('payment processed!');
            _this.addToast('Payment processed succcessfully');
        });
    };
    BankPaymentComponent.prototype.addToast = function (message) {
        var toastOptions = {
            title: "Bank Payment",
            msg: message,
            showClose: true,
            timeout: 5000,
            theme: 'default'
        };
        this.toastyService.success(toastOptions);
    };
    return BankPaymentComponent;
}());
BankPaymentComponent = __decorate([
    core_1.Component({
        selector: 'bankpayment',
        templateUrl: './bankpayment.component.html',
        providers: [bankpayment_service_1.BankPaymentService]
    }),
    __metadata("design:paramtypes", [bankpayment_service_1.BankPaymentService, ng2_toasty_1.ToastyService, ng2_toasty_1.ToastyConfig])
], BankPaymentComponent);
exports.BankPaymentComponent = BankPaymentComponent;
//# sourceMappingURL=bankpayment.component.js.map