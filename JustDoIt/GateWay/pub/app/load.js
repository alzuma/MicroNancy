(function (global) {
    var map = {
        'app': '/app'
    };
    var packages = {
        app: {
            defaultExtension: 'js'
        }
    };    
    var config = {
        map: map,
        packages: packages
    };
    System.config(config);
})(this);