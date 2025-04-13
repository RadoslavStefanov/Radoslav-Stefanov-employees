import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CsvUploadComponent } from "./components/csv-upload/csv-upload.component";
import { AwardDetailsComponent } from './components/award-details/award-details.component';
import { NgIf } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CsvUploadComponent, AwardDetailsComponent, NgIf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'employees-ui';
  showResultsComponent = false;

  constructor(private toastr: ToastrService) {}
  
  ngOnInit() {
    this.toastr.success('The Employee Management System is at your service!', 'Welcome!', { timeOut: 3000 });
  }
}