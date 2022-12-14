import { Directive, ViewContainerRef, OnInit, TemplateRef } from '@angular/core';
import { environment } from '../environment';

/**
 * usage: <div *hideProd></div>
 */
@Directive({
  selector: '[debug]'
})
export class OnlyDebugDirective implements OnInit{

  constructor(private templateRef: TemplateRef<any>, private viewContainerRef: ViewContainerRef) { }

  ngOnInit(): void {
    if(!environment.prod){
      this.viewContainerRef.createEmbeddedView(this.templateRef);
    }
  }

}