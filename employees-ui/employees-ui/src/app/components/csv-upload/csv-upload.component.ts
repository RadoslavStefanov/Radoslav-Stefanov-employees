import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CSVUploadService } from '../../services/csvupload.service';
import { NgIf } from '@angular/common';
import { PairResults } from '../../core/models/PairResults.model';

@Component({
  selector: 'app-csv-upload',
  templateUrl: './csv-upload.component.html',
  styleUrls: ['./csv-upload.component.scss'],
  imports: [NgIf]
})
export class CsvUploadComponent {

  uploadForm: FormGroup;
  @Output() csvUploadComplete = new EventEmitter<PairResults>();

  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private csvService: CSVUploadService
  ) {
    this.uploadForm = this.fb.group({
      file: [null]
    });
  }

  get selectedFile(): File | null {
    return this.uploadForm.get('file')?.value || null;
  }

  onDragOver(event: DragEvent) {
    event.preventDefault();
    (event.currentTarget as HTMLElement).classList.add('dragover');
  }

  onDragLeave(event: DragEvent) {
    (event.currentTarget as HTMLElement).classList.remove('dragover');
  }

  onDrop(event: DragEvent) {
    event.preventDefault();
    (event.currentTarget as HTMLElement).classList.remove('dragover');

    const files = event.dataTransfer?.files;
    if (files?.length) {
      const file = files[0];
      this.uploadForm.patchValue({ file });
    }
  }

  onFileSelected(event: Event) {
    const input = event.target as HTMLInputElement;
    const files = input.files;
    if (files?.length) {
      const file = files[0];
      this.uploadForm.patchValue({ file });
    }
  }

  submitCsv() {
    if (this.selectedFile) {
      this.csvService.uploadCSV(this.selectedFile).then((res) => {
        this.toastr.success('File uploaded successfully!');
        this.csvUploadComplete.emit(res as PairResults);
      }).catch((error) => {
        console.error('Error uploading file:', error);
        this.toastr.error(error.error || 'Error uploading file!');
      });
    } else {
      this.toastr.warning('No file selected!');
    }
  }
}
