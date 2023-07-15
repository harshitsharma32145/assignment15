
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { Food2Component } from '../food2/food2.component';

@Component({
  selector: 'app-food',
  templateUrl: './food.component.html',
  styleUrls: ['./food.component.css']
})
export class FoodComponent {
  constructor(private fb: FormBuilder, private route: Router, private actroute: ActivatedRoute, private dialog: MatDialog) { }
  // Addfood:FormGroup

  Addfood = this.fb.group({

    mobileno: new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
    traineno: new FormControl('', [Validators.required, Validators.maxLength(10), Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
    date: new FormControl('', [Validators.required]),
    // boardingStation:new FormControl('haldwani')
  })
  goto2(data: any)
   {
    // this.route.navigate(['food2'],{queryParams:
    //    {mobileno:data.mobileno,
    //     traineno: data.traineno,
    //     date:data.date
    //   
    let dialogRef =this.dialog.open(Food2Component,{
      data:{data}
    } )


    console.log(data);
  }
}
