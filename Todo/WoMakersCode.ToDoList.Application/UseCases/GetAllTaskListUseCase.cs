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

        //public Task<TaskListResponse> ExecuteAsync(int request)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<TaskListResponse>> ExecuteAsync(TaskListRequest request)
        //{
        //    throw new NotImplementedException();
        //}
        //se lista vazia retornar nulo, se não retorna a lista

        /*public  Task<IEnumerable<TaskListResponse>> ExecuteAsync()
        {
            var resultado = _todoListRepository.GetLists();
            List<TaskListResponse> listas = new List<TaskListResponse>();
            if (listas.Any() == true)                          //se tem algum elemento na lista,retorna a lista
                resultado = new List<TaskListResponse>();
            else
                resultado = null;

            return resultado;

        }*/

        //public Task<IEnumerable<TaskListResponse>> ExecuteAsync(IEnumerable request)
        //{
        //    var resultado = _todoListRepository.GetLists();
        //    List<TaskListResponse> listas = new List<TaskListResponse>();
        //    if (listas.Any() == true)                          //se tem algum elemento na lista,retorna a lista
        //        resultado = new List<TaskListResponse>();
        //    else
        //        resultado = null;

        //    return resultado;
        //}

