<template>
    <div class="home">


        <Soon />

        <!--
        <img alt="Vue logo" src="../assets/logo.png">
        <HelloWorld msg="Welcome to Your Vue.js App"/>
        -->
    </div>
</template>

<script>
    import HelloWorld from '@/components/HelloWorld.vue'
    import Soon from '@/components/Soon.vue'

    export default {
        name: 'Home',
        components: {
            HelloWorld,
            Soon
        }
    }
</script>
