export class TestReport {
    constructor(public  Lr_Id:number,public DoctorName:string,public LabName:string,public DateofTest:Date,public TestName:string,
      public LabReport:File, public  IsActive:boolean,public UID:number){}
}
