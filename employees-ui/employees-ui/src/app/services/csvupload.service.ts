import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {environment } from '../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class CSVUploadService {

  constructor( private http: HttpClient) { }


  public uploadCSV(file: File): Promise<any> {
    const formData = new FormData();
    formData.append('file', file, file.name);
    debugger;

    return this.http.post(environment.apiBaseUrl + 'upload', formData).toPromise()
      .then(response => {
        console.log('CSV uploaded successfully', response);
        return response;
      })
      .catch(error => {
        console.error('Error uploading CSV', error);
        throw error;
      });
  }
}
