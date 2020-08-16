import { VMProject } from "./vmproject.model";
import { VmRequisitionDetails } from "./vmrequistiondetail.model";

export class VMRequestViewModel {
    public TblVmproject: VMProject;
    public TblVmRequisitionDetailsList: VmRequisitionDetails[];
    constructor() {
        this.TblVmproject = new VMProject();
        this.TblVmRequisitionDetailsList = new Array(new VmRequisitionDetails(undefined, undefined, "VMEN0001", "VMOS0001", "VMCPU0001", "VMRAM0001", "VMSTOR0001", "VMMON001", undefined));
    }
}
