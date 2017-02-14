'use strict';

angular.module('myApp.view1', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/view1', {
    templateUrl: 'view1/view1.html',
    controller: 'View1Ctrl'
  });
}])

.controller('View1Ctrl', function ($scope, $http) {
    $scope.GridOrderBy = function (x) {
        $scope.personalOrderBy = x;
    }
    $scope.Update = function (event) {
        var personId = $(event.target).data('id');
        $('#tr_' + personId).find('.EditView').show();
        $('#tr_' + personId).find('.displayValue').hide();
        $('#tr_' + personId).find('#btnBeforeUpdate').hide();
        $('#tr_' + personId).find('#btnInUpdate').show();

        $('input[name="FirstName"]').val($('#FirstNameVal_' + personId).html()).trigger('change');
        $('input[name="LastName"]').val($('#LastNameVal_' + personId).html()).trigger('change');
        $('input[name="JobTitle"]').val($('#JobTitleVal_' + personId).html()).trigger('change');
    }
    $scope.Cancel = function (event) {
        var personId = $(event.target).data('id');
        $('#tr_' + personId).find('.EditView').hide();
        $('#tr_' + personId).find('.displayValue').show();
        $('#tr_' + personId).find('#btnBeforeUpdate').show();
        $('#tr_' + personId).find('#btnInUpdate').hide();
    }

    $scope.Save = function (event) {
        var personId = $(event.target).data('id');
        var payload = $('#rowId' + personId).serialize() + "&Id=" + personId;
        var update = {
            method: 'PUT',
            url: window.WebApiHost  + 'Update',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            data: payload
        }

        $http(update).then(function () {
            $http.get( window.WebApiHost + "Get")
           .then(function (response) {
               $scope.personal = response.data;
               $('#tr_' + personId).find('.EditView').hide();
               $('#tr_' + personId).find('.displayValue').show();
               $('#tr_' + personId).find('#btnBeforeUpdate').show();
               $('#tr_' + personId).find('#btnInUpdate').hide();
           }
            , function errorCallback(response) {
                alert("An unexpected error occured.");
            });
        },function errorCallback(response) {
            alert("An unexpected error occured.");
        });
    }

    $http.get(window.WebApiHost  + "Get")
    .then(function (response) {
        $scope.personal = response.data;
    }, function errorCallback(response) {
        alert("An unexpected error occured.");
    });
});

