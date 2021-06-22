export class ConsultancyReport {
    constructor(public CR_Id:number,public DoctorName: string, public DateofConsultancy:Date,public ClinicName : string,
        public DiseaseName:string,public Prescription:File,public IsActive:boolean,public UId:number){}
}