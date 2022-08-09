using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models;
using WoMakersCode.ToDoList.Core.Entities;
using WoMakersCode.ToDoList.Core.Repositories;
using WoMakersCode.ToDoList.Infra.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases
{
    public class InsertTodoListUseCase : IUseCaseAsync<TaskListRequest, InsertToDoListResponse>
    {
        private readonly ITaskListRepository _repository;
        private readonly IMapper _mapper;

        public InsertTodoListUseCase(ITaskListRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<InsertToDoListResponse> ExecuteAsync(TaskListRequest request)
        {
            var resp = await _repository.GetById(new Core.Filters.GetFilter { Pesquisa = request.ListName });

            if (resp == null)
            {
                var taskList = _mapper.Map<TaskList>(request);
                await _repository.Insert(taskList);
                return new InsertToDoListResponse();
            }
            else
                return null;
        }
        //public Task<TaskListResponse> ExecuteAsync(TaskListRequest request)
        //{
        //    var taskList = _mapper.Map<TaskList>(request);
        //    //CRIAR VARIÁVEL QUE DIZ AO CONTROLLER SE É IGUAL OU NÃO. nO CONTROLLER CASO NÃO SEJA, INSERE A LISTA
        //    var resposta = _todoListRepository.Inserir(taskList);
        //    var response = (TaskList)null;
        //    //se request(objeto do tipo TLRq ?) !=
        //    //if (request.ListName.Equals(TaskListResponse))
        //    if (resposta != TaskListResponse.ListName)//como comparar com o nome de outras listas já inseridas? PARA VERIFICAR SE É DIFERENTE?
        //        response = new TaskListResponse
        //        {
        //            Id = resposta.Id,
        //            ListName = resposta.ListName
        //        };

        //    return Task.FromResult(response);
        //}
    }
}
