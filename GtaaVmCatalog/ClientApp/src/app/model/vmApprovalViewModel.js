"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var vmproject_model_1 = require("../model/vmproject.model");
var vmapprovalrejection_model_1 = require("../model/vmapprovalrejection.model");
var VMApprovalViewModel = /** @class */ (function () {
    function VMApprovalViewModel() {
        this.tblVmproject = new vmproject_model_1.VMProject();
        this.tblVmapprovalRejection = new vmapprovalrejection_model_1.tblVmapprovalRejection();
    }
    return VMApprovalViewModel;
}());
exports.VMApprovalViewModel = VMApprovalViewModel;
//# sourceMappingURL=vmApprovalViewModel.js.map