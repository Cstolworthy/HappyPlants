import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoadingScreenComponent } from './loading-screen/loading-screen.component';
import { OnlyDebugDirective } from './directives/OnlyDebugDirective';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    LoadingScreenComponent,
    OnlyDebugDirective
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
       { path: '', component: DashboardComponent, pathMatch: 'full' },
       { path: 'plants', loadChildren: () => import('./plants/plants.module').then(m => m.PlantsModule) },
    //   { path: 'fetch-data', component: FetchDataComponent },
     ]) 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
