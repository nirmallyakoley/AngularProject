export class Email {
    constructor(
        public requestId?: number,
        public requestStatus?: string,
        public email?: string,
        public approverLevel?: string
    ) { }
}
