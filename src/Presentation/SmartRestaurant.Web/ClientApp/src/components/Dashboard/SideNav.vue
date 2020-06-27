<template>
    <div class="main-menu menu-fixed menu-dark menu-accordion menu-shadow" data-scroll-to-active="true" style="touch-action: none; user-select: none; -webkit-user-drag: none; -webkit-tap-highlight-color: rgba(0, 0, 0, 0);">
        <div class="main-menu-content ps">
            <ul class="navigation navigation-main" id="main-menu-navigation" data-menu="menu-navigation">
                <li class="nav-item has-sub">
                    <a href="#"><i class="feather icon-home"></i><span class="menu-title">Restaurant</span></a>
                    <ul class="menu-content">
                        <li>
                            <a class="menu-item" href="#">Restaurant</a>
                            <a class="menu-item" href="#">Zones</a>
                            <a class="menu-item" href="#">Tables</a>
                        </li>
                    </ul>
                </li>
                <li class="nav-item has-sub">
                    <a href="#"><i class="feather icon-package"></i><span class="menu-title">Inventory</span></a>
                    <ul class="menu-content">
                        <li>
                            <a class="menu-item" href="#">Store</a>
                            <a class="menu-item" href="#">Vendor</a>
                            <a class="menu-item" href="#">Product</a>
                            <a class="menu-item" href="#">Purchase</a>
                            <a class="menu-item" href="#">Return</a>
                            <a class="menu-item" href="#">Transfer</a>
                            <a class="menu-item" href="#">Consumption</a>
                        </li>
                    </ul>
                </li>
                <li class="nav-item has-sub">
                    <a href="#"><i class="feather icon-book-open"></i><span class="menu-title">Menu</span></a>
                    <ul class="menu-content">
                        <li>
                            <a class="menu-item" href="#">Menu</a>
                            <a class="menu-item" href="#">Section</a>
                            <a class="menu-item" href="#">Sub section</a>
                            <a class="menu-item" href="#">Ingredient</a>
                            <a class="menu-item" href="#">Specification</a>
                            <a class="menu-item" href="#">Suplement</a>
                            <a class="menu-item" href="#">Dish</a>
                        </li>
                    </ul>
                </li>
                <li class=" nav-item">
                    <a href="#"><i class="feather icon-check-square"></i><span class="menu-title">Order</span></a>
                </li>
                <li class="nav-item has-sub">
                    <a href="#"><i class="feather icon-user"></i><span class="menu-title">Clients</span></a>
                    <ul class="menu-content">
                        <li>
                            <a class="menu-item" href="#">Clients</a>
                            <a class="menu-item" href="#">Billing</a>
                            <a class="menu-item" href="#">Reservation</a>
                        </li>
                    </ul>
                </li>
                <li class="nav-item has-sub">
                    <a href="#"><i class="feather icon-dollar-sign"></i><span class="menu-title">Cash</span></a>
                    <ul class="menu-content">
                        <li>
                            <a class="menu-item" href="#">Entry</a>
                            <a class="menu-item" href="#">Settlement</a>
                            <a class="menu-item" href="#">Drawer</a>
                        </li>
                    </ul>
                </li>
                <li class=" nav-item">
                    <a href="#"><i class="feather icon-users"></i><span class="menu-title">Users</span></a>
                </li>
                <li class=" nav-item">
                    <a href="#"><i class="feather icon-bookmark"></i><span class="menu-title">Subscription</span></a>
                </li>
                <li class=" nav-item">
                    <a href="#"><i class="feather icon-shield"></i><span class="menu-title">Illness</span></a>
                </li>
            </ul>
            <div class="ps__rail-x" style="left: 0px; bottom: 0px;"><div class="ps__thumb-x" tabindex="0" style="left: 0px; width: 0px;"></div></div><div class="ps__rail-y" style="top: 0px; right: 0px;"><div class="ps__thumb-y" tabindex="0" style="top: 0px; height: 0px;"></div></div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'SideNav'
    }
</script>