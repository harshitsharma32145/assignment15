import { Component } from '@angular/core';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent {
fooddetail:FoodDetail[]=[
  {foodname:'pizza',description:'any',price:500},
  {foodname:'momo',description:'any',price:100},
  {foodname:'burger',description:'any',price:200},
]
}
interface FoodDetail{
  foodname:string;
  description:string;
  price:number;
}