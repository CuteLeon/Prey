using Prey.DataAccess;
using Prey.Models;

namespace Prey.Services
{
    /// <summary>
    /// 人员服务
    /// </summary>
    public class PersonService : PersistServiceBase<Person>, IPersonService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService"/> class.
        /// </summary>
        /// <param name="context"></param>
        public PersonService(DBContext context)
            : base(context)
        {
        }
    }
}
