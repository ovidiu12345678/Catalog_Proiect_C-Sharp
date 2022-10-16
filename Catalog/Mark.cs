using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class Mark
    {
        private readonly UInt16 value;
        private readonly DateTime dateTime;
        private readonly Course course;

        public Mark(UInt16 value, DateTime dateTime,Course course)
        {
            this.value = value;
            this.dateTime = dateTime;
            this.course = course;
        }

        public UInt16 Value { get => value; }
        public DateTime DateTime { get => dateTime; }
        public Course Course { get => course; }

        public override String ToString()
        {
            return String.Format("Value : {0}, DateTime : {1}, Course : {2}\n\t", value, dateTime, course);
        }
    }
}
