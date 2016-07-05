/// <reference path="E:\_Study\_SourceCode\_SourseGithub\NamCkikuShop\NamCkikuShop.Web\Scripts/angular.js" />
(function () {
    angular.module("namckikuShop.product", ['namckikuShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product', {
            url: "/product",
            parent: 'base',
            templateUrl: "/app/components/products/productListView.html",
            controller: "productListController",
        }).state('product_add', {
            url: "/product_add",
            parent: 'base',
            templateUrl: "/app/components/products/productAddView.html",
            controller: "productAddController",
        }).state('product_update', {
            url: "/product_update/:id",
            parent: 'base',
            templateUrl: "/app/components/products/productEditView.html",
            controller: "productEditController",
        });
    }
})();