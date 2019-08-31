using System.Collections.Generic;

namespace Prey.Models.Comparers
{
    /// <summary>
    /// 实体基类比较器
    /// </summary>
    /// <typeparam name="TEntityBase">实体基类类型</typeparam>
    public class EntityBaseComparer<TEntityBase> : IEqualityComparer<TEntityBase>
        where TEntityBase : EntityBase
    {
        /// <summary>
        /// 相等
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public virtual bool Equals(TEntityBase x, TEntityBase y)
            => string.Equals(x?.ID, y?.ID);

        /// <summary>
        /// 获取哈希
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual int GetHashCode(TEntityBase obj)
            => obj.GetHashCode();
    }
}
