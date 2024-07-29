using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.DeleteCommand;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class NoteController : BaseController
    {
        //маппер для преобразования входных данных в команду 
        //внедрение как зависимости через конструктор
        private readonly IMapper _mapper;

        public NoteController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //получение всех заметок
        [HttpGet] //атрибут гет запроса
        public async Task<ActionResult<NoteListVm>> GetAll()
        {
            //запрос к медиатору, а ответ клиенту
            var query = new GetNoteListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        //получение деталей заметки по айди заметки
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteListVm>> Get(Guid id)
        {
            var query = new GetNoteDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        //создание заметки
        //from body - указывает что параметр метода контроллера должен быть извлечен из данных тела хттп запроса
        //десериализован при помощи форматоров входных данных 
        //по умолчанию json
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteDto createNoteDto)
        {
            var command = _mapper.Map<CreateNoteCommand>(createNoteDto);

            command.UserId = UserId;

            var noteId = await Mediator.Send(command);

            return Ok(noteId);

        }
        
        //изменение заметки
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateNoteDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateNoteCommand>(updateNoteDto);

            command.UserId = UserId;

            await Mediator.Send(command);

            return NoContent();
        }

        //удаление заметки
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteNoteCommand
            {
                Id = id,
                UserId = UserId
            };

            await Mediator.Send(command);

            return NoContent();
        }

    }
}
