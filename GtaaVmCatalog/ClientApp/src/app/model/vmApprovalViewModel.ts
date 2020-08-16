import { VMProject } from '../model/vmproject.model';
import { tblVmapprovalRejection } from '../model/vmapprovalrejection.model';

export class VMApprovalViewModel {
    public tblVmproject: VMProject;
    public tblVmapprovalRejection: tblVmapprovalRejection;
   
    constructor() {
        this.tblVmproject = new VMProject();
        this.tblVmapprovalRejection = new tblVmapprovalRejection();
    }
}
