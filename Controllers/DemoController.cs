using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoDataAccess;

namespace WebAPIDemo.Controllers
{
    public class DemoController : ApiController
    {
        public IEnumerable<logintable> GetDetails()
        {
            using(BookListCrudEntities entities = new BookListCrudEntities())
            {
                return entities.logintables.ToList();
            }
        }

        public logintable GetDetails(int id)
        {
            using(BookListCrudEntities entities = new BookListCrudEntities())
            {
                return entities.logintables.FirstOrDefault(e => e.UserId == id);
            }
        }

        public void Post([FromBody]logintable LoginTable)
        {
            using(BookListCrudEntities entities = new BookListCrudEntities())
            {
                entities.logintables.Add(LoginTable);
                entities.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (BookListCrudEntities entities = new BookListCrudEntities())
            {
                entities.logintables.Remove(entities.logintables.FirstOrDefault(e => e.UserId == id));
                entities.SaveChanges();
            }
        }
    }
}
