import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CsvUploadComponent } from "./components/csv-upload/csv-upload.component";
import { AwardDetailsComponent } from './components/award-details/award-details.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CsvUploadComponent, AwardDetailsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'employees-ui';
}
