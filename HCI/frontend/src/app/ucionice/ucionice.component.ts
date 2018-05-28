import { Component, OnInit } from '@angular/core';
import { Ucionica }    from '../ucionica';
@Component({
  selector: 'app-ucionice',
  templateUrl: './ucionice.component.html',
  styleUrls: ['./ucionice.component.css']
})
export class UcioniceComponent implements OnInit {

  constructor() { }
  /**ucionica = new Ucionica('JUG','OPIS',15,true,true,true,'os','softver');*/
	ucionica = new Ucionica();
  ngOnInit() {
  }

}
