namespace Library.Mongo
{
    using System;

    /// <summary>
    /// Represents a mongo entoty.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the entity id.
        /// </summary>
        Guid Id { get; set; }
    }
}