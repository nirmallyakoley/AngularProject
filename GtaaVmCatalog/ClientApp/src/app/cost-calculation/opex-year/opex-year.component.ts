import { Component, OnInit, Input } from '@angular/core';
import { CostBO } from '../../model/costBO';

@Component({
  selector: 'app-opex-year',
  templateUrl: './opex-year.component.html',
  styleUrls: ['./opex-year.component.css']
})
export class OpexYearComponent implements OnInit {
    @Input() year: number;
    @Input() opexData: CostBO[];
    public yearWiseOpexData: CostBO[];
    public yearWiseOpexCost: number= 0.0;

  constructor() { }

    ngOnInit() {
        if (this.opexData != null && this.opexData.length > 0) {
            this.yearWiseOpexData = this.opexData.filter(obj => obj.Year == this.year);
            if (this.yearWiseOpexData != null && this.yearWiseOpexData.length > 0) {
                this.yearWiseOpexData.forEach(costBo => { this.yearWiseOpexCost += costBo.CostAmount});
            }
        }
  }

}
