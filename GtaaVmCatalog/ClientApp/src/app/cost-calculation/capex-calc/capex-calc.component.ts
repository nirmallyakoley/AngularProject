import { Component, OnInit, Input } from '@angular/core';
import { CapexEnvironment } from '../../model/CapexEnvironment';


@Component({
  selector: 'app-capex-calc',
  templateUrl: './capex-calc.component.html',
  styleUrls: ['./capex-calc.component.css']
})
export class CapexCalcComponent implements OnInit {
   

    @Input() CapexList: CapexEnvironment[];
    public capexCost: number=0.0;
  constructor() { }

    ngOnInit() {
        if (this.CapexList != null && this.CapexList.length > 0) {
            this.CapexList.forEach(objCapexEnvironment => { this.capexCost += objCapexEnvironment.CapexCost });
        }
    }
    
  }


