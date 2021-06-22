import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl,FormGroup,FormBuilder,Validator,NgForm, Validators } from '@angular/forms';
import { ConsultancyReport } from '../Source/consultancy-report';
import { TestReport } from '../Source/test-report';


@Component({
  selector: 'app-addtest-report',
  templateUrl: './addtest-report.component.html',
  styleUrls: ['./addtest-report.component.css']
})
export class AddtestReportComponent implements OnInit {

  frmTReport:FormGroup;
  selectedFile!: File;
  router: any;
  constructor(private http:HttpClient,private formBuilder:FormBuilder) {
    this.frmTReport=this.formBuilder.group({
    //  Lr_Id:new FormControl('',Validators.required) ,
     DoctorName :new FormControl('',[Validators.required,Validators.minLength(3)]),
     LabName:new FormControl('',[Validators.required,Validators.minLength(3)]),
     DateofTest:new FormControl('',Validators.required),
     TestName:new FormControl('',[Validators.required,Validators.minLength(3)]),
    //  LabReport:new FormControl('',Validators.required),
     IsActive:new FormControl(false),
    UID:localStorage.getItem('UId')

    });
   }

   fileSelected($event:any){
    this.selectedFile = $event.target.files[0];
    console.log(this.selectedFile);
  }

   get f(){
     return this.frmTReport.controls;
   }
   SaveReport(){

    const fd = new FormData();
     fd.append('uploadedfile',this.selectedFile);
     fd.append('labreport' , JSON.stringify(this.frmTReport.value));

    if(this.frmTReport.valid){
      // let p:TestReport=this.frmCReport.value as TestReport;
      this.http.post('http://localhost:57071/api/Patient/AddTestReport',fd).subscribe(data=>{
        alert('test report saved'); 
        this.router.navigate(['/test-report']);

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
