export class TblCapexCostDetail {

    constructor(private id?: number,
        private requestId?: number,
        private vmrequisitionId?: number,
        private vmenvironmentTypeId?: string,
        private capexType?: string,
        private capexUnit?: number,
        private capexPerUnitCost?: number,
        private capexCost?: number,
        private createdOn?: number
    ) { }

}
