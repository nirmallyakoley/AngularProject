export class workflow {
    constructor(
        public requestId?: number,
        public approvalPDM?: string,
        public emailOfPDM?: string,
        public pdmApprovalRejectionDate?: number,
        public approvalTAP?: string,
        public emailOfTAP?: string,
        public tapApprovalRejectionDate?: number,
        public approvalDirector?: string,
        public emailOfDirector?: string,
        public directorApprovalRejectionDate?: number,) { }
}
