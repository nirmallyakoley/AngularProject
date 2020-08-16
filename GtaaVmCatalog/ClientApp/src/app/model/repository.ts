import { VMProject } from "./vmproject.model";
import { VmServiceService } from "./vm-service.service";
import { VMRequestViewModel } from "./vmRequestViewModel";
import { AuthenticationService } from "../_services/authentication.service";


export class Repository {
    constructor(private vmService: VmServiceService, private authenticationService: AuthenticationService) {
        this.getVMProjectList(this.authenticationService.currentUserValue.username);
    }
    public vmproject: VMProject;
    public VmProjectList: VMProject[];


    public registerVMProject(obj: VMRequestViewModel)    {
        return this.vmService.registerVMProject(obj);
    }

    public getVMProjectList(userName:string) {
        this.vmService.getVMProjectList(userName)            
            .subscribe(data => this.VmProjectList = data);
    }
}



