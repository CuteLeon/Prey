using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prey.Services;

namespace Prey.WebAPI.Controllers
{
    /// <summary>
    /// 人员控制器
    /// </summary>
    [Route("[Controller]/[Action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        /// <summary>
        /// Gets 人员服务
        /// </summary>
        public IPersonService PersonService { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonController"/> class.
        /// </summary>
        /// <param name="personService"></param>
        public PersonController(IPersonService personService)
        {
            this.PersonService = personService;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Person
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
