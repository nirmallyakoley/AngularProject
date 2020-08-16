import { NgModule } from "@angular/core";
import { Repository } from "./repository";
import { VmServiceService } from "./vm-service.service";

@NgModule({
    providers: [Repository]
}) 
export class ModelModule {

}
