export class ConsultancyReport {
    constructor(public DoctorName: string, public DateofConsultancy:Date,public ClinicName : string,
        public DiseaseName:string,public Prescription:string,public IsActive:boolean,public UId:number){}
}