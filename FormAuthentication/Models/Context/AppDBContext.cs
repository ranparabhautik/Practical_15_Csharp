using FormAuthentication.Models.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FormAuthentication.Models.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() :base("name=MyConn")
        {

        }   
      public  DbSet<Users> users { get;set;  }
    }
}