
using System;

namespace VirtualVendingMachine.Domain
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            DateCreated = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public int Version { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
