import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Router } from '@angular/router';

import { PrimeNgModules } from './prime-ng.modules';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { ViewAcademiesNgxComponent } from './components/view-academies/view-academies-ngx/view-academies-ngx.component';
import { AcademyService } from './components/view-academies/academy.service';

import { HistoryListComponent } from './components/history/history-list/history-list.component';
import { HistoryService } from './components/history/history.service';

import { NavTabsComponent } from './components/nav-tabs/nav-tabs.component';
import { HeaderComponent } from './components/header/header.component';
import { ErrorComponent } from './components/error/error.component';
import { NotFoundErrorComponent } from './components/error/not-found-error/not-found-error.component';

@NgModule({
  declarations: [
      AppComponent
    , HeaderComponent
    , NavTabsComponent
    , HistoryListComponent
    , ErrorComponent
    , NotFoundErrorComponent
    , ViewAcademiesNgxComponent
  ],
  imports: [
      BrowserModule.withServerTransition({ appId: 'ng-cli-universal' })
    , HttpClientModule
    , AppRoutingModule
    , FormsModule
    , PrimeNgModules
  ],
  providers: [HistoryService, AcademyService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule {
  constructor(router: Router) {
    //console.log('AppModule Routes: ', JSON.stringify(router.config, undefined, 2));
  }
}
