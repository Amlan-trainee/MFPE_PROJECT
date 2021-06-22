import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-delete-doctor',
  templateUrl: './delete-doctor.component.html',
  styleUrls: ['./delete-doctor.component.css']
})
export class DeleteDoctorComponent implements OnInit {

  url:string = 'http://localhost:57071/api/Admin/RemoveDoctor/';
  urlt:string = '';
  status: string='';
  errorMessage: any;

  constructor(private http :HttpClient) { }

  ngOnInit(): void {
  }

  OnDelete(data: { Email: string; UserId: string; }){
    this.urlt=this.url+data.Email+'/'+data.UserId;
    this.http.delete(this.urlt)
        .subscribe({
            next: data => {
                this.status = 'Delete successful';
            },
            error: error => {
                this.errorMessage = error.message;
                console.error('There was an error!', error);
            }
        });

  }

}
