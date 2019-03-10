import { PersonDesigantionService } from './../../../shared/service/person-desigantion.service';
import { Observable } from 'rxjs';
import { Designation } from './../../../shared/models/person.model.';
import { Component, OnInit, ViewChild } from '@angular/core';
import * as data from './../../../shared/data';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { ModalComponent } from 'angular-custom-modal';
@Component({
  selector: 'app-person-designation',
  templateUrl: './person-designation.component.html',
  styleUrls: ['./person-designation.component.css']
})
export class PersonDesignationComponent implements OnInit {
  @ViewChild('htmlInsideModal') ModalPopup: ModalComponent;
  newDesignation: Designation;
  designationForm: FormGroup;
  saved: boolean = false;
  IsListShorted: boolean = false;
  items: Designation[] = [];
  deleteItem: Designation = null;

  sortedItems: Designation[];
  listStyle = {
    width: '100%', //width of the list defaults to 300
    height: '100%', //height of the list defaults to 250
  };

  constructor(private formBuilder: FormBuilder, private pds: PersonDesigantionService) {

    this.designationForm = this.formBuilder.group({
      DesignationTitle: ['', Validators.required],
      TitleAbbreviation: ['', Validators.required],
      Id: [null],
      SortOrder: [null]
    }
    );
    pds.data.subscribe((i: Designation[]) => {
      this.items.splice(0, this.items.length);
      this.items = i;
      this.sortedItems = this.items;

    });
  }
  ngOnInit() {
  }
  listOrderChanged($event) {
    this.IsListShorted = true;
    // this.items = $event;
    $event.forEach(function (value, index) {
      value.SortOrder = index;
    });
    this.sortedItems = $event;
  }
  addOrEdit() {
    if (!this.designationForm.valid) {
      this.saved = true;
      return;
    }

    const a = Object.assign({}, {
      Id: this.designationForm.value.Id === null ? this.items.length : this.designationForm.value.Id,
      DesignationTitle: this.designationForm.value.DesignationTitle,
      TitleAbbreviation: this.designationForm.value.TitleAbbreviation,
      SortOrder: this.designationForm.value.Id === null ? this.items.length : this.designationForm.value.SortOrder
    });
    this.pds.add(a).subscribe(o => {
      this.saved = false;
      this.designationForm.reset();
    });
  }
  get f() { return this.designationForm.controls; }
  edit(item) {
    this.designationForm.setValue({
      'DesignationTitle': item.DesignationTitle, 'TitleAbbreviation': item.TitleAbbreviation,
      'Id': item.Id, 'SortOrder': item.SortOrder
    });
  }
  clearEdit() {
    this.designationForm.reset();
  }
  delete(item) {
    this.deleteItem = item;
    this.ModalPopup.open();
  }
  deleteConfirm() {
    this.ModalPopup.close();
    this.pds.remove(this.deleteItem).subscribe(o => {
      this.deleteItem = null;
      this.sortItem(this.items);
      this.saveShorting();
    });
  }
  cancelSorting() {
    this.pds.data.subscribe((i: Designation[]) => {
      this.items = i;
      this.sortedItems = this.items;
    });
    this.IsListShorted = false;
  }
  saveShorting() {
    this.pds.saveShorting(this.sortedItems).subscribe(o => {
      this.IsListShorted = false;
    });
  }

  sortItem(listToSort: Designation[]) {
    listToSort.forEach(function (value, index) {
      value.SortOrder = index;
    });
    this.IsListShorted = true;
  }

}
