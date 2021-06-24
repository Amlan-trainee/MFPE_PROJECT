import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-delete-doctor',
  templateUrl: './delete-doctor.component.html',
  styleUrls: ['./delete-doctor.component.css']
})
export class DeleteDoctorComponent implements OnInit {
  UserId: number;
  EmailId: string;
  url:string="http://localhost:57071/api/Admin/RemoveDoctor/";
  urlt:string='';
  

  constructor(private http: HttpClient,private router:Router,private actr:ActivatedRoute){
    this.UserId=Number(this.actr.snapshot.paramMap.get('user-id'));
    this.EmailId=String(this.actr.snapshot.paramMap.get('mail-id'));
  }

  ngOnInit(): void {
  }

  OnSubmit(){
    this.urlt = this.url+this.EmailId+'/'+this.UserId;
    this.http.delete(this.urlt)
        .subscribe({
            next: data => {
                alert('Doctor Deleted');
            },
            error: error => {
                alert('Doctor deletion failed');
            }
        });

}
}
