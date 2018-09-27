// Importing angular modules, interfaces from the winner-list.model file and the WinnersListService for communication with the backend
import { Component, OnInit } from '@angular/core';
import { IUserCodeAward } from './winners-list.model';
import { WinnersListService } from './winners-list.service';

// Component configuration
@Component({
  selector: 'app-winners-list',
  templateUrl: './winners-list.component.html',
  styleUrls: ['./winners-list.component.css']
})
// Here we export the module
// OnInit( on creation ) of the component creates an array of IUserCodeAward interface that is called winners
export class WinnersListComponent implements OnInit {
  public winners: Array<IUserCodeAward>;
  // Initially we make the winners array to be an empty array in the constructor.
  constructor(private winnersListService: WinnersListService) {
    this.winners = [];
  }
  // When the angular is done creating the component ( the instanciation of the component class is done ) this ngOnInit executes
  // Here we make a call to the service and get all winners. After that we add all winners in the winners array and if the promise returns error, we log the error in the console
  ngOnInit() {
    this.winnersListService.getAllWinners().subscribe((result) => {
      this.winners = result;
    }, (error) => {
      console.log(error);
    });
  }

}
