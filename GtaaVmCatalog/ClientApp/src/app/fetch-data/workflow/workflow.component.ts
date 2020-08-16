import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { tblVmapprovalRejection } from '../../model/vmapprovalrejection.model';
import { VmServiceService } from '../../model/vm-service.service';
import { workflow } from '../../model/workflow.model';
import { Location } from '@angular/common';



@Component({
  selector: 'app-workflow',
  templateUrl: './workflow.component.html',
  styleUrls: ['./workflow.component.css']
})
export class WorkflowComponent implements OnInit {
    public vmRequestId: number;
    public objtblVmapprovalRejection: tblVmapprovalRejection[];
   

    constructor(private route: ActivatedRoute, private service: VmServiceService, private locationService: Location) {
        
    }

    ngOnInit() {
        this.route.paramMap.subscribe(params => this.vmRequestId = +params.get('vmRequestId'))
        this.fetchApproverData();
    }
    public fetchApproverData() {
        this.service.getWorkflowData(this.vmRequestId).subscribe(data =>
        {
            this.objtblVmapprovalRejection = data;
            console.log(this.objtblVmapprovalRejection);
        });
       
    }

    navigateBack() {
        this.locationService.back();
    }
}
