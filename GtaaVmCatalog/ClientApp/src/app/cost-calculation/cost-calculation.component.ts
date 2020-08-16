import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CostserviceService } from '../_services/costservice.service';
import { OpexViewModel } from '../model/opexViewModel ';
import { CapexViewModel } from '../model/CapexViewModel';
import { Location } from '@angular/common';

@Component({
  selector: 'app-cost-calculation',
  templateUrl: './cost-calculation.component.html',
  styleUrls: ['./cost-calculation.component.css']
})
export class CostCalculationComponent implements OnInit {
    public vmRequestId: number;
    public objOpexViewModel: OpexViewModel;
    public objCapexVieModelArray: CapexViewModel[]
    constructor(private route: ActivatedRoute, private costService: CostserviceService,private locationService:Location) {
    }

    ngOnInit() {
        this.route.paramMap.subscribe(params => this.vmRequestId = +params.get('vmRequestId'))
        this.costService.getOpexCost(this.vmRequestId).subscribe(data => {            
            this.objOpexViewModel = data;
          
        });

        this.costService.getCapexCost(this.vmRequestId).subscribe(data => {
            this.objCapexVieModelArray = data;           
        });
    }

    navigateBack() {
        this.locationService.back();
    }




}
