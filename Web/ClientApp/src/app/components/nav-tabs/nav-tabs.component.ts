import {Component, Input, OnInit, ViewChild} from '@angular/core';

@Component({
  selector: 'app-nav-tabs',
  templateUrl: './nav-tabs.component.html',
  styleUrls: ['./nav-tabs.component.css']
})
export class NavTabsComponent implements OnInit {
  @Input() academyId: number;
  @Input() techDirection : number;
  @ViewChild('showHistory') childHistory;
  @ViewChild('showFeedbacks') childFeedbacks;

  getAppTestNamesTemplate(directId: number) {
    this.childHistory.getTestsTemplate(directId);
    this.childFeedbacks.getTestsTemplate(directId);
  }
  updateTestNameTab() {
    this.childHistory.updateTab();
    this.childFeedbacks.updateTab();

  }
  constructor() {}

  ngOnInit() {
  }
}
