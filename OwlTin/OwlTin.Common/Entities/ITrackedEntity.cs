using System;

namespace Mitchell.Common.Entities
{
    public interface ITrackedEntity
    {
        DateTime CreateDate { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}