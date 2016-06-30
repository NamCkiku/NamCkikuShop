/// <reference path="E:\_Study\_SourceCode\_SourseGithub\NamCkikuShop\NamCkikuShop.Web\Scripts/angular.js" />
(function () {
    angular.module("namckikuShop.productCategories", ['namckikuShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('productCategories', {
            url: "/productCategories",
            templateUrl: "/app/components/productCategories/productCategoryListView.html",
            controller: "productCategoryListController",
        }).state('addProductCategories', {
            url: "/addProductCategories",
            templateUrl: "/app/components/productCategories/productCategoryAddView.html",
            controller: "productCategoryAddController",
        });
    }
})();