using System;
using AutoMapper;
using Common.Interfaces;
using Organizer.Domain.Entities;
using Organizer.UI.Web.Models.ViewModels;

namespace Organizer.UI.Web.Mapping
{
    /// <summary>
    /// Маппер задачи во вью-модель задачи и обратно
    /// </summary>
    public class TaskMapper : ICommonMapper<Task, TaskViewModel>
    {
        private readonly MapperConfiguration _config;
        private readonly IMapper _mapper;

        public TaskMapper()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Task, TaskViewModel>());
            _config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Task, TaskViewModel>();
                cfg.CreateMap<TaskViewModel, Task>();
            });
            _mapper = _config.CreateMapper();
        }

        public TaskViewModel MapEntityToModel(Task task)
        {
            return _mapper.Map<TaskViewModel>(task);
        }

        public Task MapModelToEntity(TaskViewModel model)
        {
            return _mapper.Map<Task>(model);
        }

        public TaskViewModel MapEntityToModel(Task task, TaskViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task MapModelToEntity(TaskViewModel model, Task task)
        {
            throw new NotImplementedException();
        }
    }
}