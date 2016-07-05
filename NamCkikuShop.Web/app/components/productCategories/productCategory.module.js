/// <reference path="E:\_Study\_SourceCode\_SourseGithub\NamCkikuShop\NamCkikuShop.Web\Scripts/angular.js" />
(function () {
    angular.module("namckikuShop.productCategories", ['namckikuShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('productCategories', {
            url: "/productCategories",
            parent: 'base',
            templateUrl: "/app/components/productCategories/productCategoryListView.html",
            controller: "productCategoryListController",
        }).state('addProductCategories', {
            url: "/addProductCategories",
            parent: 'base',
            templateUrl: "/app/components/productCategories/productCategoryAddView.html",
            controller: "productCategoryAddController",
        }).state('editProductCategories', {
            url: "/editProductCategories/:id",
            parent: 'base',
            templateUrl: "/app/components/productCategories/productCategoryEditView.html",
            controller: "productCategoryEditController",
        });
    }
})();