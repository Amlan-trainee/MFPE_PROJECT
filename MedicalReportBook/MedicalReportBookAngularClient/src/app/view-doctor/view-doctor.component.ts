import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Getdoctor } from '../Source/getdoctor';

@Component({
  selector: 'app-view-doctor',
  templateUrl: './view-doctor.component.html',
  styleUrls: ['./view-doctor.component.css']
})
export class ViewDoctorComponent implements OnInit {
  DoctorData:Getdoctor[]=[];
  url:string='';
  formData: FormGroup | undefined;

  constructor(private http :HttpClient) { }

  ngOnInit(): void {

    this.formData = new FormGroup({name : new FormControl()});

    this.http.get(this.url).subscribe(
      (data)=>{this.DoctorData= data as Getdoctor[]},
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

}
