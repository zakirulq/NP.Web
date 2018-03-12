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
var http_1 = require("@angular/http");
require("rxjs/add/operator/map");
require("rxjs/add/operator/toPromise");
var BankPaymentService = (function () {
    function BankPaymentService(http) {
        this.http = http;
    }
    BankPaymentService.prototype.processBankPayment = function (payment) {
        var body = JSON.stringify(payment);
        var headerOptions = new http_1.Headers({ 'Content-Type': 'application/json' });
        var requestOptions = new http_1.RequestOptions({ method: http_1.RequestMethod.Post, headers: headerOptions });
        return this.http.post('http://localhost:53844/api/BankPayment', body, requestOptions).map(function (x) { return x.json(); });
    };
    return BankPaymentService;
}());
BankPaymentService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], BankPaymentService);
exports.BankPaymentService = BankPaymentService;
//# sourceMappingURL=bankpayment.service.js.map