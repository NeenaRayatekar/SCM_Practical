using NotesApp.Context;
using NotesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotesApp.Repository
{
    public class LoginRepository : ILogin
    {        
        public bool Userlogin(UserDetails model)
        {
            using (var context = new NotesDetailsEntities())
            {
                bool isValid = context.Users.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                return isValid;
            }
        }
    }
}