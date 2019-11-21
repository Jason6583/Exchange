using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Log
    {
        public int Id { get; set; }
        public string ShortMessage { get; set; }
        public string LongMessage { get; set; }
        public DateTime CreatedOn { get; set; }
        public short LogLevel { get; set; }
    }
}
