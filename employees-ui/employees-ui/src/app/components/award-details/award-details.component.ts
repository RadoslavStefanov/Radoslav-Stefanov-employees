import { Component, Input } from '@angular/core';
import { PairResults } from '../../core/models/PairResults.model';
import { NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-award-details',
  imports: [NgFor, NgIf],
  templateUrl: './award-details.component.html',
  styleUrl: './award-details.component.scss'
})
export class AwardDetailsComponent {

  @Input() result: PairResults | null = null;
}
