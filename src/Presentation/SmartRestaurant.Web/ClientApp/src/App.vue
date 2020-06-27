<template>
    <div v-if="IsAdmin">
        <TopNav />
        <SideNav />
        <div class="app-content content">
            <div class="content-overlay"></div>
            <div class="content-wrapper">
                <div class="content-body">
                    <router-view />
                    <div class="sidenav-overlay"></div>
                    <div class="drag-target"></div>
                </div>
            </div>
        </div>
        <footer />
    </div>
    <div v-else>
        <!--
        <div id="nav">
            <router-link to="/">Home</router-link> |
            <router-link to="/about">About</router-link>
        </div>
            -->
        <router-view />
    </div>
</template>

<script>
    import TopNav from '@/components/Dashboard/TopNav.vue'
    import SideNav from '@/components/Dashboard/SideNav.vue'
    import Footer from '@/components/Dashboard/Footer.vue'


    export default {
        name: 'app',
        components: {
            TopNav,
            SideNav,
            Footer
        },
        mounted() {
            if (this.IsAdmin) {
                document.body.className = 'vertical-layout vertical-menu 2-columns fixed-navbar';
            }
        },
        data() {
            return {
                IsAdmin: true
            }
        }
    }
</script>