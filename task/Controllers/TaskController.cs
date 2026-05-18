using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using task.Helpers.Security;
using task.Models;
using task.Services;
using task.Services.Impl;
using task.ViewModels;

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
            var identity = (ClaimsIdentity)User.Identity;

            var userId = identity
                .FindFirst(ClaimTypes.NameIdentifier)
                ?.Value;


            var taskList = await _taskService.GetTaskListByUserId(int.Parse(userId));

            List<TaskListViewModel> taskViewModel = _mapper.Map<List<TaskListViewModel>>(taskList);


            return View(taskViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterTask(TaskViewModel taskView)
        {
            Tasks task = _mapper.Map<Tasks>(taskView);

            await _taskService.Add(task);

            return Json(new
            {
                success = true,
                message = "cadastrado com sucesso"
            });
        } 
    }
}