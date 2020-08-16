export class VmRequisitionDetails {   
    constructor(
        public requestId?: number,
        public vmrequisitionId?: number,
        public vmenvironmentTypeId?: string,
        public vmostypeId?: string,
        public vmcpuid?: string,
        public vmramid?: string,
        public vmstorid?: string,
        public vmmonitoringId?:string,
        public loggedTime?: number
    ) { }
    }
