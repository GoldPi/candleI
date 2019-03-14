import { Component, OnInit } from '@angular/core';
import { EventType } from "src/app/shared/models/event-type.enum";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-event-add',
  templateUrl: './event-add.component.html',
  styleUrls: ['./event-add.component.css']
})
export class EventAddComponent implements OnInit {

  addFrom:FormGroup;
  submitted=false;

  eventType=EventType;
  constructor(private formBuilder: FormBuilder) {

    this.addFrom = this.formBuilder.group({
      Title:['', Validators.required]
      
        }
      );
    
   }

  ngOnInit() {
  }
  get f() { return this.addFrom.controls; }
  onSubmit() {
    this.submitted = true;
   
    
    if (this.addFrom.invalid) {
        return;
    }

    alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.addFrom.value))
  }
}
