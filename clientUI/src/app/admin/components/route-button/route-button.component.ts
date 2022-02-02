import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-route-button',
  templateUrl: './route-button.component.html',
  styleUrls: ['./route-button.component.css']
})
export class RouteButtonComponent implements OnInit {

  @Input() link!: string;
  @Input() btnColor!: string;
  @Input() btnPosition!: string;
  @Input() title!: string;
  @Input() icon!: string;
  constructor() { }

  ngOnInit(): void {
  }

}
