using System;

namespace Library.Mongo
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}