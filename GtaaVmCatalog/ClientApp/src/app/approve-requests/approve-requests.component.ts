import { Component, OnInit } from '@angular/core';
import { VMProject } from '../model/vmproject.model';
import { tblVmapprovalRejection } from '../model/vmapprovalrejection.model';
import { VmServiceService } from '../model/vm-service.service';
import { CustomResponseMessage } from '../model/CustomResponseMessage';
import { AuthenticationService } from '../_services/authentication.service';
import { User } from '../model/user';
import { VMApprovalViewModel } from '../model/vmApprovalViewModel';
import { HelperConstant } from '../helper/HelperConstant';
import Swal from 'sweetalert2'


@Component({
    selector: 'app-approve-requests',
    templateUrl:'./approve-requests.component.html'
})
export class ApproveRequestsComponent implements OnInit {
    public vmprojects: VMProject[];
    private objCustomResponseMessage: CustomResponseMessage;
    public approverLevel: string;
    public status: string;
    public currentUser: User;
    public vmApprovalViewModel: VMApprovalViewModel;
    private VmapprovalRejection: tblVmapprovalRejection;

    constructor(private service: VmServiceService, private authenticationService: AuthenticationService)
    {
       
        this.VmapprovalRejection = new tblVmapprovalRejection();
        this.vmApprovalViewModel = new VMApprovalViewModel();
        this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
        this.VmapprovalRejection.ApprovedOrRejectedBy = authenticationService.currentUserValue.email;
        this.VmapprovalRejection.ApprovalLevel = authenticationService.currentUserValue.accessLevel;
        this.vmApprovalViewModel.tblVmapprovalRejection = this.VmapprovalRejection;
       
    }

    ngOnInit()
    {
        this.getVMRequestsForApprover();
    }
    public getVMRequestsForApprover()
    {
        // userlevel from LDAP//
        this.approverLevel = this.currentUser.accessLevel;
        const promise = this.service.getVMRequestsForApproverL1(this.approverLevel);
        promise.then((data) => {
            if (data != undefined || data != null) {
                this.vmprojects = data;
            }
        }).catch((error) => {
            console.log("Promise rejected with " + JSON.stringify(error));
        });
    }

    public approveRequest(i: number, approver: string)
    {
        Swal.fire({
            title: 'Are you sure to approve?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, Approve it!'
        }).then((result) => {
            if (result.value) {
                this.fireApprove(i,approver);
                Swal.fire(
                    'Approved!',
                    'The VM Request approved successfully for further processing.',
                    'success'
                )
            }
        });

        
      
    }


    private fireApprove(i: number, approver: string) : void
    {
        this.status = "Approved";
        let objVMProject = this.vmprojects[i];
        if (approver == HelperConstant.PDM_APPROVER) {
            objVMProject.approverL1 = true;
        }
        else if (approver == HelperConstant.TAP_APPROVER) {
            objVMProject.approverL2 = true;
        }
        else if (approver == HelperConstant.DIRECTOR_APPROVER) {
            objVMProject.approverL3 = true;
        }

        this.vmApprovalViewModel.tblVmproject = objVMProject;
        this.vmApprovalViewModel.tblVmapprovalRejection.Status = this.status;
          const promise = this.service.approveOrRejectVMRequest(this.vmApprovalViewModel);
          promise.then((data) => {
            this.objCustomResponseMessage = data;
            if (this.objCustomResponseMessage != undefined || this.objCustomResponseMessage != null) {
                if (this.objCustomResponseMessage.message == "success") {
                    this.getVMRequestsForApprover();
                    this.service.sendEmail(this.vmApprovalViewModel, this.status);
                }

            } else {
                console.log("Promise rejected with " + JSON.stringify(this.objCustomResponseMessage));
            }
        }).catch((error) => {
            console.log("Promise rejected with " + JSON.stringify(error));
        });
    }

    public rejectRequest(i: number, approver: string)
    {
        Swal.fire({
            title: 'Are you sure to reject?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, Reject it!'
        }).then((result) => {
            if (result.value) {
                this.fireReject(i, approver);
                Swal.fire(
                    'Rejected!',
                    'The VM Request rejected successfully from your end .',
                    'success'
                )
            }
        });
    }


    private fireReject(i: number, approver: string)
    {
        this.status = "Rejected";
        let objVMProject = this.vmprojects[i];

        if (approver == HelperConstant.PDM_APPROVER) {
            objVMProject.approverL1 = false;
        }
        else if (approver == HelperConstant.TAP_APPROVER) {
            objVMProject.approverL1 = false;
            objVMProject.approverL2 = false;
        }
        else if (approver == HelperConstant.DIRECTOR_APPROVER) {
            objVMProject.approverL2 = false;
            objVMProject.approverL3 = false;
        }

        this.vmApprovalViewModel.tblVmproject = objVMProject;
        this.vmApprovalViewModel.tblVmapprovalRejection.Status = this.status;
        const promise = this.service.approveOrRejectVMRequest(this.vmApprovalViewModel);
        promise.then((data) => {
            this.objCustomResponseMessage = data;
            if (this.objCustomResponseMessage != undefined || this.objCustomResponseMessage != null) {
                if (this.objCustomResponseMessage.message == "success") {
                    this.getVMRequestsForApprover();
                    this.service.sendEmail(this.vmApprovalViewModel, this.status);
                }

            } else {
                console.log("Promise rejected with " + JSON.stringify(this.objCustomResponseMessage));
            }
        }).catch((error) => {
            console.log("Promise rejected with " + JSON.stringify(error));
        });

    }
}
