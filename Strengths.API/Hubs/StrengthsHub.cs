namespace Strengths.API.Hubs {
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Strengths.API.Data;
using Strengths.Shared.Models;
public class StrengthsHub : Hub
{
    public static class UserHandler
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();
    }

    private StrengthsContext _strengthsContext;
    public StrengthsHub(StrengthsContext strengthsContext)
    {
        this._strengthsContext = strengthsContext;
    }

    public override Task OnConnectedAsync()
    {
        UserHandler.ConnectedIds.Add(Context.ConnectionId);
        this.UpdateCount();
        foreach(User _user in _strengthsContext.Users
                                .Include(u => u.Theme1)
                                    .ThenInclude(t => t.Domain)
                                .Include(u => u.Theme2)
                                    .ThenInclude(t => t.Domain)
                                .Include(u => u.Theme3)
                                    .ThenInclude(t => t.Domain)
                                .Include(u => u.Theme4)
                                    .ThenInclude(t => t.Domain)
                                .Include(u => u.Theme5)
                                    .ThenInclude(t => t.Domain))
        {
            Clients.Caller.SendAsync("broadcastUser", _user);
        }
        
        return base.OnConnectedAsync();
    }
    public void Send(Strengths.Shared.Models.User user)
    {
        Clients.All.SendAsync("broadcastUser", user);
    }

    public void UpdateCount(){
        Clients.All.SendAsync("broadcastCount", UserHandler.ConnectedIds.Count);
    }

    public void SendUser(Strengths.Shared.Models.User user){
        User _existingUser = _strengthsContext.Users.SingleOrDefault(u => u.FirstName == user.FirstName && u.LastName == user.LastName);
        if(_existingUser != null){
            _existingUser.Theme1 = _strengthsContext.Themes.Find(user.Theme1.Id);
            _existingUser.Theme2 = _strengthsContext.Themes.Find(user.Theme2.Id);
            _existingUser.Theme3 = _strengthsContext.Themes.Find(user.Theme3.Id);
            _existingUser.Theme4 = _strengthsContext.Themes.Find(user.Theme4.Id);
            _existingUser.Theme5 = _strengthsContext.Themes.Find(user.Theme5.Id);
            _strengthsContext.SaveChanges();
        }else{
            user.Id = 0;
            user.Theme1 = _strengthsContext.Themes.Include(t => t.Domain).SingleOrDefault(t => t.Id == user.Theme1.Id);
            user.Theme2 = _strengthsContext.Themes.Include(t => t.Domain).SingleOrDefault(t => t.Id == user.Theme2.Id);
            user.Theme3 = _strengthsContext.Themes.Include(t => t.Domain).SingleOrDefault(t => t.Id == user.Theme3.Id);
            user.Theme4 = _strengthsContext.Themes.Include(t => t.Domain).SingleOrDefault(t => t.Id == user.Theme4.Id);
            user.Theme5 = _strengthsContext.Themes.Include(t => t.Domain).SingleOrDefault(t => t.Id == user.Theme5.Id);
            _strengthsContext.Users.Add(user);
            _strengthsContext.SaveChanges();
        }

        this.Send(user);
    }

    public override Task OnDisconnectedAsync(System.Exception exception)
    {
        //Clients.All.SendAsync("broadcastMessage", "system", $"{Context.ConnectionId} left the conversation");
        UserHandler.ConnectedIds.Remove(Context.ConnectionId);
        this.UpdateCount();
        return base.OnDisconnectedAsync(exception);
    }
}
}
