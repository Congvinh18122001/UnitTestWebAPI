using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectLib.Object;
using System.Data;
namespace ProjectAPI.Controllers
{
    [Route("api/Members")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersRepository _repo;
        public MembersController(IMembersRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("GetAllMembers")]
        public List<Member> GetAllMembers()
        {
            return _repo.GetMembers();
        }

        [HttpGet("GetMember/{id}")]
        public HttpStatusCode GetMember(int id)
        {
            var member = _repo.GetMemberById(id);
            if (member != null){
                return HttpStatusCode.OK;
            }else{
                return HttpStatusCode.NotFound;
            }
        }
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }

        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}