using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models;
using WoMakersCode.ToDoList.Application.UseCases;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Mvc.Abstractions;
using WoMakersCode.ToDoList.Core.DTOs;
using WoMakersCode.ToDoList.Core.Entities;
using WoMakersCode.ToDoList.Core.Repositories;
using WoMakersCode.ToDoList.Core.Filters;

namespace WoMakersCode.ToDoList.Controllers
{
    [ApiController]
    [Route("api/todolist")]
    public class ToDoListController : ControllerBase
    {
        private readonly IUseCaseAsync<TaskListRequest, List<TaskListResponse>> _getAllUseCase;
        private readonly IUseCaseAsync<GetFilter, GetByIdResponse> _getByIdUseCase;
        private readonly IUseCaseAsync<TaskListRequest, InsertToDoListResponse> _insertTodoListUseCase;
        private readonly IUseCaseAsync<List<InsertAlarmRequest>, InsertAlarmResponse> _insertAlarmUseCase;
        private readonly IUseCaseAsync<TaskRequest, TaskResponse> _insertTaskDetailUseCase;
        private readonly IUseCaseAsync<string, WeatherDTO> _getWeatherForecastUseCase;


        public ToDoListController(IUseCaseAsync<TaskListRequest, List<TaskListResponse>> getAllUseCase,
            IUseCaseAsync<GetFilter, GetByIdResponse> getByIdUseCase,
            IUseCaseAsync<TaskListRequest, InsertToDoListResponse> insertTodoListUseCase,
            IUseCaseAsync<List<InsertAlarmRequest>, InsertAlarmResponse> insertAlarmUseCase,
            IUseCaseAsync<TaskRequest, TaskResponse> insertTaskDetailUseCase,
            IUseCaseAsync<string, WeatherDTO> getWeatherForecastUseCase)
        {
            _getAllUseCase = getAllUseCase;
            _getByIdUseCase = getByIdUseCase;
            _insertTodoListUseCase = insertTodoListUseCase;
            _insertAlarmUseCase = insertAlarmUseCase;
            _insertTaskDetailUseCase = insertTaskDetailUseCase;
            _getWeatherForecastUseCase = getWeatherForecastUseCase;
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<TaskListResponse>>> Get([FromQuery] TaskListRequest request)//poderia tirar a necessidade de parâmetro?
        {
            return await _getAllUseCase.ExecuteAsync(request);
        }

        [HttpGet("id")]
        public async Task<ActionResult<GetByIdResponse>> Get([FromQuery] GetFilter filter)
        {
            var response = await _getByIdUseCase.ExecuteAsync(filter);
            if (response == null)
                return new NotFoundObjectResult("Não encontrado");

            return new OkObjectResult(response);

        }

        [HttpPost]
        public async Task<ActionResult<InsertToDoListResponse>> Post([FromBody] TaskListRequest request)
        {
            var resposta = await _insertTodoListUseCase.ExecuteAsync(request);

            if (resposta != null)
                return Ok(resposta);
            else
                return new BadRequestObjectResult("Lista já existente");

        }

        [HttpPost("insertAlarm")]
        public async Task<ActionResult<InsertAlarmResponse>> PostMultiplus([FromBody] List<InsertAlarmRequest> request)
        {
            var resposta = await _insertAlarmUseCase.ExecuteAsync(request);
            return Ok(resposta);
        }

        
        [HttpPost("task")]//AQUI PRECISA: "Ajuste os retornos do controller para utilizar ActionResult."  
        public async Task<TaskResponse> PostTask([FromBody] TaskRequest request)
        {
            return await _insertTaskDetailUseCase.ExecuteAsync(request);
        }

        [HttpGet("weatherforcast")]
        public async Task<ActionResult<WeatherDTO>> GetWeatherForcast()
        {
            var response = await _getWeatherForecastUseCase.ExecuteAsync(string.Empty);

            return new OkObjectResult(response);
        }

        /* 
        private readonly ILogger<ToDoListController> _logger;
        private readonly IUseCaseAsync<TaskListRequest, TaskListResponse> _insertUseCase;
        private readonly IUseCaseAsync<int, TaskListResponse> _getUseCase;
        private readonly IUseCaseAsync<TaskRequest, TaskResponse> _insertTaskDetailUseCase;
        private readonly IUseCaseAsync<string, WeatherDTO> _getWeatherForecastUseCase;
        
       

        public ToDoListController(ILogger<ToDoListController> logger,
            IUseCaseAsync<TaskRequest, TaskResponse> insertTaskDetailUseCase,
            IUseCaseAsync<string, WeatherDTO> getWeatherForecastUseCase
        
        {
            _logger = logger;
            
            _insertTaskDetailUseCase = insertTaskDetailUseCase;
            _getWeatherForecastUseCase = getWeatherForecastUseCase;
           

        }*/

        //PRECISA: "Ajuste os retornos do controller para utilizar ActionResult."  
        //[HttpPost("task")]
        //public async Task<TaskResponse> PostTask([FromBody] TaskRequest request)
        //{
        //    return await _insertTaskDetailUseCase.ExecuteAsync(request);
        //}

        //[HttpGet("weatherforcast")]
        //public async Task<ActionResult<WeatherDTO>> GetWeatherForcast()
        //{
        //    var response = await _getWeatherForecastUseCase.ExecuteAsync(string.Empty);

        //    return new OkObjectResult(response);
        //}


    }

}

