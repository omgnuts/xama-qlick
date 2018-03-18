import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

export const routes: Routes = [
    { path: "", loadChildren: "./+home/home.module#HomeModule?chunkName=home" },
    { path: "admin", loadChildren: "./+admin/admin.module#AdminModule?chunkName=admin" },
    { path: "**", redirectTo: "", pathMatch: "full" },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutesModule { }