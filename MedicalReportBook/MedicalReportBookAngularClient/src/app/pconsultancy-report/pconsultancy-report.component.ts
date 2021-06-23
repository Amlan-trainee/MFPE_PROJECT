import { Component, OnInit } from '@angular/core';
import { ConsultancyReport } from '../Source/consultancy-report';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-pconsultancy-report',
  templateUrl: './pconsultancy-report.component.html',
  styleUrls: ['./pconsultancy-report.component.css']
})
export class PconsultancyReportComponent implements OnInit {
  reports:ConsultancyReport[] = [];
  formData: any;
  // ReportId: number;
  Status:boolean | undefined;
  postId: any;
  errorMessage: any;
  
  constructor(private http :HttpClient) {
    // this.ReportId=Number(this.actr.snapshot.paramMap.get('CR-Id'));
    // this.Status=Boolean(this.actr.snapshot.paramMap.get('Status'));
  
  }


  url:string="http://localhost:57071/api/Patient/ViewConsultancyReport/";
  // urllt:string="http://localhost:57071/api/Patient/LockUnlockCrReport/";
  urlt:string="";
  UserId=localStorage.getItem('UId');
  // urll:string="";



  ngOnInit(): void {
    this.formData = new FormGroup({
      name    : new FormControl()
  });
    
  }

  onSubmit(data: { DiseaseName: string; }){ 
     this.urlt= this.url+this.UserId+'/'+data.DiseaseName;

     this.http.get(this.urlt).subscribe(
      (data)=>{this.reports= data as ConsultancyReport[]},
      (err)=>{
        if(err.status===404){
          alert('Api not available');
        }
        else if(err.status===500){
          alert('Server Error');
        }
      }

    );
  }

  // OnToggle(){
  //   this.urll=this.urllt+this.ReportId;
  //   // const body = { title: 'Angular PUT Request Example' };
  //   this.http.put(`${this.urll}/${this.ReportId}`,true)
  //       .subscribe({
  //           next: data => {
                
  //               alert('Status Changed');
  //           },
  //           error: error => {
  //               this.errorMessage = error.message;
  //               console.error('There was an error!', error);
  //               alert('Status Change Failed');
  //           }
  //       });

  // }
}
