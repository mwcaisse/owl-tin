using System;
using System.Collections.Generic;
using System.Text;
using OwlTin.Common.Entities;

namespace OwlTin.Authentication.Entities
{
    public partial class UserRegistrationKey : ITrackedEntity
    {
        public long UserRegistrationKeyId { get; set; }
        public string Key { get; set; }
        public int UsesRemaining { get; set; }
        public bool Active { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<UserRegistrationKeyUse> UserRegistrationKeyUses { get; set; }
    }
}
