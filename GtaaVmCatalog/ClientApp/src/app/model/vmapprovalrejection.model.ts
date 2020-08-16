export class tblVmapprovalRejection {
    constructor(
        public RequestId?: number,
        public ApprovalRejectionId?:number,
        public ApprovalLevel?: string,
        public ApprovedOrRejectedBy?: string,
        public ApprovedOrRejectedOn?: number,
        public Status?: string
    ) { }

}
