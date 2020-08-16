
export class Opexdetail
{
    constructor(
        private id?: number,
        private requestId?: number,
        private vmrequisitionId?: number,
        private opexType?: string,
        private year?: number,
        private months?: number,
        private costPerYear?: number,
        private actualCost?: number,
        private createdOn?: number
    ) { }
}
