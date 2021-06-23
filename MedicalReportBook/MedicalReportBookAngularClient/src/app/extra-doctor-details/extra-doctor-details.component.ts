import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl,FormGroup,FormBuilder,Validator,NgForm, Validators } from '@angular/forms';
import { ExtraDoctorDetails } from '../Source/extradoctordetails';
@Component({
  selector: 'app-extra-doctor-details',
  templateUrl: './extra-doctor-details.component.html',
  styleUrls: ['./extra-doctor-details.component.css']
})
export class ExtraDoctorDetailsComponent implements OnInit {
  frmTReport:FormGroup;
  constructor(private http:HttpClient,private formBuilder:FormBuilder) {
    this.frmTReport=this.formBuilder.group({
      DoctorId: new FormControl('',[Validators.required,Validators.minLength(3)]),
      Specialization:new FormControl('',[Validators.required,Validators.minLength(3)]),
      Qualification:new FormControl('',Validators.required)
      })
   }

  ngOnInit(): void {
  }
  get f(){
    return this.frmTReport.controls;
  }

  SaveReport(){
    const fd=new FormData()
    if(this.frmTReport.valid){
      this.http.post('pi',fd).subscribe(data=>{
        alert('details saved');
      },error=>{
        alert('details not saved');
      })
    }
}
