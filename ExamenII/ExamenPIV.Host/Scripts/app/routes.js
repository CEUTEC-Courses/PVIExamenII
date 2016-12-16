app.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/', {
                templateUrl: '/Scripts/app/home/home.template.html',
                controller: 'homeController'
            }).
            otherwise({
                redirectTo: '/'
            })
    }
]);