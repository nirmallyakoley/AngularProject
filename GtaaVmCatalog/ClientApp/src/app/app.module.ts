import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApproveRequestsComponent } from './approve-requests/approve-requests.component';
import { ModelModule } from './model/model.module';
import { VmRequestComponent } from './vm-request/vm-request.component';
import { BasicAuthInterceptor } from './_helpers/basic-auth.interceptor';
import { ErrorInterceptor } from './_helpers/error.interceptor';
import { LoginComponent } from './Login/login.component';
import { AuthGuard } from './_helpers/auth.guard';
import { WorkflowComponent } from './fetch-data/workflow/workflow.component';
import { CostCalculationComponent } from './cost-calculation/cost-calculation.component';
import { OpexYearComponent } from './cost-calculation/opex-year/opex-year.component';
import { CapexCalcComponent } from './cost-calculation/capex-calc/capex-calc.component';
import { UploadFileComponent } from './upload-file/upload-file.component';
import { ShowVmdetailsComponent } from './show-vmdetails/show-vmdetails.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    VmRequestComponent,
    ApproveRequestsComponent,
        LoginComponent,
        WorkflowComponent,
        CostCalculationComponent,
        OpexYearComponent,
        CapexCalcComponent,
        UploadFileComponent,
        ShowVmdetailsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
      HttpClientModule,
      NgbModule,
      ReactiveFormsModule,
      FormsModule,
      ModelModule,
      RouterModule.forRoot([
          { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] },
          { path: 'approve-requests', component: ApproveRequestsComponent },
          { path: 'fetch-data', component: FetchDataComponent },
          { path: 'vmrequest', component: VmRequestComponent },
          { path: 'login', component: LoginComponent },
          { path: 'workflow/:vmRequestId', component: WorkflowComponent },
          { path: 'cost/:vmRequestId', component: CostCalculationComponent },
          { path: 'upload-file/:vmRequestId', component: UploadFileComponent },
          { path: 'show-vmdetails/:vmRequestId', component: ShowVmdetailsComponent },

    ])
  ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: BasicAuthInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }        
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
