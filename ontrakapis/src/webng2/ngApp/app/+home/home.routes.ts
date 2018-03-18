import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { HomeComponent } from "./home.component";

export const routes: Routes = [
    { path: "", component: HomeComponent,
        children: [
            { path: "about", loadChildren: "./../+about/about.module#AboutModule?chunkName=about" }
        ]
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class HomeRoutesModule { }