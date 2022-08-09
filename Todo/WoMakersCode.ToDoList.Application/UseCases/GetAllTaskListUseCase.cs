using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases
{
    public class GetAllTaskListUseCase : IUseCaseAsync<TaskListRequest, List<TaskListResponse>>
    {
        private readonly ITaskListRepository _repository; 
        private readonly IMapper _mapper;

        public GetAllTaskListUseCase(ITaskListRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<TaskListResponse>> ExecuteAsync(TaskListRequest request)
        {
            var resp = await _repository.GetAll();
            var response = _mapper.Map<List<TaskListResponse>>(resp);

            return response;
        }
    }
}
