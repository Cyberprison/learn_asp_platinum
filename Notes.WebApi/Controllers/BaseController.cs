using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace Notes.WebApi.Controllers
{
    [ApiController] //позволяет добавлять атрибут в новые контроллеры
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        //поля медиатор, для выполнения запросов
        private IMediator _mediator;

        //protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected IMediator Mediator;

        //поле айди пользователя
        internal Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
