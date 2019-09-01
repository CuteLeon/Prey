using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Prey.Services;

namespace Prey.WebAPI.Controllers
{
    /// <summary>
    /// 人员控制器
    /// </summary>
    [ApiController]
    [Route("[Controller]/[Action]")]
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
            var count = this.PersonService.CountAsync().Result;
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Get with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
