using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Pong.PongDbContext.Tables;
using System.Text.RegularExpressions;

namespace Pong.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IDbContextFactory<PongDbContext.PongDbContext> contextFactory;
        public MessageController(IDbContextFactory<PongDbContext.PongDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public class ServiceResponse<T>
        {
            public T? Response { get; set; }
        }


        [HttpPost("/addMessage")]
        public IActionResult AddMessage(string text, Guid id)
        {
            
            using var context = contextFactory.CreateDbContext();
            Messages message = new Messages
            {
                Id = Guid.NewGuid().ToString(),
                Text = text,
                IdUser = id.ToString()
            };
            context.Messages.Add(message);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("/getMessage")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<Message>))]
        public IActionResult GetMessage(Guid userId,Guid id)
        {
            using var context = contextFactory.CreateDbContext();
            var rawMessage = context.Messages
                .Where(x => x.Id == id.ToString()).FirstOrDefault();
            Message message = new Message
            {
                Id = rawMessage.Id,
                Text = rawMessage.Text,
                Status = 1
            };

            return Ok(new ServiceResponse<Message> { Response = message });
        }

        [HttpGet("/getMessageList")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<List<Message>>))]
        public IActionResult GetMessageList(Guid userId, Guid messageId)
        {
            using var context = contextFactory.CreateDbContext();
            var rawMessages = context.Messages
                .Where(x => x.IdUser == userId.ToString()).ToList();

            var messagesList = new List<Message>();
            foreach(var rawMessage in rawMessages)
            {
                var message = new Message
                {
                    Id = rawMessage.Id,
                    Text = rawMessage.Text,
                    Status = 1
                };
                messagesList.Add(message);
            }
            return Ok(new ServiceResponse<List<Message>> { Response = messagesList });
        }

        [HttpDelete("/deleteMessage")]
        public IActionResult DeleteMesage(Guid userId,Guid messageId)
        {
            using var context = contextFactory.CreateDbContext();
            var rawMessage = context.Messages
                .Where(x => x.Id == messageId.ToString()).FirstOrDefault();
            context.Messages.Remove(rawMessage);
            context.SaveChanges();
            return Ok();
        }
    }
}
