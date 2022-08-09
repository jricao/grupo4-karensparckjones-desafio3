using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models;
using WoMakersCode.ToDoList.Core.Entities;
using WoMakersCode.ToDoList.Core.Filters;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases
{
    public class GetByIdUseCase : IUseCaseAsync<GetFilter, GetByIdResponse>
    {
        public readonly ITaskListRepository _repository;
        public readonly IMapper _mapper;

        public GetByIdUseCase(ITaskListRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public  Task<GetByIdResponse> ExecuteAsync(GetFilter filter)
        {
            var resposta = _repository.GetById(filter).Result;

            var response = (GetByIdResponse)null;

            if (resposta != null)
            {
                response = _mapper.Map<GetByIdResponse>(resposta);
            }

            return Task.FromResult(response);

        }

        

        //public Task<TaskDetail> ExecuteAsync(int request)
        //{
        //    var resultado = _todoListRepository.GetTaskDetails(request);
        //    List<TaskDetail> listas = new List<TaskDetail>();
        //    if (listas.Any() == true)                          //se tem algum elemento na lista,retorna a lista
        //        resultado = new List<TaskDetail>();
        //    else
        //        resultado = null;

        //    return (Task<TaskDetail>)resultado; //pq precisaria ser assim?
        //}


    }
}
