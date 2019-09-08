using System;

namespace Entity
{
    public partial class KycInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AdhaarNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public string PanNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Users User { get; set; }
    }
}
