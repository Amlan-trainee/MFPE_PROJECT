export class UpdatePassword {
    constructor(public User_Id:number,public OldPassword:string,public NewPassword:string,
        public ConfirmPassword:string){};
}
