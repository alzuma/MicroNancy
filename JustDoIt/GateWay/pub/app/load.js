(function (global) {

    var map = {
        'app': '/app', // 'dist',
        '@angular': 'lib/@angular'
    };

    var packages = {
        'app': { main: 'main.js',  defaultExtension: 'js' }
    };

    var ngPackageNames = [
        'common',
        'compiler',
        'core',
        'forms',
        'http',
        'platform-browser',
        'platform-browser-dynamic',
        'router',
        'router-deprecated',
        'upgrade',
    ];

    function packUmd(pkgName) {
        packages['@angular/'+pkgName] = { main: '/bundles/' + pkgName + '.umd.js', defaultExtension: 'js' };
    }

    var setPackageConfig = packUmd;
    ngPackageNames.forEach(setPackageConfig);

    var config = {
        map: map,
        packages: packages
    };

    System.config(config);
})(this);