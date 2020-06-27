<template>
    <div v-if="IsAdmin">
        <section id="description" class="card">
            <div class="card-header">
                <h4 class="card-title">Description</h4>
            </div>
            <div class="card-content">
                <div class="card-body">
                    <div class="card-text">
                        <p>
                            The dark layout has a semi dark color navbar, dark navigation menu and light footer. In this page you can experience it. If you want to create a semi dark version template you can use this layout. For admin panels this
                            layout provide elegant UI.
                        </p>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <div v-else>
        <Soon />
    </div>

    <!--
    <img alt="Vue logo" src="../assets/logo.png">
    <HelloWorld msg="Welcome to Your Vue.js App"/>
    -->
</template>

<script>
    import Soon from '@/components/Soon.vue'

    export default {
        name: 'Home',
        components: {
            Soon
        },
        data() {
            return {
                IsAdmin: true
            }
        }
    }
</script>
