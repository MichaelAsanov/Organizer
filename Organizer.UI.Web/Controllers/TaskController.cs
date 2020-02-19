using System.Web.Mvc;
using Common.Interfaces;
using Organizer.Domain.Entities;
using Organizer.Domain.Interfaces;
using Organizer.UI.Web.Filters;
using Organizer.UI.Web.Models.Validators;
using Organizer.UI.Web.Models.ViewModels;

namespace Organizer.UI.Web.Controllers
{
    /// <summary>
    /// Контроллер для работы с задачами
    /// </summary>
   [RequireHttps]  
   [JsonExceptionFilter]
    public class TaskController : BaseAdminController
    {
        #region Fields
        private readonly ITaskDbService _taskService;
        private readonly ICommonMapper<Task, TaskViewModel> _taskMapper;
        #endregion

        #region Ctor
        public TaskController(ITaskDbService taskService, ICommonMapper<Task, TaskViewModel> taskMapper, IValidationService validationService)
            :base(validationService)
        {
            _taskService = taskService;
            _taskMapper = taskMapper;
        }

        #endregion

        #region Members

        /// <summary>
        /// Возвращает главную страницу с задачами
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Возвращает список задач в формате JSON
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var tasks = _taskService.GetTasks();
            return Json(tasks, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Возвращает форму создания новой задачи
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Добавляет новую задачу
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]       
        public ActionResult Create(TaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var renderedView = RenderPartialViewToString("Create", model);
                return Json(new
                {
                    success = false,
                    htmlresponse = renderedView
                });
            }

            var task = _taskMapper.MapModelToEntity(model);
            _taskService.AddTask(task);
            return Json(new {success = true, task = task}, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Помечает задачу как выполненную
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult MarkAsCompleted(int id)
        {
            var task = _taskService.GetTaskById(id);
            _taskService.MarkTaskAsCompleted(task);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Возвращает форму удаления задачи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var task = _taskService.GetTaskById(id);
            return View(task);
        }

        /// <summary>
        /// Удаляет задачу
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _taskService.DeleteTask(id);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}