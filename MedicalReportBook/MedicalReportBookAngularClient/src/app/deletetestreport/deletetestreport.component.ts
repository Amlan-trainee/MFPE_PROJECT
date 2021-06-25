import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TestReport } from '../Source/test-report';

@Component({
  selector: 'app-deletetestreport',
  templateUrl: './deletetestreport.component.html',
  styleUrls: ['./deletetestreport.component.css']
})
export class DeletetestreportComponent implements OnInit {
  TestId: number;
  TestName: string;
  UserId=localStorage.getItem('UId');
  public url:string="http://localhost:57071/api/Patient/DeleteLabReport/";
  status!: string;
  errorMessage: any;
  urlt: string='';


  constructor(private http: HttpClient,private router:Router,private actr:ActivatedRoute){
    this.TestId=Number(this.actr.snapshot.paramMap.get('Lr-Id'));
    this.TestName=String(this.actr.snapshot.paramMap.get('Test-Name'));
  }

  ngOnInit(): void {
    
  }
  OnSubmit(){
    this.urlt=this.url+this.UserId+'/'+this.TestName+'/'+this.TestId;
    this.http.delete(this.urlt)
        .subscribe({
            next: data => {
              alert('Doctor Deleted');
              this.status = 'Delete successful';
              this.router.navigateByUrl("/test-report");
               
            },
            error: error => {
              alert('Doctor Deletion Failed');
              this.errorMessage = error.message;
              console.error('There was an error!', error);
            }
        });
  }




}
