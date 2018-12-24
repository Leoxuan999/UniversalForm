using System;

namespace UniversalForm.Domain
{
    /// <summary>
    /// 泛型实体基类
    /// </summary>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    public abstract class Entity<TPrimaryKey>
    {
        public virtual TPrimaryKey ID { get; set; }
    }

    /// <summary>
    /// 默认主键为Guid的实体基类，根据需要可以设置int
    /// </summary>
    public abstract class Entity : Entity<Guid>
    {

    }
}
