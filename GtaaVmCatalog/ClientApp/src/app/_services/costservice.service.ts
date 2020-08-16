import { Injectable, Inject } from '@angular/core';
import { HttpClient } from  '@angular/common/http';
import { Observable } from 'rxjs';
import { OpexViewModel } from '../model/opexViewModel ';
import { CapexViewModel } from '../model/CapexViewModel';

@Injectable({
  providedIn: 'root'
})
export class CostserviceService {

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string)
    {

    }

    public getOpexCost(requestId: number): Observable<OpexViewModel>
        {
        let url = this.baseUrl + `opexcost/${requestId}`;
        return this.http.get<OpexViewModel>(url);
    }

    public getCapexCost(requestId: number): Observable<CapexViewModel[]> {
        let url = this.baseUrl + `capex/${requestId}`;
        return this.http.get<CapexViewModel[]>(url);
    }
}
