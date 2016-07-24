/// <binding AfterBuild='angular' />
var gulp = require('gulp');

gulp.task('angular', function () {
    gulp.src([
        "node_modules/angular2/bundles/*.*",
        "node_modules/systemjs/dist/*.*",
        "node_modules/rxjs/bundles/*.*",
        "node_modules/reflect-metadata/Reflect.js",
        "node_modules/zone.js/dist/*.*"
    ])
    .pipe(gulp.dest("pub/lib/angular2"));
});

gulp.task('delfault', function () {

});