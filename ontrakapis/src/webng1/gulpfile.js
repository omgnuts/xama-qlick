/// <binding BeforeBuild='lib' />
"use strict";

let gulp = require("gulp"),
    series = require('stream-series'),
    inject = require('gulp-inject'),
    wiredep = require('wiredep').stream;

let webroot = "./wwwroot/";

let paths = {
    ngModule:       webroot + "app/**/*.module.js",
    ngRoute:        webroot + "app/**/*.route.js",
    ngService:      webroot + "app/**/*.service.js",
    ngController:   webroot + "app/**/*.controller.js",
    script:         webroot + "js/**/*.js",
    style:          webroot + "css/**/*.css"
};

gulp.task('injector', () => {
    let moduleSrc = gulp.src(paths.ngModule, { read: false });
    let routeSrc = gulp.src(paths.ngRoute, { read: false });
    let serviceSrc = gulp.src(paths.ngService, { read: false });
    let controllerSrc = gulp.src(paths.ngController, { read: false });
    let scriptSrc = gulp.src(paths.script, { read: false });
    let styleSrc = gulp.src(paths.style, { read: false });

    gulp.src(webroot + 'app/index.html')
        .pipe(wiredep({
            bowerJson: require('./bower.json'),
            directory: webroot + 'vendor/',
            optional: 'configuration',
            goes: 'here',
            ignorePath: '..',
            overrides: {
                angular: { main: ["angular.min.js"] },
                bootstrap: { main: ["dist/css/bootstrap.min.css", "dist/js/bootstrap.min.js"] },
                //"ng-table": { main: ["dist/ng-table.min.css", "dist/ng-table.min.js"] },
                jquery: { main: ["dist/jquery.min.js"] },
            }
        }))
        .pipe(inject(series(scriptSrc, moduleSrc, serviceSrc, controllerSrc, routeSrc), { ignorePath: '/wwwroot' }))
        .pipe(inject(series(styleSrc), { ignorePath: '/wwwroot' }))
        .pipe(gulp.dest(webroot + 'app'));
});