import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { VMProject } from './vmproject.model';
import { Observable, Subscribable, Subscription } from 'rxjs';
import { CustomResponseMessage } from './CustomResponseMessage';
import { VMEnvironment } from './vmenvironment.model';
import { tblVmapprovalRejection } from './vmapprovalrejection.model';
import { VMOs } from './vmos.model';
import { VMCpu } from './vmcpu.model';
import { VMRam } from './vmram.model';
import { VMStorage } from './vmstorage.model';
import { VMRequestViewModel } from './vmRequestViewModel';
import { VMApprovalViewModel } from './vmApprovalViewModel';
import { Email } from './email.model';
import { VmMonitoringType } from './vmMonitoringType.model';
import { promise } from 'protractor';
import { AcquiredVMDetailsViewModel } from './AcquiredVMDetailsViewModel';



@Injectable({
  providedIn: 'root'
})
export class VmServiceService {

    constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    }
    private objEmail: Email;

    public registerVMProject(obj: VMRequestViewModel):Observable<CustomResponseMessage> {
        let url = this.baseUrl + 'vmproject';
        return this.httpClient.post<CustomResponseMessage>(url, obj, { headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' }) }
        );
    }
    public getRequestedVMDetails(requestId: number): Observable<AcquiredVMDetailsViewModel> {
        let url = this.baseUrl + 'vmdetails';
        return this.httpClient.post<AcquiredVMDetailsViewModel>(url, requestId, { headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' }) });
    }

    public getVMProjectList(userName:String): Observable<VMProject[]> { 
        let url = this.baseUrl + `vmproject/${userName}`;
        return this.httpClient.get<VMProject[]>(url);
           
    }
    public getVMRequestsForApproverL1(userLevel: string): Promise<VMProject[]> {
        let url = this.baseUrl + 'vmrequestapprover/' + userLevel;
        //let params = new HttpParams().set('userLevel', userLevel);
        return this.httpClient.post<VMProject[]>(url, null, { headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' }) }).toPromise();       
    }



    public approveOrRejectVMRequest(objVMApprovalViewModel: VMApprovalViewModel): Promise<CustomResponseMessage>
    {
        let url = this.baseUrl + 'vmrequestapprover';        
        return this.httpClient.post<CustomResponseMessage>(url, objVMApprovalViewModel, { headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' }) }).toPromise(); 
    }
    public sendEmail(objVMApprovalViewModel: VMApprovalViewModel, status: string): Promise<CustomResponseMessage> {
        let emailUrl = this.baseUrl + 'email';
        this.objEmail = new Email();
        this.objEmail.requestId = objVMApprovalViewModel.tblVmproject.requestId;
        this.objEmail.approverLevel = objVMApprovalViewModel.tblVmapprovalRejection.ApprovalLevel;
        this.objEmail.email = objVMApprovalViewModel.tblVmproject.requesterLoggedId;
        this.objEmail.requestStatus = status;
        return this.httpClient.post<CustomResponseMessage>(emailUrl, this.objEmail, { headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' }) }).toPromise();
    }
        public getVMEnvironmentList(): Observable<VMEnvironment[]> {
        let url = this.baseUrl + 'vmenvironment';
        return this.httpClient.get<VMEnvironment[]>(url);
    }


    public getVMOsList(): Observable<VMOs[]> {
        let url = this.baseUrl + 'vmos';
        return this.httpClient.get<VMOs[]>(url);
    }

    public getVMCpuList(): Observable<VMCpu[]> {
        let url = this.baseUrl + 'vmcpu';
        return this.httpClient.get<VMCpu[]>(url);

    }
    public getVMRamList(): Observable<VMRam[]> {
        let url = this.baseUrl + 'vmram';
        return this.httpClient.get<VMRam[]>(url);

    }

    public getVMStorageList(): Observable<VMStorage[]> {
        let url = this.baseUrl + 'vmstorage';
        return this.httpClient.get<VMStorage[]>(url);

    }

    public deleteVmRequest(objVMProject: VMProject): Observable<CustomResponseMessage> {
        let url = this.baseUrl + 'vmproject';
        return this.httpClient.put<CustomResponseMessage>(url, objVMProject, { headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' }) });

    }
    public getWorkflowData(vmRequestId: number): Observable<tblVmapprovalRejection[]> {
        let url = this.baseUrl + 'Workflow';
        return this.httpClient.post<tblVmapprovalRejection[]>(url, vmRequestId, { headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8'}) });
    }

    //fetch monitoring data//
    public getMonitoringData(): Observable<VmMonitoringType[]> {
        let url = this.baseUrl + 'vmmonitoring';
        return this.httpClient.get<VmMonitoringType[]>(url);
    }
    public postFile(file: FormData): Observable<boolean>{
        let url = this.baseUrl + 'uploadfile';
        return this.httpClient.post<boolean>(url, file);
    }
    public getQuoteIdNumber(): Observable<string> {
        const headers = new HttpHeaders().set('Content-Type', 'text/plain; charset=utf-8');
            let url = this.baseUrl + 'quoteid';
        return this.httpClient.get<string>(url, { headers, responseType: 'text' as 'json'});
      
    }

}
