import {Component, Input, OnInit} from '@angular/core';
import {HistoryService} from '../history.service';
import {MatTableDataSource} from "@angular/material";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-history-list',
  templateUrl: './history-list.component.html',
  styleUrls: ['./history-list.component.css'],
  providers: [HistoryService]
})

export class HistoryListComponent implements OnInit {
    @Input() groupId: number = 2;

    academyId: number = 1;
    dataTable: any;

  constructor(private historyService: HistoryService,
    private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.academyId = 586; // this.groupId;
    this.historyService.getAll(this.academyId).subscribe(
      data => {
        this.dataTable = data;
        console.log('History data:');
        console.log(data);
      },
      error => console.log(error)
    );
  }

}


