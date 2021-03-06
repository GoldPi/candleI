import { Component, OnInit, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { UploaderOptions, UploadFile, UploadInput, humanizeBytes, UploadOutput } from 'ngx-uploader';

@Component({
  selector: 'app-media-upload',
  templateUrl: './media-upload.component.html',
  styleUrls: ['./media-upload.component.css']
})
export class MediaUploadComponent implements OnInit {
  ngOnInit() {
    
  }
  
  options: UploaderOptions;
  formData: FormData;
  files: UploadFile[];
  uploadInput: EventEmitter<UploadInput>;
  humanizeBytes: Function;
  dragOver: boolean;
  urlp="";
  constructor(private router:Router) {
    var url=this.router.url.split('/')
    url.pop();
    this.urlp=url.join('/');
  
     this.options = { concurrency: 1, maxUploads: 3 };
     this.files = []; // local uploading files array
     this.uploadInput = new EventEmitter<UploadInput>(); // input events, we use this to emit data to ngx-uploader
     this.humanizeBytes = humanizeBytes;
   }
  
   onUploadOutput(output: UploadOutput): void {
     switch (output.type) {
       case 'allAddedToQueue':
           // uncomment this if you want to auto upload files when added
           // const event: UploadInput = {
           //   type: 'uploadAll',
           //   url: '/upload',
           //   method: 'POST',
           //   data: { foo: 'bar' }
           // };
           // this.uploadInput.emit(event);
         break;
       case 'addedToQueue':
         if (typeof output.file !== 'undefined') {
           this.files.push(output.file);
         }
         break;
       case 'uploading':
         if (typeof output.file !== 'undefined') {
           // update current data in files array for uploading file
           const index = this.files.findIndex((file) => typeof output.file !== 'undefined' && file.id === output.file.id);
           this.files[index] = output.file;
         }
         break;
       case 'removed':
         // remove file from array when removed
         this.files = this.files.filter((file: UploadFile) => file !== output.file);
         break;
       case 'dragOver':
         this.dragOver = true;
         break;
       case 'dragOut':
       case 'drop':
         this.dragOver = false;
         break;
       case 'done':
         // The file is downloaded
         break;
     }
   }
  
   startUpload(): void {
     const event: UploadInput = {
       type: 'uploadAll',
       url: 'http://ngx-uploader.com/upload',
       method: 'POST',
       data: { foo: 'bar' }
     };
  
     this.uploadInput.emit(event);
   }
  
   cancelUpload(id: string): void {
     this.uploadInput.emit({ type: 'cancel', id: id });
   }
  
   removeFile(id: string): void {
     this.uploadInput.emit({ type: 'remove', id: id });
   }
  
   removeAllFiles(): void {
     this.uploadInput.emit({ type: 'removeAll' });
   }

}
