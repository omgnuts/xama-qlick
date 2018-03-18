import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { AdminComponent } from "./admin.component";
import { AdminRoutesModule } from "./admin.routes";

@NgModule({
    imports: [
        CommonModule,
        AdminRoutesModule
    ],
    exports: [],
    declarations: [
        AdminComponent
    ],
    providers: [],
})

export class AdminModule { }