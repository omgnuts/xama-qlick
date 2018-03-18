import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { AboutComponent } from "./about.component";
import { AboutRoutesModule } from "./about.routes";

@NgModule({
    imports: [
        CommonModule,
        AboutRoutesModule
    ],
    exports: [],
    declarations: [
        AboutComponent
    ],
    providers: [],
})

export class AboutModule { }