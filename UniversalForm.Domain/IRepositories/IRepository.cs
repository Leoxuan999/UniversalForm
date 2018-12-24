using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UniversalForm.Domain.IRepositories
{
    /// <summary>
    /// 仓储模式
    /// </summary>
    public interface IRepository
    {
    }
    /// <summary>
    /// 仓储泛型接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IRepository<TEntity,TPrimaryKey> : IRepository where TEntity : Entity<TPrimaryKey>
    {

        /// <summary>
        /// 获得所有集合
        /// </summary>
        /// <returns></returns>
        List<TEntity> GetAllList();

        /// <summary>
        /// 根据 lambda表达式条件获取实体集合
        /// </summary>
        /// <param name="prodicate">lambda表达式条件</param>
        /// <returns></returns>
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> prodicate);

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="Id">主键</param>
        /// <returns></returns>
        TEntity GetModel(TPrimaryKey Id);

        /// <summary>
        /// 根据 lambda 表达式获取实体
        /// </summary>
        /// <param name="prodicate"></param>
        /// <returns></returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> prodicate);

        /// <summary>
        /// 添加一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="autoSave">是否立即执行</param>
        /// <returns></returns>
        TEntity Insert(TEntity entity, bool autoSave = true);

        /// <summary>
        /// 更新一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="autoSave">是否立即执行</param>
        /// <returns></returns>
        TEntity Update(TEntity entity, bool autoSave = true);        

        /// <summary>
        /// 新增或者更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="autoSave">是否立即执行</param>
        /// <returns></returns>
        TEntity InsertOrUpdate(TEntity entity, bool autoSave = true);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="Id">主键</param>
        /// <param name="autoSave">是否立即执行</param>
        /// <returns></returns>
        bool Delete(TPrimaryKey Id, bool autoSave = true);

        /// <summary>
        /// 根据 lambda 表达式删除
        /// </summary>
        /// <param name="where"></param>
        /// <param name="autoSave"></param>
        void Delete(Expression<Func<TEntity, bool>> where, bool autoSave = true);

        /// <summary>
        /// 分页数据获取
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数量</param>
        /// <param name="rowCount">数据总数</param>
        /// <param name="where">查询条件</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        IQueryable<TEntity> LoadPageList(int pageIndex, int pageSize, out int rowCount, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> order);

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        bool Save();
    }

    /// <summary>
    /// 主键默认为Guid的仓储泛型接口
    /// </summary>
    /// <typeparam name="TEntity">泛型</typeparam>
    public interface IRepositry<TEntity> : IRepository<TEntity,Guid> where TEntity : Entity
    {

    }
}
