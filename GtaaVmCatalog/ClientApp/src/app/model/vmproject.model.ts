import { tblVmapprovalRejection } from './vmapprovalrejection.model'
import { tblVmdocument } from './vmdocument.model'
export class VMProject {
    constructor(
        public requestId?: number,
        public projectName?: string,
        public projectNumber?: string,
        public requesterName?: string,
        public architectName?: string,
        public pdmname?: string,
        public quoteIdnumber?: string,
        public changeOrderNumber?: string,
        public agreementNumber?: string,
        public releaseNumber?: string,
        public changeRequestNumber?: string,
        public briefDescription?: string,
        public requesterLoggedId?: string,
        public requesterUserId?: string,
        public loggedTime?: number,
        public approverL1?: boolean,
        public approverL2?: boolean,
        public approverL3?: boolean,
        public applicationCriticality?: string,
        public vmType?: string,
        public siem?: string,
        public growthFactor?: string,
        public otherCriteria?: string,        
        public ticketClosedOn?: number,
        public isDeleted?: boolean,
        public isTicketClosed?: boolean,
        public deletedOn?: number,
        public tapApprovalDoc?: string,
        public solutionDesignDoc?: string,
        public securityApprovalDoc?: string,
        public buildSheetDoc?: string,  
        public tapApprovalDocUrl?: string,  
        public solutionDesignDocUrl?: string,  
        public securityApprovalDocUrl?: string,  
        public buildSheetDocUrl?: string,  
        public tblVmapprovalRejection?: tblVmapprovalRejection[],
        public tblVmdocument?: tblVmdocument[]
    ) { }

}
