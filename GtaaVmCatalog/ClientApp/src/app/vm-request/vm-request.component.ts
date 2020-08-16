import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Repository } from '../model/repository';
import { CustomResponseMessage } from '../model/CustomResponseMessage';
import { Router } from '@angular/router';
import { VmServiceService } from '../model/vm-service.service';
import { VMEnvironment } from '../model/vmenvironment.model';

import { VMOs } from '../model/vmos.model';
import { VMCpu } from '../model/vmcpu.model';
import { VMRam } from '../model/vmram.model';
import { VMStorage } from '../model/vmstorage.model';
import { VMRequestViewModel } from '../model/vmRequestViewModel';
import { VmRequisitionDetails } from '../model/vmrequistiondetail.model';
import { project } from '../model/project.model';
import { NgbAccordion } from '@ng-bootstrap/ng-bootstrap';
import { AuthenticationService } from '../_services/authentication.service';
import { User } from '../model/user';
import { VmMonitoringType } from '../model/vmMonitoringType.model';
import { HelperConstant } from '../helper/HelperConstant';
import { start } from 'repl';
import Swal from 'sweetalert2';


@Component({
    selector: 'app-vm-request',
    templateUrl: './vm-request.component.html',
    styleUrls: ['./vm-request.component.css']
})
export class VmRequestComponent implements OnInit {

    public objVMEnvironmentList: VMEnvironment[];
    public objMessageResponse: CustomResponseMessage;
    public objvmRequestViewModel: VMRequestViewModel;
    public objVMOsArray: VMOs[];
    public objVMCpuArray: VMCpu[];
    public objVMRamArray: VMRam[];
    public objVMStorageArray: VMStorage[];
    public objProjectArray: project[];
    private currentUser: User;
    private objVmMonitoringTypeArray: VmMonitoringType[];
    public quoteId: string;
    public fileToUpload: FormData;

    @ViewChild('myaccordion', { static: true }) accordion: NgbAccordion;
    constructor(private repository: Repository, private router: Router, private service: VmServiceService, private authenticationService: AuthenticationService) {
        this.objvmRequestViewModel = new VMRequestViewModel();
        this.currentUser = authenticationService.currentUserValue;
    }

    ngOnInit() {

        this.objMessageResponse = new CustomResponseMessage();
        this.polulateEnvironmentType();
        this.populateOSList();
        this.populateCpuList();
        this.populateRamList();
        this.poulateStorageList();
        this.populateProjectList();
        this.populateMonitoringType();
        this.getQuoteId();
        this.objvmRequestViewModel.TblVmproject.siem = "Yes";
        
    }

    onSubmit(form: NgForm) {
        this.objvmRequestViewModel.TblVmproject.approverL1 = false;
        this.objvmRequestViewModel.TblVmproject.approverL2 = false;
        this.objvmRequestViewModel.TblVmproject.approverL3 = false;
        this.objvmRequestViewModel.TblVmproject.requesterLoggedId = this.currentUser.email;
        this.objvmRequestViewModel.TblVmproject.requesterUserId = this.currentUser.username;
        if (this.objvmRequestViewModel.TblVmproject.tapApprovalDoc != 'Yes')
            this.objvmRequestViewModel.TblVmproject.tapApprovalDocUrl = '';
        if (this.objvmRequestViewModel.TblVmproject.solutionDesignDoc != 'Yes')
            this.objvmRequestViewModel.TblVmproject.solutionDesignDocUrl = '';
        if (this.objvmRequestViewModel.TblVmproject.buildSheetDoc != 'Yes')
            this.objvmRequestViewModel.TblVmproject.buildSheetDocUrl = '';
        if (this.objvmRequestViewModel.TblVmproject.securityApprovalDoc != 'Yes')
            this.objvmRequestViewModel.TblVmproject.securityApprovalDocUrl = '';


        this.repository.registerVMProject(this.objvmRequestViewModel).subscribe(data => {
            this.objMessageResponse = data;
            if (this.objMessageResponse.message == "success") {
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: 'VM request successfully saved',
                    showConfirmButton: false,
                    timer: 3000
                });
                this.close();
            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Something went wrong!',
                    footer: 'Please contact administrator!'
                });
            }
            console.log(this.objMessageResponse);
        },
            error => {
                console.log(error);
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Something went wrong!',
                    footer: 'Please contact administrator!'
                });
                     }

        );
        this.accordion.collapseAll();
    }

    public getQuoteId() {        
        this.service.getQuoteIdNumber().subscribe(data =>
        {
            this.quoteId = data;
            this.objvmRequestViewModel.TblVmproject.quoteIdnumber = this.quoteId;
            console.log(data);
         },
           error => {
               window.alert(error);  
            }
        );
    }


    close() {
        this.router.navigateByUrl("/fetch-data");
    }
    newRow() {
        this.objvmRequestViewModel.TblVmRequisitionDetailsList.push(new VmRequisitionDetails(undefined, undefined, "VMEN0001", "VMOS0001", "VMCPU0001", "VMRAM0001", "VMSTOR0001", "VMMON001", undefined));
    }

    deleteRow(i: number) {
        this.objvmRequestViewModel.TblVmRequisitionDetailsList.splice(i, 1);
    }

    polulateEnvironmentType() {
        this.service.getVMEnvironmentList().subscribe((data) => {
            this.objVMEnvironmentList = data;
        });
    }
    populateOSList() {
        this.service.getVMOsList().subscribe((data) => { this.objVMOsArray = data });
    }

    populateCpuList() {
        this.service.getVMCpuList().subscribe((data) => { this.objVMCpuArray = data });
    }
    populateRamList() {
        this.service.getVMRamList().subscribe((data) => { this.objVMRamArray = data });
    }

    poulateStorageList() {
        this.service.getVMStorageList().subscribe((data) => { this.objVMStorageArray = data });
    }

    populateProjectList() {
        this.objProjectArray = [new project("ChatBot Project", "ChatBotProject"), new project("TP-Site Project", "TPSiteProject")];

    }
    populateMonitoringType() {
        this.service.getMonitoringData().subscribe((data) => { this.objVmMonitoringTypeArray = data });
    }
    public uploadFile(files: any, docType: string) {
        if (typeof this.quoteId != 'undefined' && this.quoteId) {
            let fileName: string = String(files[0].name);
            let fileType: string = fileName.substring(fileName.lastIndexOf('.') + 1);

            //let fileType: string = (files[0].name).split('.')[1];
            if (docType == HelperConstant.TapDoc)
                this.objvmRequestViewModel.TblVmproject.tapApprovalDocUrl = HelperConstant.BLOB_URL + docType + this.quoteId + "." + fileType;
            else if (docType == HelperConstant.SolDesignDoc)
                this.objvmRequestViewModel.TblVmproject.solutionDesignDocUrl = HelperConstant.BLOB_URL + docType + this.quoteId + "." + fileType;
            else if (docType == HelperConstant.BuildSheetDoc)
                this.objvmRequestViewModel.TblVmproject.buildSheetDocUrl = HelperConstant.BLOB_URL + docType + this.quoteId + "." + fileType;
            else
                this.objvmRequestViewModel.TblVmproject.securityApprovalDocUrl = HelperConstant.BLOB_URL + docType + this.quoteId + "." + fileType;

            let formData: FormData = new FormData();
            formData.append('myfile', files[0], docType + this.quoteId + "." + fileType);
            this.fileToUpload = formData;
            this.service.postFile(this.fileToUpload).subscribe((response: any) => {
                if (response == true) {
                    console.log(true);
                }
                else
                    console.log(false);
            },
                err => console.log(err));
        }
        else
            return false;
    }
    
}






