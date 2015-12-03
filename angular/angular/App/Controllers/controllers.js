

var testControllers = angular.module('testControllers', []);

testControllers.controller("homePageCtrl", function ($scope) {
    $scope.items = [
        { 'name': 'val1' },
        { 'name': 'val2' }
    ]
});