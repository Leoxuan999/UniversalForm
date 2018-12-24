using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using UniversalForm.Domain;
using UniversalForm.Domain.IRepositories;

namespace UniversalForm.EF.Repositories
{
    public class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {

        protected readonly EFDBContext _dbcontext;

        public RepositoryBase(EFDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        /// <summary>
        /// 获取所有实体集合
        /// </summary>
        /// <returns></returns>
        public List<TEntity> GetAllList() => _dbcontext.Set<TEntity>().ToList();

        /// <summary>
        /// 根据条件获取实体集合
        /// </summary>
        /// <param name="prodicate"></param>
        /// <returns></returns>
        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> prodicate) => _dbcontext.Set<TEntity>().Where(prodicate).ToList();

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public TEntity GetModel(TPrimaryKey Id) => _dbcontext.Set<TEntity>().FirstOrDefault(CreateEqualityExpressionForId(Id));

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="prodicate"></param>
        /// <returns></returns>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> prodicate) => _dbcontext.Set<TEntity>().Where(prodicate).FirstOrDefault();
        
        /// <summary>
        /// 添加一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        public TEntity Insert(TEntity entity, bool autoSave = true)
        {
            _dbcontext.Set<TEntity>().Add(entity);
            if (autoSave)
                Save();            
            return entity;
        }

        /// <summary>
        /// 更新一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        public TEntity Update(TEntity entity, bool autoSave = true)
        {
            var obj = GetModel(entity.ID);
            EntityToEntity(entity, obj);
            if (autoSave)
                Save();
            return entity;            
        }

        /// <summary>
        /// 添加或更新一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        public TEntity InsertOrUpdate(TEntity entity, bool autoSave = true)
        {
            if (GetModel(entity.ID)!=null)
            {
                return Update(entity);
            }
            else
            {
                return Insert(entity);
            }            
        }

        /// <summary>
        /// 更新实体信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pTargetObjSrc">更新后实体内容</param>
        /// <param name="pTargetObjDest">待更新的实体</param>
        private void EntityToEntity<T>(T pTargetObjSrc, T pTargetObjDest)
        {
            foreach (var mItem in typeof(T).GetProperties())
            {
                mItem.SetValue(pTargetObjDest, mItem.GetValue(pTargetObjSrc, new object[] { }), null);
            }
        }

        
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        public bool Delete(TPrimaryKey Id, bool autoSave = true)
        {
            _dbcontext.Set<TEntity>().Remove(GetModel(Id));
            if (autoSave)
                return Save();
            return false;
        }


        /// <summary>
        /// 根据条件，批量删除数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="autoSave"></param>
        public void Delete(Expression<Func<TEntity, bool>> where, bool autoSave = true)
        {
            _dbcontext.Set<TEntity>().Where(where).ToList().ForEach(p => _dbcontext.Set<TEntity>().Remove(p));
            if (autoSave)
                Save();
        }

        
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public IQueryable<TEntity> LoadPageList(int pageIndex, int pageSize, out int rowCount, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> order)
        {
            var result = from p in _dbcontext.Set<TEntity>() select p;
            if (where != null)
                result = result.Where(where);
            if (order != null)
                result = result.OrderBy(order);
            else
                result = result.OrderBy(m => m.ID);
            rowCount = result.Count();
            return result.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public bool Save()
        {
            if (_dbcontext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 根据主键构建判断表达式
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));
            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TPrimaryKey))
                );
            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }

}
}
