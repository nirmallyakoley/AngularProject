import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { VmServiceService } from '../model/vm-service.service';

@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.css']
})
export class UploadFileComponent implements OnInit {
    public vmRequestId: number;
    public fileToUpload: FormData;

    constructor(private route: ActivatedRoute, private service: VmServiceService) { }

    ngOnInit() {
        this.route.paramMap.subscribe(params => this.vmRequestId = +params.get('vmRequestId'))
    }
    public uploadFile(files: any) {
        let formData: FormData = new FormData();
        formData.append('myfile', files[0], 'Req' + this.vmRequestId + files[0].name)
        this.fileToUpload = formData;
        this.service.postFile(this.fileToUpload).subscribe((response: any) => {
            if (response == true) {
                console.log(true);
            }
            else
                console.log(false);
        },
            err => console.log(err));
    }

}
