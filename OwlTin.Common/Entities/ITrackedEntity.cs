using System;

namespace OwlTin.Common.Entities
{
    public interface ITrackedEntity
    {
        DateTime CreateDate { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}