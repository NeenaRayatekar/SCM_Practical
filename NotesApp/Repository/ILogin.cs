using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesApp.Models;

namespace NotesApp.Repository
{
   public interface ILogin
    {
        bool Userlogin(UserDetails model);
    }
}
