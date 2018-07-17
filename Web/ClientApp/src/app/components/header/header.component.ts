import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  private employeeFirstName: string;
  private employeeLastName: string;

  constructor(private router: Router) {
  }

  ngOnInit() {
      this.employeeFirstName = 'FN';
      this.employeeLastName = 'LN';
  }

  logout = () => {
    //this.cookie.remove('auth');
  };

}
