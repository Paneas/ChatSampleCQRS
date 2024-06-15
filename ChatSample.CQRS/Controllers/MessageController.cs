using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChatSample.CQRS.Commands.Messages;
using ChatSample.CQRS.Model.DTO;
using ChatSample.CQRS.Model.Requests;
using ChatSample.CQRS.Queries.Messages;

namespace ChatSample.CQRS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPost]
        [Route("AddMessage")]
        public async Task<IResult> AddMessage(SendMessageRequest request)
        {
            AddMessageCommand query = new AddMessageCommand(request.FromUser, request.ToUser, request.Body);

            var res = await _sender.Send(query);

            return Results.Ok(MessageDTO.ToDto(res));
        }

        [HttpGet]
        [Route("GetMessages")]
        public async Task<IResult> GetMessages(Guid from, Guid to)
        {
            GetMessagesOfDriver getMessages = new GetMessagesOfDriver(from, to);

            var res = await _sender.Send(getMessages);

            return Results.Ok(res);
        }
    }
}
