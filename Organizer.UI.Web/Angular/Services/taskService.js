angular.module("organizerApp")

/**
 * Сервис для работы с задачами
*/
    .factory("taskService", function ($http, $q) {
        return {

            /**
            /* Возвращает список всех задач
             * @returns {} 
             */
            GetTasksAsync: function() {
                var deferred = $q.defer();

                $http.get("/Task/List", {})
                .then(function(tasksResponse) {
                        deferred.resolve(tasksResponse.data);
                     }, function (e) {
                    console.error(e);
                    deferred.reject();
                });

                return deferred.promise;
            },

            /**
             * Создает новую задачу
             * @param {} task 
             * @returns {} 
             */
            CreateTaskAsync : function(task) {
                var deferred = $q.defer();

                $http.post("/Task/Create", task)
                    .then(function (createTaskResponse) {
                        deferred.resolve(createTaskResponse.data);
                    }, function (e) {
                        console.error(e);
                        deferred.reject();
                    });

                return deferred.promise;
            },

            /**
            /* Помечает задачу как выполненную
             * @param {} task 
             * @returns {} 
             */
            MarkTaskAsCompletedAsync : function(task) {
                var deferred = $q.defer();

                $http.get("/Task/MarkAsCompleted",
                    {
                        params: { id: task.Id }
                    })
                .then(function (markTaskAsCompletedResponse) {
                    deferred.resolve(markTaskAsCompletedResponse.data);
                }, function (e) {
                    console.error(e);
                    deferred.reject();
                });

                return deferred.promise;
            },


            /**
            /* Удаляет задачу
             * @param {} task 
             * @returns {} 
             */
            DeleteTaskAsync : function(taskId) {
                var deferred = $q.defer();

                $http.post("/Task/Delete",
                        {
                             id: taskId
                        }
                    )
                .then(function (deleteRaskResponse) {
                    deferred.resolve(deleteRaskResponse.data);
                }, function (e) {
                    console.error(e);
                    deferred.reject();
                });

                return deferred.promise;
            }
        }
    });