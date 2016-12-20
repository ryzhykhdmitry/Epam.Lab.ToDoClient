angular.module("Repository", [])
    .service("TodoItemsService", ["$http", function ($http) {
        return {
            getAll: function () {
                return $http.get("/api/ToDos");
            },

            getById: function (id) {
                return $http.get("/api/ToDos/" + id);
            },

            addItem: function (item) {
                return $http.post("/api/ToDos/", item);
            },

            removeItem: function (id) {
                return $http.delete("/api/ToDos/" + id);
            },

            updateItem: function (item) {
                return $http.put("/api/ToDos", item);
            }
        };
    }]);