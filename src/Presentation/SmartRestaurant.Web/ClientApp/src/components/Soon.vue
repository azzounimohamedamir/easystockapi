<template>
    <div class="vertical-layout vertical-overlay-menu 1-column  comingsoonOne blank-page blank-page">
        <div class="app-content content">
            <div class="content-overlay"></div>
            <div class="content-wrapper">
                <div class="content-body">
                    <section class="flexbox-container">
                        <div class="col-12 d-flex align-items-center justify-content-center p-0">
                            <div class="col-sm-10 col-12 p-0">
                                <div class="card card-transparent box-shadow-0 border-0">
                                    <div class="card-content">
                                        <div class="text-center">
                                            <h5 class="card-text pb-2 white">WE ARE LAUNCHING SOON.</h5>
                                            <img src="/assets/img/logo.png" class="img-responsive block width-300 mx-auto" height="300" alt="bg-img">
                                            <br />
                                            <div class="col-12 pt-1">
                                                <p class="card-text lead white">Our website is under construction.</p>
                                            </div>
                                            <div class="col-12 text-center pt-2"> 
                                                <p class="socialIcon card-text">
                                                    <a href="#"><i class="fa fa-facebook-square white"></i></a>
                                                    <a href="#"><i class="fa fa-twitter-square white"></i></a>
                                                    <a href="#"><i class="fa fa-google-plus-square white"></i></a>
                                                    <a href="#"><i class="fa fa-linkedin-square white"></i></a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'Soon'
    }
</script>


<style>
    /*========== Coming Soon Background Image =========*/
    .comingsoonVideo .app-content .coming-soon-content {
        z-index: 99;
    }

    .clockCard {
        float: right;
        border-radius: 0.50rem;
    }

    .comingsoonOne {
        background-image: url("/assets/img/background.jpg");
        background-repeat: no-repeat;
        background-size: cover;
    }

    .getting-started {
        font-size: 2.4rem;
        border-radius: 60px;
        min-width: 360px;
    }

    .socialIcon i {
        font-size: 38px;
        padding: 5px;
    }

    .comingsoonFlat {
        background-image: url("/assets/img/background.jpg");
        background-repeat: no-repeat;
        background-size: cover;
    }
</style>