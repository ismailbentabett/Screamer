import { Component, Input } from '@angular/core';
import { User } from 'src/app/core/models/User';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.scss']
})
export class UserCardComponent {
@Input () user! : User | any
@Input () userId! : string | any

/**
 *
 */
constructor() {

}

//oninit void
ngOnInit(): void {
console.log(
  "userId",
  this.userId
)
}





}
