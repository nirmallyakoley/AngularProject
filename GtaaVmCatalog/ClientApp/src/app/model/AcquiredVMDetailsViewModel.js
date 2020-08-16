"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var vmproject_model_1 = require("./vmproject.model");
var AcquiredVMSpecification_1 = require("./AcquiredVMSpecification");
var AcquiredVMDetailsViewModel = /** @class */ (function () {
    function AcquiredVMDetailsViewModel() {
        this.tblVmproject = new vmproject_model_1.VMProject();
        this.aquiredVmSpecification = new Array(new AcquiredVMSpecification_1.AcquiredVMSpecification());
    }
    return AcquiredVMDetailsViewModel;
}());
exports.AcquiredVMDetailsViewModel = AcquiredVMDetailsViewModel;
//# sourceMappingURL=AcquiredVMDetailsViewModel.js.map