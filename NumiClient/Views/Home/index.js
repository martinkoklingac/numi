import $ from 'jquery';
import Vue from 'vue';

import './index.scss';
import Widget from './Widget.vue';

//$(document).ready(function () {
//    console.log("-> index.js");
//    $(".some-test").append($("<div>SOME TEST</div>"));
//});

let x = new Vue({
    el: "#_vueContext",
    components: {
        'widget':Widget
    },
    created: function () {
        console.log("-> vue created");
    }
});
