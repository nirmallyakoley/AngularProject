export class AcquiredVMSpecification {
    constructor(
        private vmEnvironment?: string,
        private vmOs?: string,
        private vmCpuType?: string,
        private vmRamType?: string,
        private vmStorageType?: string,
        private vmMonitoringType?: string
    ) { }
}
