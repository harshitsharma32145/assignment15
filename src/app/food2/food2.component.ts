import { Component, Inject } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { FoodComponent } from '../food/food.component';
import { ActivatedRoute, Router } from '@angular/router';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-food2',
  templateUrl: './food2.component.html',
  styleUrls: ['./food2.component.css']
})
export class Food2Component {
  userdata: any=[];
  constructor(@Inject(MAT_DIALOG_DATA) public data: any,private fb: FormBuilder,private route:Router, private actroute: ActivatedRoute) { }
journey:any
train:any
  ngOnInit(): void {
    this.Addfood2 = this.fb.group({
      mobileno: new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
      traineno: new FormControl('', [Validators.required, Validators.maxLength(10), Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
      date: new FormControl('', [Validators.required]),
      boardingStation:new FormControl('',Validators.required)
    })
    console.log(this.data);
    
    this.Addfood2.patchValue(this.data)}
    // this.actroute.queryParams.subscribe((params) => {
    //   this.userdata[0] = params["journey"];
    //   this.journey=this.userdata[0],
    //   this.userdata[1]=params['train'];
    //   this.train=this.userdata[1];
    //   console.log(this.journey);
      
    //   console.log(this.train);
    // })
  

    // ,private fd:FoodComponent
    Addfood2 = this.fb.group({
      mobileno: new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
      traineno: new FormControl('', [Validators.required, Validators.maxLength(10), Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
      date: new FormControl('', [Validators.required]),
      boardingStation:new FormControl('',Validators.required)
    })

    goto3(i: any)
    { 
      this.route.navigate(['order'])
      
    }
    boarding: Boarding[] = [
      { value: 'Haldwani', station: 'Haldwani' },
      { value: 'Haldwani', station: 'Dehradun' },
    ]
  }

 
interface Boarding {
  value: string;
  station: string;
}