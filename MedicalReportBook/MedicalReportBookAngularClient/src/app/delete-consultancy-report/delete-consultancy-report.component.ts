import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-delete-consultancy-report',
  templateUrl: './delete-consultancy-report.component.html',
  styleUrls: ['./delete-consultancy-report.component.css']
})
export class DeleteConsultancyReportComponent implements OnInit {
  ReportId: number;
  DiseaseName: string;
  UserId=localStorage.getItem('UId');
  public url:string="http://localhost:57071/api/Patient/DeleteConsultancyReport/";
  errorMessage: any;
  urlt: string='';
  status: string='';

  constructor(private http: HttpClient,private router:Router,private actr:ActivatedRoute){
    this.ReportId=Number(this.actr.snapshot.paramMap.get('CR-Id'));
    this.DiseaseName=String(this.actr.snapshot.paramMap.get('Disease-Name'));
  }

  ngOnInit(): void {
  }
  OnSubmit(){
    this.urlt=this.url+this.UserId+'/'+this.DiseaseName+'/'+this.ReportId;
    this.http.delete(this.urlt)
        .subscribe({
            next: data => {
                this.status = 'Delete successful';
                alert('Prescription Deleted');
                this.router.navigateByUrl("/consultancy-report");
            },
            error: error => {
                this.errorMessage = error.message;
                console.error('There was an error!', error);
                alert('Prescription deletion failed');
            }
        });

}
}
