using MediatR;
using Microsoft.AspNetCore.SignalR;
using ChatSample.CQRS.Commands.Messages;
using ChatSample.CQRS.Model.Requests;
using ChatSample.CQRS.Queries.Messages;

namespace ChatSample.CQRS.Hubs
{
    public class ChatHub(ISender sender) : Hub
    {
        private readonly ISender _sender = sender;

        public async Task SendMessage(SendMessageRequest request)
        {

            AddMessageCommand addMessageCommand = new AddMessageCommand(request.FromUser,
                                                        request.ToUser, request.Body);

            var res = await _sender.Send(addMessageCommand);

            await Clients.All.SendAsync("ReceiveMessage", res);
        }

        public async Task<IResult> GetMessages(Guid from, Guid to)
        {
            GetMessagesOfDriver getMessages = new GetMessagesOfDriver(from, to);

            var res = await _sender.Send(getMessages);

            return Results.Ok(res);
        }
    }
}
