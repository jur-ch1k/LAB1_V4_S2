using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1_V4_S2_CLASSES {
    public abstract class V4Data : IEnumerable<DataItem> {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public V4Data(string name, DateTime date) {
            Name = name;
            Date = date;
        }
        public abstract float MaxAbsValue { get; }
        public abstract string ToLongString(string format);
        public override string ToString() => $"Name = {Name}\nDate = {Date}";

        //----------------------Lab2----------------------//
        public abstract IEnumerator<DataItem> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
