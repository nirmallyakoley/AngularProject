"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var workflow = /** @class */ (function () {
    function workflow(requestId, approvalPDM, emailOfPDM, pdmApprovalRejectionDate, approvalTAP, emailOfTAP, tapApprovalRejectionDate, approvalDirector, emailOfDirector, directorApprovalRejectionDate) {
        this.requestId = requestId;
        this.approvalPDM = approvalPDM;
        this.emailOfPDM = emailOfPDM;
        this.pdmApprovalRejectionDate = pdmApprovalRejectionDate;
        this.approvalTAP = approvalTAP;
        this.emailOfTAP = emailOfTAP;
        this.tapApprovalRejectionDate = tapApprovalRejectionDate;
        this.approvalDirector = approvalDirector;
        this.emailOfDirector = emailOfDirector;
        this.directorApprovalRejectionDate = directorApprovalRejectionDate;
    }
    return workflow;
}());
exports.workflow = workflow;
//# sourceMappingURL=workflow.model.js.map