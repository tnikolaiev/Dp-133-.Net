import { Component, Input, OnInit } from '@angular/core';
import { FeedbackService } from '../feedback.service';
import { MatTableDataSource } from "@angular/material";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-feedback-list',
  templateUrl: './feedback-list.component.html',
  styleUrls: ['./feedback-list.component.css'],
  providers: [FeedbackService]
})

export class FeedbackListComponent implements OnInit {
  @Input() groupId: number = 2;

  academyId: number = 1;
  dataTable: any;
 // dataTableExpert: any;
  constructor(private feedbackService: FeedbackService,
    private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.academyId = 586; // this.groupId;
   
    this.feedbackService.getTeacherInGroup(this.academyId).subscribe(
      data => {
        this.dataTable = data;
        console.log(' Feedback data:');
        console.log(data);
      },
      error => console.log(error)
    );
   
    
  }

}

