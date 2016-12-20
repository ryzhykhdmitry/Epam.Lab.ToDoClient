angular.module("TodoApp", ["Repository"])
        .controller("TodoController", ["$scope", "TodoItemsService", function ($scope, service) {

            $scope.items = [];
            clearParams();

            initialize();

            $scope.addItem = function () {
                var obj = {
                    Name: $scope.name,
                    IsCompleted: $scope.isCompleted
                };

                clearParams();

                service.addItem(obj).then(function (response) {
                    $scope.items.push(cast(response.data));
                });
            };

            $scope.removeItem = function (index, item) {
                service.removeItem(item.id);
                $scope.items.splice(index, 1);
            };

            $scope.updateItem = function (item) {
                var obj = {
                    Id: item.id,
                    Name: item.name,
                    IsCompleted: item.isCompleted
                };

                service.updateItem(obj);
            };

            function clearParams() {
                $scope.name = "";
                $scope.isCompleted = "";
            }

            function cast(item) {
                return {
                    id: item.Id,
                    name: item.Name,
                    isCompleted: item.IsCompleted
                }
            }

            function initialize() {
                service.getAll().then(function (response) {
                    $scope.items = [];

                    if (response.data.length !== 0) {
                        for (var i = 0; i < response.data.length; i++) {
                            var obj = cast(response.data[i]);
                            $scope.items.push(obj);
                        }
                    }
                });

            };
        }]);