import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl,FormGroup,FormBuilder,Validator,NgForm, Validators } from '@angular/forms';
import { ConsultancyReport } from '../Source/consultancy-report';

@Component({
  selector: 'app-addpconsultancy-report',
  templateUrl: './addpconsultancy-report.component.html',
  styleUrls: ['./addpconsultancy-report.component.css']
})
export class AddpconsultancyReportComponent implements OnInit {
  frmCReport:FormGroup;
  selectedFile!: File;
  constructor(private http:HttpClient,private formBuilder:FormBuilder) {
    this.frmCReport=this.formBuilder.group({ 
    //  CR_Id:new FormControl('',Validators.required) ,
     DoctorName :new FormControl('',[Validators.required,Validators.minLength(3)]),
     DateofConsultancy:new FormControl('',Validators.required),
     ClinicName:new FormControl('',[Validators.required,Validators.minLength(3)]),
     DiseaseName:new FormControl('',[Validators.required,Validators.minLength(3)]),
    //  Prescription:new FormControl('',Validators.required),
     IsActive:new FormControl('',Validators.required),
    UId:localStorage.getItem('UId')

    });
   }

   fileSelected($event:any){
     this.selectedFile = $event.target.files[0];
     console.log(this.selectedFile);
   }

   get f(){
     return this.frmCReport.controls;
   }
   SaveReport(){
    //  const header = new HttpHeaders();
    //  header.append('Content-Type' , 'application/json');
    //  const options = {Headers:header};
    
     const fd = new FormData();
     fd.append('uploadedfile',this.selectedFile);
     fd.append('prescription' , JSON.stringify(this.frmCReport.value));
    if(this.frmCReport.valid){
      // let p:ConsultancyReport=this.frmCReport.value as ConsultancyReport;
      this.http.post('http://localhost:57071/api/Patient/AddConsultancyReport', fd).subscribe(data=>{
        alert('product saved');
      },error=>{
        alert('not saved');
      })

    }
    else{
     alert('Invalid form entries');
    }
   }

  ngOnInit(): void {
  }

}
