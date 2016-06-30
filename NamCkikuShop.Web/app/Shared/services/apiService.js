/// <reference path="/Scripts/angular.js" />
(function (app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http'];

    function apiService($http) {
        return {
            get:get
        }
        function get(url, params, success, failure) {
            //authenticationService.setHeader();
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }
    }

})(angular.module('namckikuShop.common'));