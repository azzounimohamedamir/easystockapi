import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
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



const routes: Routes = [

{path: '', component: ComingSoonComponent},
{path: 'home', component: HomeComponent},
{path: 'menu-catalogue', component: MenuCatalogueComponent},
{path: 'menu-list', component: MenuListComponent},
{path: 'menu-grid', component: MenuGridComponent},
{path: 'add-product', component: AddProductComponent},
{path: 'product-detail', component: ProductDetailComponent},
{path: 'order', component: OrdersComponent},
{path: 'restaurant-list', component: RestaurantsListComponent},
{path: "add-restaurant", component : AddRestaurantComponent},
{path: 'invoice-detail', component: InvoiceDetailComponent},
{path: 'invoice-list', component: InvoiceListComponent},
{path: 'customer-review', component: CustomersReviewComponent},
{path: 'customer-list', component: CustomersListComponent},
{path: 'social-activity', component: SocialActivityComponent},
{path: 'sales', component: SalesComponent},
{path: 'widgets', component: WidgetsComponent},
{path: 'accordions', component: AccordionsComponent},
{path: 'alerts', component: AlertsComponent},
{path: 'buttons', component: ButtonsComponent},
{path: 'breadcrumbs', component: BreadcrumbsComponent},
{path: 'cards', component: CardsComponent},
{path: 'progress-bars', component: ProgressBarsComponent},
{path: 'preloaders', component: PreLoadersComponent},
{path: 'pagination', component: PaginationComponent},
{path: 'tabs', component: TabsComponent},
{path: 'typography', component: TypographyComponent},
{path: 'draggable', component: DraggablesComponent},
{path: 'sliders', component: SlidersComponent},
{path: 'modals', component: ModalsComponent},
{path: 'rating', component: RatingComponent},
{path: 'tour', component: TourComponent},
{path: 'cropper', component: CropperComponent},
{path: 'range-sliders', component: RangeSliderComponent},
{path: 'animation', component: AnimationsComponent},
{path: 'form-elements', component: FormElementsComponent},
{path: 'form-layouts', component: FormLayoutsComponent},
{path: 'form-validation', component: FormValidationComponent},
{path: 'form-wizard', component: FormWizardComponent},
{path: 'chartjs', component: ChartjsComponent},
{path: 'morris-chart', component: MorrisChartComponent},
{path: 'basic-table', component: BasicTablesComponent},
{path: 'data-table', component: DataTablesComponent},
{path: 'sweet-alert', component: SweetAlertsComponent},
{path: 'toast', component: ToastComponent},
{path: 'fontawesome', component: FontawesomeComponent},
{path: 'flaticons', component: FlaticonsComponent},
{path: 'materialize', component: MaterializeComponent},
{path: 'google-map', component: GoogleMapsComponent},
{path: 'vector-map', component: VectorMapsComponent},
{path: 'web-analytics', component: WebAnalyticsComponent},
{path: 'stock-management', component: StockManagementComponent},
{path: 'client-management', component: ClientManagementComponent},
{path: 'login', component: DefaultLoginComponent},
{path: 'modal-login', component: ModalLoginComponent},
{path: 'register', component: DefaultRegisterComponent},
{path: 'modal-register', component: ModalRegisterComponent},
{path: 'lock-screen', component: LockScreenComponent},
{path: 'coming-soon', component: ComingSoonComponent},
{path: 'error-404', component: ErrorComponent},
{path: 'faq', component: FaqComponent},
{path: 'portfolio', component: PortfolioComponent},
{path: 'user-profile', component: UserProfileComponent},
{path: 'invoice', component: InvoiceComponent},
{path: 'chat', component: ChatComponent},
{path: 'email', component: EmailComponent},
{path: 'to-do-list', component: TodoListComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
