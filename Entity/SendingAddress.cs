using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class SendingAddress
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public short CurrencyId { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedOn { get; set; }
        public int ModifiedOn { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual Users User { get; set; }
    }
}
