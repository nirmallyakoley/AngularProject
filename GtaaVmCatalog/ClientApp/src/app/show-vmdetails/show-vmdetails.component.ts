import { Component, OnInit } from '@angular/core';
import { VmServiceService } from '../model/vm-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AcquiredVMDetailsViewModel } from '../model/AcquiredVMDetailsViewModel';
import { Location } from '@angular/common';


@Component({
  selector: 'app-show-vmdetails',
  templateUrl: './show-vmdetails.component.html',
  styleUrls: ['./show-vmdetails.component.css']
})
export class ShowVmdetailsComponent implements OnInit {
    private objAcquiredVMDetailsViewModel: AcquiredVMDetailsViewModel;
    private requestId: number;
    constructor(private service: VmServiceService, private route: ActivatedRoute, private router: Router, private locationService: Location) { }

    ngOnInit() {
        this.route.paramMap.subscribe(params => this.requestId = +params.get('vmRequestId'))
        this.getAcquiredVMDetails();
    }
    public getAcquiredVMDetails() {
        this.objAcquiredVMDetailsViewModel = new AcquiredVMDetailsViewModel();
        this.service.getRequestedVMDetails(this.requestId).subscribe((data) =>
        {
            this.objAcquiredVMDetailsViewModel = data;
            console.log(this.objAcquiredVMDetailsViewModel);
        });
    }
    close() {
        this.locationService.back();
    }
}
