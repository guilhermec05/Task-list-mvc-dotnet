using AutoMapper;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using task.Domain.Models;
using task.Domain.ViewModels;
using task.Helpers.Security;
using task.Services.Impl;

namespace task.Controllers
{
    [CustomAuthorizeAttribute]
    public class TaskController : Controller
    {

        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public TaskController(IMapper mapper, ITaskService taskService)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        // GET: Task
        public async Task<ActionResult> Index()
        {
            var taskViewModel = await GetListTaskByUser();

            return View(taskViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterTask(TaskViewModel taskView)
        {
            Tasks task = _mapper.Map<Tasks>(taskView);

            if (taskView.Id == 0)
            {
                await _taskService.Add(task);

            }
            else
            {
                await _taskService.Update(task);
            }



            return Json(new
            {
                success = true,
                message = "Adicionado com sucesso"
            });


        }

        [HttpGet]
        public async Task<ActionResult> Edit(int taskId)
        {

            var task = await _taskService.GetTaskById(taskId);

            var taskViewModel = _mapper.Map<TaskViewModel>(task);

            return Json(new
            {
                success = true,
                data = taskViewModel
            }, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public async Task<ActionResult> Delete(int taskId)
        {

            await _taskService.Delete(taskId);


            return Json(new
            {
                success = true,
                data = "Removido com sucesso"
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public async Task<ActionResult> SearchTask(string search)
        {

            if (search == string.Empty)
            {
                var taskViewModelByUser = await GetListTaskByUser();

                return Json(new
                {
                    success = false,
                    data = taskViewModelByUser
                }, JsonRequestBehavior.AllowGet);
            }

            var tasks = await _taskService.GetTaskListByName(search);

            var taskViewModel = _mapper.Map<List<TaskListViewModel>>(tasks);

            return Json(
                new
                {
                    success = true,
                    data = taskViewModel,
                }, JsonRequestBehavior.AllowGet);
        }

        private async Task<List<TaskListViewModel>> GetListTaskByUser()
        {
            var identity = (ClaimsIdentity)User.Identity;

            var userId = identity
                .FindFirst(ClaimTypes.NameIdentifier)
                ?.Value;


            var taskList = await _taskService.GetTaskListByUserId(int.Parse(userId));

            List<TaskListViewModel> taskViewModel = _mapper.Map<List<TaskListViewModel>>(taskList);

            return taskViewModel;

        }


    }
}