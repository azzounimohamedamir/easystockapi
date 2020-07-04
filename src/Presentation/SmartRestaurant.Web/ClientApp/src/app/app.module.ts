import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PreloaderComponent } from './components/layouts/preloader/preloader.component';
import { SideNavbarComponent } from './components/layouts/side-navbar/side-navbar.component';
import { TopNavbarComponent } from './components/layouts/top-navbar/top-navbar.component';
import { HomeComponent } from './components/pages/home/home.component';
import { MenuCatalogueComponent } from './components/pages/menu-catalogue/menu-catalogue.component';
import { MenuListComponent } from './components/pages/menu-list/menu-list.component';
import { MenuGridComponent } from './components/pages/menu-grid/menu-grid.component';
import { AddProductComponent } from './components/pages/add-product/add-product.component';
import { ProductDetailComponent } from './components/pages/product-detail/product-detail.component';
import { OrdersComponent } from './components/pages/orders/orders.component';
import { RestaurantsListComponent } from './components/pages/restaurants-list/restaurants-list.component';
import { AddRestaurantComponent } from './components/pages/add-restaurant/add-restaurant.component';
import { InvoiceDetailComponent } from './components/pages/invoice-detail/invoice-detail.component';
import { InvoiceListComponent } from './components/pages/invoice-list/invoice-list.component';
import { CustomersReviewComponent } from './components/pages/customers-review/customers-review.component';
import { CustomersListComponent } from './components/pages/customers-list/customers-list.component';
import { SocialActivityComponent } from './components/pages/social-activity/social-activity.component';
import { SalesComponent } from './components/pages/sales/sales.component';
import { WidgetsComponent } from './components/pages/widgets/widgets.component';
import { AccordionsComponent } from './components/pages/accordions/accordions.component';
import { AlertsComponent } from './components/pages/alerts/alerts.component';
import { ButtonsComponent } from './components/pages/buttons/buttons.component';
import { BreadcrumbsComponent } from './components/pages/breadcrumbs/breadcrumbs.component';
import { BadgesComponent } from './components/pages/badges/badges.component';
import { CardsComponent } from './components/pages/cards/cards.component';
import { ProgressBarsComponent } from './components/pages/progress-bars/progress-bars.component';
import { PreLoadersComponent } from './components/pages/pre-loaders/pre-loaders.component';
import { PaginationComponent } from './components/pages/pagination/pagination.component';
import { TabsComponent } from './components/pages/tabs/tabs.component';
import { TypographyComponent } from './components/pages/typography/typography.component';
import { DraggablesComponent } from './components/pages/draggables/draggables.component';
import { SlidersComponent } from './components/pages/sliders/sliders.component';
import { ModalsComponent } from './components/pages/modals/modals.component';
import { RatingComponent } from './components/pages/rating/rating.component';
import { TourComponent } from './components/pages/tour/tour.component';
import { CropperComponent } from './components/pages/cropper/cropper.component';
import { RangeSliderComponent } from './components/pages/range-slider/range-slider.component';
import { AnimationsComponent } from './components/pages/animations/animations.component';
import { FormElementsComponent } from './components/pages/form-elements/form-elements.component';
import { FormLayoutsComponent } from './components/pages/form-layouts/form-layouts.component';
import { FormValidationComponent } from './components/pages/form-validation/form-validation.component';
import { FormWizardComponent } from './components/pages/form-wizard/form-wizard.component';
import { ChartjsComponent } from './components/pages/chartjs/chartjs.component';
import { MorrisChartComponent } from './components/pages/morris-chart/morris-chart.component';
import { BasicTablesComponent } from './components/pages/basic-tables/basic-tables.component';
import { DataTablesComponent } from './components/pages/data-tables/data-tables.component';
import { SweetAlertsComponent } from './components/pages/sweet-alerts/sweet-alerts.component';
import { ToastComponent } from './components/pages/toast/toast.component';
import { FontawesomeComponent } from './components/pages/fontawesome/fontawesome.component';
import { FlaticonsComponent } from './components/pages/flaticons/flaticons.component';
import { MaterializeComponent } from './components/pages/materialize/materialize.component';
import { GoogleMapsComponent } from './components/pages/google-maps/google-maps.component';
import { VectorMapsComponent } from './components/pages/vector-maps/vector-maps.component';
import { WebAnalyticsComponent } from './components/pages/web-analytics/web-analytics.component';
import { StockManagementComponent } from './components/pages/stock-management/stock-management.component';
import { ClientManagementComponent } from './components/pages/client-management/client-management.component';
import { DefaultLoginComponent } from './components/pages/default-login/default-login.component';
import { ModalLoginComponent } from './components/pages/modal-login/modal-login.component';
import { DefaultRegisterComponent } from './components/pages/default-register/default-register.component';
import { ModalRegisterComponent } from './components/pages/modal-register/modal-register.component';
import { LockScreenComponent } from './components/pages/lock-screen/lock-screen.component';
import { ComingSoonComponent } from './components/pages/coming-soon/coming-soon.component';
import { ErrorComponent } from './components/pages/error/error.component';
import { FaqComponent } from './components/pages/faq/faq.component';
import { PortfolioComponent } from './components/pages/portfolio/portfolio.component';
import { UserProfileComponent } from './components/pages/user-profile/user-profile.component';
import { InvoiceComponent } from './components/pages/invoice/invoice.component';
import { ChatComponent } from './components/pages/chat/chat.component';
import { EmailComponent } from './components/pages/email/email.component';
import { TodoListComponent } from './components/pages/todo-list/todo-list.component';

@NgModule({
  declarations: [
    AppComponent,
    PreloaderComponent,
    SideNavbarComponent,
    TopNavbarComponent,
    HomeComponent,
    MenuCatalogueComponent,
    MenuListComponent,
    MenuGridComponent,
    AddProductComponent,
    ProductDetailComponent,
    OrdersComponent,
    RestaurantsListComponent,
    AddRestaurantComponent,
    InvoiceDetailComponent,
    InvoiceListComponent,
    CustomersReviewComponent,
    CustomersListComponent,
    SocialActivityComponent,
    SalesComponent,
    WidgetsComponent,
    AccordionsComponent,
    AlertsComponent,
    ButtonsComponent,
    BreadcrumbsComponent,
    BadgesComponent,
    CardsComponent,
    ProgressBarsComponent,
    PreLoadersComponent,
    PaginationComponent,
    TabsComponent,
    TypographyComponent,
    DraggablesComponent,
    SlidersComponent,
    ModalsComponent,
    RatingComponent,
    TourComponent,
    CropperComponent,
    RangeSliderComponent,
    AnimationsComponent,
    FormElementsComponent,
    FormLayoutsComponent,
    FormValidationComponent,
    FormWizardComponent,
    ChartjsComponent,
    MorrisChartComponent,
    BasicTablesComponent,
    DataTablesComponent,
    SweetAlertsComponent,
    ToastComponent,
    FontawesomeComponent,
    FlaticonsComponent,
    MaterializeComponent,
    GoogleMapsComponent,
    VectorMapsComponent,
    WebAnalyticsComponent,
    StockManagementComponent,
    ClientManagementComponent,
    DefaultLoginComponent,
    ModalLoginComponent,
    DefaultRegisterComponent,
    ModalRegisterComponent,
    LockScreenComponent,
    ComingSoonComponent,
    ErrorComponent,
    FaqComponent,
    PortfolioComponent,
    UserProfileComponent,
    InvoiceComponent,
    ChatComponent,
    EmailComponent,
    TodoListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
