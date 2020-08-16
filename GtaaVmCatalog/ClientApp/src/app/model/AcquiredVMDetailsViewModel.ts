import { VMProject } from "./vmproject.model";
import { AcquiredVMSpecification } from "./AcquiredVMSpecification";

export class AcquiredVMDetailsViewModel {
    public tblVmproject: VMProject;
    public aquiredVmSpecification: AcquiredVMSpecification[];
    constructor() {
        this.tblVmproject = new VMProject();
        this.aquiredVmSpecification = new Array(new AcquiredVMSpecification());
    }
}
