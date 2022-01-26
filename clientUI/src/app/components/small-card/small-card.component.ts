import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-small-card',
  templateUrl: './small-card.component.html',
  styleUrls: ['./small-card.component.css']
})
export class SmallCardComponent implements OnInit {

  @Input() background !: string ;
  @Input() info !: boolean ;
  @Input() count!: number;
  @Input() mainicon!:string;
  @Input() link!:string;
  @Input() title!:string;
  @Input() symbol!:string;
  constructor() { }

  ngOnInit(): void {
  }

}
