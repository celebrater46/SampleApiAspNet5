using SampleApiAspNet5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
// using System.Web.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleApiAspNet5.Controllers
{
    public class MembersController : ControllerBase
    {
        Member[] members = new Member[]
        {
            new Member { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Member { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Member { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        public IEnumerable<Member> GetAllProducts()
        {
            return members;
        }

        // public IHttpActionResult GetProduct(int id)
        [HttpPost]
        // public ActionResult<Member>(int id)
        public async Task<ActionResult<Member>>PostMember(Member member)
        {
            // var member = members.FirstOrDefault((p) => p.Id == id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
            // return Ok(member);
        }
        // {
        //     _context.Employees.Add(employee);
        //     await _context.SaveChangesAsync();
        //
        //     return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        // }
    }
}