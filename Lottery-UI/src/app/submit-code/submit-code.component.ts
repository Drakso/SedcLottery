import { Component, OnInit } from '@angular/core';
import { IUserCode, ICode } from '../winners-list/winners-list.model';
import { SubmitCodeService } from './submit-code.service';
import { ToastrService } from 'ngx-toastr'; // toastr is a library for notifications ( error or success )
import { Router } from '@angular/router';

@Component({
  selector: 'app-submit-code',
  templateUrl: './submit-code.component.html',
  styleUrls: ['./submit-code.component.css']
})
// The submitCodeComponent has a userCode object that is initially empty
export class SubmitCodeComponent implements OnInit {
  userCode: IUserCode = {} as IUserCode;

  constructor(private submitCodeService: SubmitCodeService,
    private toastrService: ToastrService,
    private router: Router) {
    this.userCode.code = {} as ICode;
  }

  ngOnInit() {
  }

  // A method of the component that submits the data entered and binded to the userCode model from the view
  submit() {
    // We call the submitCodeService and submit the code and the toastr library prints a message accordingly
    this.submitCodeService.submitCode(this.userCode).subscribe((result) => {
      if(!!result) {
        this.toastrService.success(result.awardDescription, "Congartulations!");
      } else {
        this.toastrService.info("Better luck next time", "Info");
      }
      this.router.navigate(['winners']);
    }, (error) => {
      this.toastrService.error(error.error.exceptionMessage, "Error!")
    })
  }
}
