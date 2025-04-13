import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CsvUploadComponent } from "./components/csv-upload/csv-upload.component";
import { AwardDetailsComponent } from './components/award-details/award-details.component';
import { NgIf } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { PairResults } from './core/models/PairResults.model';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CsvUploadComponent, AwardDetailsComponent, NgIf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'employees-ui';
  showResultsComponent = false;
  result: PairResults | null = null;

  constructor(private toastr: ToastrService) {}
  
  ngOnInit() {
    this.toastr.success('The Employee Management System is at your service!', 'Welcome!', { timeOut: 3000 });
  }

  onCsvUploadComplete(result: any): void {
    this.result = result as PairResults;
    this.showResultsComponent = true;
    this.toastr.success( `Employees #${this.result.empId1} and #${this.result.empId2} are inseparable!`, 'Congrats.', { timeOut: 3000 });
  }
}