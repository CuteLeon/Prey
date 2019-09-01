using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Prey.Models;
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
        /// 获取人员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return Enumerable.Range(1, 10).Select(index => new Person() { Name = $"人员-{index}", });
        }

        /// <summary>
        /// 获取人员
        /// </summary>
        /// <param name="name">搜索名称</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Person> Get(string name)
        {
            return Enumerable.Range(1, 10).Select(index => new Person() { Name = $"人员-{index}", });
        }

        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="id">人员 ID</param>
        /// <returns></returns>
        [HttpGet]
        public bool Delete(string id)
        {
            return true;
        }

        /// <summary>
        /// 创建人员
        /// </summary>
        /// <param name="person"></param>
        [HttpPost]
        public void Create([FromBody] Person person)
        {
        }

        /// <summary>
        /// 编辑人员
        /// </summary>
        /// <param name="person"></param>
        [HttpPost]
        public void Edit([FromBody] Person person)
        {
        }
    }
}
