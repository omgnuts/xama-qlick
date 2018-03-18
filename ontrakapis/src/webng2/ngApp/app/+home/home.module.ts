import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { HomeComponent } from "./home.component";
import { HomeRoutesModule } from "./home.routes";


@NgModule({
    imports: [
        CommonModule,
        HomeRoutesModule
    ],
    declarations: [
        HomeComponent
    ],
    providers: [],
    bootstrap: [HomeComponent]
})

export class HomeModule { }