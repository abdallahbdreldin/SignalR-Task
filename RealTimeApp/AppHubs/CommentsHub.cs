using Microsoft.AspNetCore.SignalR;

namespace RealTimeApp.AppHubs
{
    public class CommentsHub : Hub
    {
        public async Task JoinProductGroup(string productId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"product-{productId}");
        }

        public async Task SendComment(string productId, string comment)
        {
            await Clients.Group($"product-{productId}").SendAsync("NewCommentNotification", comment);
        }
    }
}
