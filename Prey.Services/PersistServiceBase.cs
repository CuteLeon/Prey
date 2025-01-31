﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Prey.DataAccess;

namespace Prey.Services
{
    /// <summary>
    /// 数据持久化服务基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <remarks>
    /// 同步方法通过 System.Linq 内的 IQueryable<> 接口调用
    /// 服务基类封装 DbSet 和 QueryableExtensions 提供的方法
    /// </remarks>
    public abstract class PersistServiceBase<TEntity> : IPersistService<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersistServiceBase{TEntity}"/> class.
        /// </summary>
        /// <param name="context"></param>
        public PersistServiceBase(DBContext context)
        {
            this.Context = context;
            this.Database = this.Context.Database;
        }

        #region 属性

        /// <summary>
        /// Gets or sets 日志
        /// </summary>
        public Action<string> Log { get; set; }

        /// <summary>
        /// Gets 数据库交互
        /// </summary>
        public DbContext Context { get; }

        /// <summary>
        /// Gets 数据库
        /// </summary>
        public DatabaseFacade Database { get; }
        #endregion

        #region 增加

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual TEntity Add(TEntity entity)
        {
            var result = this.Context.Set<TEntity>().Add(entity);
            this.Context.SaveChanges();
            return result.Entity;
        }

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual int AddRange(IEnumerable<TEntity> entities)
        {
            this.Context.Set<TEntity>().AddRange(entities);
            return this.Context.SaveChanges();
        }
        #endregion

        #region 删除

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual TEntity Remove(TEntity entity)
        {
            var result = this.Context.Set<TEntity>().Remove(entity);
            this.Context.SaveChanges();
            return result.Entity;
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual int RemoveRange(IEnumerable<TEntity> entities)
        {
            this.Context.Set<TEntity>().RemoveRange(entities);
            return this.Context.SaveChanges();
        }
        #endregion

        #region 加载

        /// <summary>
        /// 加载
        /// </summary>
        public virtual void Load()
            => this.Context.Set<TEntity>().Load();

        /// <summary>
        /// 加载
        /// </summary>
        /// <returns></returns>
        public virtual Task LoadAsync()
            => this.Context.Set<TEntity>().LoadAsync();
        #endregion

        #region 遍历

        /// <summary>
        /// 全部
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<bool> AllAsync(Expression<Func<TEntity, bool>> expression)
            => this.Context.Set<TEntity>().AllAsync(expression);

        /// <summary>
        /// 任一
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
            => this.Context.Set<TEntity>().AnyAsync(expression);

        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual Task ForEachAsync(Action<TEntity> action)
            => this.Context.Set<TEntity>().ForEachAsync(action);
        #endregion

        #region 极值

        /// <summary>
        /// 最大值
        /// </summary>
        /// <typeparam name="TResult">结果类型</typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<TResult> MaxAsync<TResult>(Expression<Func<TEntity, TResult>> expression)
            => this.Context.Set<TEntity>().MaxAsync(expression);

        /// <summary>
        /// 最小值
        /// </summary>
        /// <typeparam name="TResult">结果类型</typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<TResult> MinAsync<TResult>(Expression<Func<TEntity, TResult>> expression)
            => this.Context.Set<TEntity>().MinAsync(expression);
        #endregion

        #region 计数

        /// <summary>
        /// 计算数量
        /// </summary>
        /// <returns></returns>
        public virtual Task<int> CountAsync()
            => this.Context.Set<TEntity>().CountAsync();

        /// <summary>
        /// 计算数量
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
            => this.Context.Set<TEntity>().CountAsync(expression);
        #endregion

        #region 包含

        /// <summary>
        /// 包含
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Task<bool> ContainsAsync(TEntity entity)
            => this.Context.Set<TEntity>().ContainsAsync(entity);
        #endregion

        #region 主键查询

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        /// <remarks>Find 方法会优先在内存中搜索是否存在已经缓存的实体，内存中不存在时才会查询数据库</remarks>
        public virtual TEntity Find(params object[] keys)
            => this.Context.Set<TEntity>().Find(keys);

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public virtual Task<TEntity> FindAsync(params object[] keys)
            => this.Context.Set<TEntity>().FindAsync(keys).AsTask();
        #endregion

        #region 单值查找

        /// <summary>
        /// 第一个元素
        /// </summary>
        /// <returns></returns>
        public virtual Task<TEntity> FirstAsync()
            => this.Context.Set<TEntity>().FirstAsync();

        /// <summary>
        /// 第一个元素
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> expression)
            => this.Context.Set<TEntity>().FirstAsync(expression);

