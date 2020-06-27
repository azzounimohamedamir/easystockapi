<template>
   <nav class="header-navbar navbar-expand-md navbar navbar-with-menu fixed-top navbar-semi-dark">
        <div class="navbar-wrapper">
            <div class="navbar-header">
                <ul class="nav navbar-nav flex-row">
                    <li class="nav-item mobile-menu d-md-none mr-auto"><a class="nav-link nav-menu-main menu-toggle hidden-xs" href="#"><i class="feather icon-menu font-large-1"></i></a></li>
                    <li class="nav-item">
                        <a class="navbar-brand" href="/">
                            <h4 class="brand-text">Smart Restaurant</h4>
                        </a>
                    </li>
                    <li class="nav-item d-md-none"><a class="nav-link open-navbar-container" data-toggle="collapse" data-target="#navbar-mobile"><i class="fa fa-ellipsis-v"></i></a></li>
                </ul>
            </div>
            <div class="navbar-container content">
                <div class="collapse navbar-collapse" id="navbar-mobile">
                    <ul class="nav navbar-nav mr-auto float-left">
                        <li class="nav-item d-none d-md-block"><a class="nav-link nav-menu-main menu-toggle hidden-xs" href="#"><i class="feather icon-menu"></i></a></li>
                    </ul>
                    <ul class="nav navbar-nav float-right">
                        <li class="dropdown dropdown-user nav-item">
                            <a class="dropdown-toggle nav-link dropdown-user-link" href="#" data-toggle="dropdown" aria-expanded="false">
                                <div class="avatar avatar-online">
                                    <img src="https://massive.mpcthemes.net/wp-content/uploads/2016/02/avatar03.jpg" alt="avatar">
                                    <i></i>
                                </div>
                                <span class="user-name">Amine</span>
                            </a>
                            <div class="dropdown-menu dropdown-menu-right"><a class="dropdown-item" href="user-profile.html"><i class="feather icon-user"></i> Edit Profile</a><a class="dropdown-item" href="app-email.html"><i class="feather icon-mail"></i> My Inbox</a>
                                <a class="dropdown-item" href="user-cards.html"><i class="feather icon-check-square"></i> Task</a><a class="dropdown-item" href="app-chat.html"><i class="feather icon-message-square"></i> Chats</a>
                                <div class="dropdown-divider"></div><a class="dropdown-item" href="login-with-bg-image.html"><i class="feather icon-power"></i> Logout</a>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </nav>
</template>

<script>
    export default {
        name: 'TopNav'
    }
</script>