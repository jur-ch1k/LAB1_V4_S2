using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LAB1_V4_S2_CLASSES {
    public struct DataItem {
        public float Coord { get; set; }
        public float[] val = new float[2];
        public DataItem(float coord, float x, float y) {
            Coord = coord;
            val[0] = x;
            val[1] = y;
        }
        public string ToLongString(string format) {
            return "coord = " + Coord.ToString() +
                " Val1 = " + val[0].ToString(format) +
                " Val2 = " + val[1].ToString(format);
        }
        public override string ToString() => $"coord = {Coord} Val1 = {val[0]} Val2 = {val[1]}";
    };
}
