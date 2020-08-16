"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var vmproject_model_1 = require("./vmproject.model");
var vmrequistiondetail_model_1 = require("./vmrequistiondetail.model");
var VMRequestViewModel = /** @class */ (function () {
    function VMRequestViewModel() {
        this.TblVmproject = new vmproject_model_1.VMProject();
        this.TblVmRequisitionDetailsList = new Array(new vmrequistiondetail_model_1.VmRequisitionDetails(undefined, undefined, "VMEN0001", "VMOS0001", "VMCPU0001", "VMRAM0001", "VMSTOR0001", "VMMON001", undefined));
    }
    return VMRequestViewModel;
}());
exports.VMRequestViewModel = VMRequestViewModel;
//# sourceMappingURL=vmRequestViewModel.js.map