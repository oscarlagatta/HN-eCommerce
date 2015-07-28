var editCultureModule = angular.module('editCulture', ['common'])
        .config(function ($routeProvider, $locationProvider) {
            $routeProvider.when(eCommerce.rootPath + 'resourcemaster/editcultures', { templateUrl: eCommerce.rootPath + 'Templates/CultureList.html', controller: 'CurrentCultureViewModel' });
            $routeProvider.otherwise({ redirectTo: eCommerce.rootPath + 'resourcemaster/index' });
            $locationProvider.html5Mode(true);
        });

editCultureModule.controller("CultureViewModel", function ($scope, $window, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.resourceMasterModel = new eCommerce.ResourceMasterModel();

    $scope.previous = function () {
        $window.history.back();
    }
});

editCultureModule.controller('CurrentCultureViewModel', function ($scope,$http, $location, $window, viewModelHelper) {

    $scope.viewMode = 'culturelist'; // culturelist, success
    $scope.cultures = [];
    $scope.cultureKeys = [];
    $scope.init = false;
    $scope.initResources = false;

    $scope.availableCultures = function () {
        viewModelHelper.apiGet('api/resourcemaster/editCultures/', null,
               function (result) {
                   $scope.cultures = result.data;
                   $scope.init = true;
               });
    }

    //$scope.submitForm = function() {

    //    $scope.init = true;
    //    $scope.initResources = false;
    //    $scope.viewMode = 'success';
    //};

    $scope.cancelForm = function() {
        $scope.init = true;
        $scope.initResources = false;
    };
    
    $scope.submitResource = function (cultureKey) {
            var model = { ResourceId: cultureKey.ResourceId, Culture: cultureKey.Culture, Name: cultureKey.Name, Value: cultureKey.Value };
            
            viewModelHelper.apiPost('api/resourcemaster/updateresource', model,
               function (result) {
                   $scope.reservationNumber = result.data.ReservationId;
                   toastr.options.positionClass = 'toast-top-left';
                   toastr.options.extendedTimeOut = 0; 
                   toastr.options.timeOut = 1000;
                   toastr.options.fadeOut = 250;
                   toastr.options.fadeIn = 250;
                   toastr.success('Resource ' +result.data.Name + ' has been updated');
               });
    }

    $scope.selectCulture = function (culture) {
        viewModelHelper.apiGet('api/resourcemaster/cultureresources/' + culture, null, 
            function (result) {
                $scope.cultureKeys = result.data;
                $scope.init = false;
                $scope.initResources = true;
            });
    }

    $scope.availableCultures();
});

