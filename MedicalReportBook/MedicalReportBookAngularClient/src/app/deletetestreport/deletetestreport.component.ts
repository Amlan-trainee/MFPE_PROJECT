import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ConsultancyReport } from '../Source/consultancy-report';
import { TestReport } from '../Source/test-report';

@Component({
  selector: 'app-deletetestreport',
  templateUrl: './deletetestreport.component.html',
  styleUrls: ['./deletetestreport.component.css']
})
export class DeletetestreportComponent implements OnInit {

  reports:TestReport[] = [];
  formData: any;


  constructor(private http: HttpClientModule,private router:Router){}

  ngOnInit(): void {

  };
  public url:string="http://localhost:57071/api/Patient/DeleteConsultancyReport/";

  public urlt:string="";

  public UserId=localStorage.getItem('UId');




}
