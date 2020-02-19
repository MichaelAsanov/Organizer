angular.module("organizerApp")

    /**
     * Контроллер (вью-модель) для работы с задачами
     */
    .controller("taskController",  function($scope, taskService, $compile) {
        
        /**
        /* Загружает все задачи
         * @returns {} 
         */
        $scope.LoadTasks = function() {
                $scope.TasksAreLoading = true;
                $scope.TasksLoadingErrors = false;

                taskService.GetTasksAsync()
                    .then(function(tasks) {                     
                        $scope.Tasks = tasks;
                    })
                    .catch(function() {
                        $scope.TasksLoadingErrors = true;
                    })
                    .finally(function() {
                        $scope.TasksAreLoading = false;
                    });
            }

        //Загружаем задачи
        $scope.LoadTasks();


        /**
         * Помечает задачу как выполненную
         * @param {} task 
         * @returns {} 
         */
        $scope.MarkTaskAsCompleted = function(task) {
            task.MarkingAsCompleted = true;
            task.MarkingAsCompletedError = true;

            taskService.MarkTaskAsCompletedAsync(task)
                .then(function() {
                    task.Completed = true;
                })
                .catch(function() {
                    task.MarkingAsCompletedError = true;
                })
                .finally(function() {
                    task.MarkingAsCompleted = false;
                });
        }


        /**
        /* Удаляет задачу
         * @param {} taskId 
         * @returns {} 
         */
        $scope.DeleteTask = function(taskId) {
            $scope.TaskIsDeleting = true;
            $scope.TaskDeletingError = false;

            taskService.DeleteTaskAsync(taskId)
               .then(function () {
                   $("#del_task").modal("hide");

                   //Удаляем из массива задачу с заданным Id
                   $scope.Tasks = $scope.Tasks.filter(function (task) { return task.Id !== taskId; });

                })
               .catch(function () {
                   $scope.TaskDeletingError = true;
               })
               .finally(function () {
                   $scope.TaskIsDeleting = false;
               });
        }


        /**
         * Загружает контент в модальное окно
         * @param {} url 
         * @param {} modalWindowSelector 
         * @param {} contentElementSelector 
         * @returns {} 
         */
        $scope.LoadContentToModal = function (url, modalWindowSelector, contentElementSelector) {
            $.ajaxSetup({ cache: false });

            $.get(url, function(html) {
                var temp = $compile(html)($scope);
                
                angular.element(document.querySelector(contentElementSelector)).html("").append(temp);

                $(modalWindowSelector).modal({
                            backdrop: 'static',
                            keyboard: true
                        }, 'show');
            });            
        };

        /**
         * Берет объект задачи с формы и передает его в метод создания задачи сервиса 
         * @returns {} 
         */
        $scope.SubmitTask = function() {
            //Берем объект с формы
            var arrayFromForm = $("#add_task form").serializeArray();
            var task = {};
            arrayFromForm.forEach(function(item) {
                task[item.name] = item.value;
            });

            
            $scope.CreateTask(task);
        }

        /**
        /* Создает новую задачу
         * @param {} task 
         * @returns {} 
         */
        $scope.CreateTask = function(task) {
            $scope.TaskIsCreating = true;
            $scope.TaskCreatingError = false;

            //создаем задачу...
            taskService.CreateTaskAsync(task)

                .then(function (result) {

                    //если успешно,
                    if (result.success) {
                        //закрываем модальное окно
                        $("#add_task").modal("hide");
                        
                        //и добавляем задачу в локальный массив задач
                        $scope.Tasks.push(result.task);
                    } else {
                        //иначе перерисовываем форму ввода задачи
                        var html = result.htmlresponse;
                        var temp = $compile(html)($scope);

                        angular.element(document.querySelector("#add_task .modal-content")).html("").append(temp);
                    }
                })
                .catch(function(e) {
                    $scope.TaskCreatingError = true;
                })
                .finally(function() {
                    $scope.TaskIsCreating = false;
                });
        }
    });