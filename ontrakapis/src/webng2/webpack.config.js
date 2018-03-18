var environment = (process.env.NODE_ENV || "development").trim();

if (environment === "development") {
    module.exports = require("./webpack.config.dev.js");
} else {
    module.exports = require("./webpack.config.prod.js");
}

//var merge = require('webpack-merge');
//// Configuration in common to both client-side and server-side bundles
//var commonConfig = {
//    context: __dirname,
//    resolve: { extensions: ['', '.js', '.ts'] },
//    output: {
//        filename: '[name].js',
//        publicPath: '/dist/' // Webpack dev middleware, if enabled, handles requests for this URL prefix
//    },
//    module: {
//        loaders: [
//            { test: /\.ts$/, include: /ClientApp/, loaders: ['ts-loader?silent=true', 'angular2-template-loader'] },
//            { test: /\.html$/, loader: 'html-loader?minimize=false' },
//            { test: /\.css$/, loader: 'to-string-loader!css-loader' },
//            { test: /\.(png|jpg|jpeg|gif|svg)$/, loader: 'url-loader', query: { limit: 25000 } }
//        ]
//    }
//};


