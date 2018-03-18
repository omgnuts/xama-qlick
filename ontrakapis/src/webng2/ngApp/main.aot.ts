// Entry point for AOT compilation

import { platformBrowser } from "@angular/platform-browser";
import { AppModuleNgFactory } from "./../gen/ngfactory/ngApp/app/app.module.ngfactory";

import { enableProdMode } from "@angular/core";

enableProdMode();
platformBrowser().bootstrapModuleFactory(AppModuleNgFactory);