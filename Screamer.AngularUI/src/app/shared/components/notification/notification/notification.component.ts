import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.scss']
})
export class NotificationComponent {

  constructor(private toastr: ToastrService) {

  }

  ngOnInit () : void{
var data =     this.toastr.toasts;
console.log(data);

}


  showToaster() {
  }
}
