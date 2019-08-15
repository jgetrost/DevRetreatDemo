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
    // static class to keep track of how many clients are connected.
    public static class UserHandler
    {
        // in this case its just a list of clients, but it could also be a dictionary mapping signlar clients to user ids.
        public static HashSet<string> ConnectedIds = new HashSet<string>();
    }

    // private container to hold the database that gets injected
    private StrengthsContext _strengthsContext;
    
    // public constructor that pulls in the injected database
    public StrengthsHub(StrengthsContext strengthsContext)
    {
        this._strengthsContext = strengthsContext;
    }

    // event that fires on every user connected to the signalr hub
    public override Task OnConnectedAsync()
    {
        // add their connection to the static list
        UserHandler.ConnectedIds.Add(Context.ConnectionId);
        
        // fire the method that tells all the users how many people are currently connected (the ui shows a reactive counter for demonstration purposes)
        this.UpdateCount();
        
        // send the new user the current dataset
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
            // send each object to just the client that connected
            Clients.Caller.SendAsync("broadcastUser", _user);
        }
        
        // bubble up to the base method
        return base.OnConnectedAsync();
    }
    public void Send(Strengths.Shared.Models.User user)
    {
        // reusable method to send an object to all clients over ws
        Clients.All.SendAsync("broadcastUser", user);
    }
    
    public void UpdateCount(){
        // send the new count of how many users are online to the all the clients.
        Clients.All.SendAsync("broadcastCount", UserHandler.ConnectedIds.Count);
    }

    // handles getting a user from the client over ws, then upserts them, and send the information back to all the clients through a reusable method.
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

    // event handler for any user disconnecting
    public override Task OnDisconnectedAsync(System.Exception exception)
    {
        // remove the users connection id from the static list
        UserHandler.ConnectedIds.Remove(Context.ConnectionId);
        
        // send the users the lates count
        this.UpdateCount();
        
        bubble up to the base method
        return base.OnDisconnectedAsync(exception);
    }
}
}
