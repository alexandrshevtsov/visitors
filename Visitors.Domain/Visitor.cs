using System;

namespace Visitors.Domain
{
    public class Visitor: BaseEntity
    {
        public string Fullname { get; set; }

        public string Phone { get; set; }

        public DateTime LastEnterDate { get; set; }

        public DateTime CreateDate { get; set; }

        public string Comments { get; set; }
    }
}
