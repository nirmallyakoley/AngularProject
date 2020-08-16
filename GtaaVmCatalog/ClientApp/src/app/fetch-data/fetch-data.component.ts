import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { VMProject } from '../model/vmproject.model';
import { Repository } from '../model/repository';
import { VmServiceService } from '../model/vm-service.service';
import { CustomResponseMessage } from '../model/CustomResponseMessage';
import { AuthenticationService } from '../_services/authentication.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {    
    public vmprojects: VMProject[];
    public requestid : number;
    public objMessageResponse: CustomResponseMessage;
    constructor(private service: VmServiceService, private authenticationService: AuthenticationService) { }

    ngOnInit() {
        this.getVMProjectList(this.authenticationService.currentUserValue.username);       
    }   

    public getVMProjectList(userName:string) {
        this.service.getVMProjectList(userName).subscribe(data => (this.vmprojects = data));
        
    }

    public deleteVMRequest(requestId: number) {
        this.requestid = requestId;
        let objVmRequest: VMProject = this.vmprojects.find(objVMRequest => objVMRequest.requestId == requestId);
        if (objVmRequest != null) { 
            if (confirm("Do you want to delete request: REQ" + requestId + "?") == true) {
                this.getVMProjectList(this.authenticationService.currentUserValue.username);
                this.service.deleteVmRequest(objVmRequest).subscribe(data => {
                    this.objMessageResponse = data;
                    if (this.objMessageResponse.message == "success") {
                        window.alert("Successfully deleted the request:REQ" + requestId);
                        this.getVMProjectList(this.authenticationService.currentUserValue.username);
                    }
                    else
                        window.alert("Sorry.. Something went wrong!");
                });
            }
            else
                this.getVMProjectList(this.authenticationService.currentUserValue.username);         
        }
    }
    
}