        /// <summary>
        /// 第一个或默认元素
        /// </summary>
        /// <returns></returns>
        public virtual Task<TEntity> FirstOrDefaultAsync()
            => this.Context.Set<TEntity>().FirstOrDefaultAsync();

        /// <summary>
        /// 第一个或默认元素
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
            => this.Context.Set<TEntity>().FirstOrDefaultAsync(expression);

        /// <summary>
        /// 唯一的元素
        /// </summary>
        /// <returns></returns>
        public virtual Task<TEntity> SingleAsync()
            => this.Context.Set<TEntity>().SingleAsync();

        /// <summary>
        /// 唯一的元素
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> expression)
            => this.Context.Set<TEntity>().SingleAsync(expression);

        /// <summary>
        /// 唯一的或默认元素
        /// </summary>
        /// <returns></returns>
        public virtual Task<TEntity> SingleOrDefaultAsync()
            => this.Context.Set<TEntity>().SingleOrDefaultAsync();

        /// <summary>
        /// 唯一的或默认元素
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
            => this.Context.Set<TEntity>().FirstOrDefaultAsync(expression);
        #endregion

        #region SQL

        /// <summary>
        /// SQL 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> SqlQuery(string sql, params object[] parameters)
            => this.Context.Set<TEntity>().FromSqlRaw(sql, parameters);

        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual int ExecuteSqlCommand(string sql, params object[] parameters)
            => this.Context.Database.ExecuteSqlRaw(sql, parameters);
        #endregion

        #region 集合转换

        /// <summary>
        /// 返回 IQueryable
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> AsQueryable()
            => this.Context.Set<TEntity>().AsQueryable();

        /// <summary>
        /// 返回 IEnumerable
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> AsEnumerable()
            => this.Context.Set<TEntity>().AsEnumerable();

        /// <summary>
        /// 返回 ParallelQuery
        /// </summary>
        /// <returns></returns>
        public virtual ParallelQuery<TEntity> AsParallel()
            => this.Context.Set<TEntity>().AsParallel();

        /// <summary>
        /// 返回数组
        /// </summary>
        /// <returns></returns>
        public virtual Task<TEntity[]> ToArrayAsync()
            => this.Context.Set<TEntity>().ToArrayAsync();

        /// <summary>
        /// 返回字典
        /// </summary>
        /// <typeparam name="TKey">字典键类型</typeparam>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public virtual Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey>(Func<TEntity, TKey> keySelector)
            => this.Context.Set<TEntity>().ToDictionaryAsync(keySelector);

        /// <summary>
        /// 返回列表
        /// </summary>
        /// <returns></returns>
        public virtual Task<List<TEntity>> ToListAsync()
            => this.Context.Set<TEntity>().ToListAsync();
        #endregion

        #region 跳跃取值

        /// <summary>
        /// 跳过
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Skip(int count)
            => this.Context.Set<TEntity>().Skip(count);

        /// <summary>
        /// 取值
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Take(int count)
            => this.Context.Set<TEntity>().Take(count);
        #endregion

        #region 累加

        /// <summary>
        /// 累加
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> expression)
            => this.Context.Set<TEntity>().SumAsync(expression);

        /// <summary>
        /// 累加
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<decimal?> SumAsync(Expression<Func<TEntity, decimal?>> expression)
            => this.Context.Set<TEntity>().SumAsync(expression);

        /// <summary>
        /// 累加
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<double> SumAsync(Expression<Func<TEntity, double>> expression)
            => this.Context.Set<TEntity>().SumAsync(expression);

        /// <summary>
        /// 累加
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<double?> SumAsync(Expression<Func<TEntity, double?>> expression)
            => this.Context.Set<TEntity>().SumAsync(expression);

        /// <summary>
        /// 累加
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<float> SumAsync(Expression<Func<TEntity, float>> expression)
            => this.Context.Set<TEntity>().SumAsync(expression);

        /// <summary>
        /// 累加
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<float?> SumAsync(Expression<Func<TEntity, float?>> expression)
            => this.Context.Set<TEntity>().SumAsync(expression);

        /// <summary>
        /// 累加
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<long> SumAsync(Expression<Func<TEntity, long>> expression)
            => this.Context.Set<TEntity>().SumAsync(expression);

        /// <summary>
        /// 累加
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<long?> SumAsync(Expression<Func<TEntity, long?>> expression)
            => this.Context.Set<TEntity>().SumAsync(expression);

        /// <summary>
        /// 累加
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<int> SumAsync(Expression<Func<TEntity, int>> expression)
            => this.Context.Set<TEntity>().SumAsync(expression);

        /// <summary>
        /// 累加
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<int?> SumAsync(Expression<Func<TEntity, int?>> expression)
            => this.Context.Set<TEntity>().SumAsync(expression);
        #endregion

        #region 平均值

        /// <summary>
        /// 平均值
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<decimal> AverageAsync(Expression<Func<TEntity, decimal>> expression)
            => this.Context.Set<TEntity>().AverageAsync(expression);

        /// <summary>
        /// 平均值
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<decimal?> AverageAsync(Expression<Func<TEntity, decimal?>> expression)
            => this.Context.Set<TEntity>().AverageAsync(expression);

        /// <summary>
        /// 平均值
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<double> AverageAsync(Expression<Func<TEntity, double>> expression)
            => this.Context.Set<TEntity>().AverageAsync(expression);

        /// <summary>
        /// 平均值
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<double?> AverageAsync(Expression<Func<TEntity, double?>> expression)
            => this.Context.Set<TEntity>().AverageAsync(expression);

        /// <summary>
        /// 平均值
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<float> AverageAsync(Expression<Func<TEntity, float>> expression)
            => this.Context.Set<TEntity>().AverageAsync(expression);

        /// <summary>
        /// 平均值
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<float?> AverageAsync(Expression<Func<TEntity, float?>> expression)
            => this.Context.Set<TEntity>().AverageAsync(expression);

        /// <summary>
        /// 平均值
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<double> AverageAsync(Expression<Func<TEntity, long>> expression)
            => this.Context.Set<TEntity>().AverageAsync(expression);

        /// <summary>
        /// 平均值
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<double?> AverageAsync(Expression<Func<TEntity, long?>> expression)
            => this.Context.Set<TEntity>().AverageAsync(expression);

        /// <summary>
        /// 平均值
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<double> AverageAsync(Expression<Func<TEntity, int>> expression)
            => this.Context.Set<TEntity>().AverageAsync(expression);

        /// <summary>
        /// 平均值
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual Task<double?> AverageAsync(Expression<Func<TEntity, int?>> expression)
            => this.Context.Set<TEntity>().AverageAsync(expression);
        #endregion

        #region 保存

        /// <summary>
        /// 保存变化
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
            => this.Context.SaveChanges();

        /// <summary>
        /// 保存变化
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync()
            => this.Context.SaveChangesAsync();
        #endregion

        #region 事务

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <typeparam name="TDelegate">委托类型</typeparam>
        /// <typeparam name="TResult">返回值类型</typeparam>
        /// <param name="delegate"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual TResult Transact<TDelegate, TResult>(TDelegate @delegate, params object[] parameters)
            where TDelegate : Delegate
        {
            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    var result = (TResult)@delegate.DynamicInvoke(parameters);

                    this.Context.SaveChanges();
                    transaction.Commit();

                    return result;
                }
                catch
                {
                    transaction.Rollback();

                    throw;
                }
            }
        }
        #endregion
    }
}
