
var require = {
    baseUrl: '../scripts',
    waitSecond: 0,
    paths: {
        'text': ['https://cdnjs.cloudflare.com/ajax/libs/require-text/2.0.12/text.min', 'requirejs/text'],
        'domReady': ['https://cdnjs.cloudflare.com/ajax/libs/require-domReady/2.0.1/domReady.min', 'requirejs/domReady'],
        'jquery': ['https://code.jquery.com/jquery-3.2.1.min', 'site/jquery.min'],
        'bootstrap': ['https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min', 'site/bootstrap.min'],
        'kendo.all.min': ['https://kendo.cdn.telerik.com/2017.2.621/js/kendo.all.min', 'site/kendo.all.min'],

        'RoomVm': ['RoomVm']
    },
    shim: {
        enforceDefine: true,
        'jquery': {
            exports: 'jquery'
        },
        'bootstrap': {
            deps: ['jquery'],
            exports: 'bootstrap'
        },
        
        'kendo.all.min': {
            deps: ['jquery'],
            exports: 'kendo.all.min'
        },
        'RoomVm': {
            deps: ['jquery', 'bootstrap', 'kendo.all.min'],
            exports: 'RoomVm'
        }
    }
};