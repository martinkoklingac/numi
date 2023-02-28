const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const VueLoaderPlugin = require('vue-loader/lib/plugin');

module.exports = {
    mode: 'development',    //production
    entry: {
        'home/index': './Views/Home/index.js',
        //'areas/security/register/index': './Areas/Security/Views/Register/index.js',
        //'areas/security/auth/login': './Areas/Security/Views/Auth/login.js'
    }
    ,
    output: {
        path: path.resolve(__dirname, 'wwwroot/dist'),
        filename: '[name].js'
    },
    resolve: {
        modules: [
            path.resolve(__dirname, 'App'),
            path.resolve(__dirname, 'node_modules')
        ],
        alias: {
            'vue$': 'vue/dist/vue.esm.js'
        }
    },
    plugins: [
        //extractCss,
        new MiniCssExtractPlugin({
            // Options similar to the same options in webpackOptions.output
            // both options are optional
            filename: '[name].css',
            chunkFilename: '[id].css',
        }),
        new VueLoaderPlugin()
    ],

    module: {
        rules: [
            {
                test: /\.vue$/,
                loader: 'vue-loader'
            },
            //{
            //    test: /\.js$/,
            //    loader: 'babel-loader'
            //},
            {
                test: /\.(sc|c)ss$/,
                use: [
                    MiniCssExtractPlugin.loader,
                    'css-loader',
                    'sass-loader'
                ]
            }
        ]
    }
};