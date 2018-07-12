import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { RouterModule, Router, Routes } from '@angular/router';

import { NavTabsComponent } from './components/nav-tabs/nav-tabs.component';
import { HeaderComponent } from './components/header/header.component';
import { NotFoundErrorComponent } from './components/error/not-found-error/not-found-error.component';
import { ViewAcademiesNgxComponent } from './components/view-academies/view-academies-ngx/view-academies-ngx.component'

const appRoutes: Routes = [
    //{ path: '', component: NavTabsComponent, pathMatch: 'full' }
    { path: '', component: ViewAcademiesNgxComponent, pathMatch: 'full' }
  , { path: 'history', component: NavTabsComponent }
  , { path: '**', component: NotFoundErrorComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes
                      , { enableTracing: true } // <-- debugging purposes only
    )
  ],
  exports: [RouterModule],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppRoutingModule {
  constructor(router: Router) {
    //console.log('ARM Routes: ', JSON.stringify(router.config, undefined, 2));
  }
}
