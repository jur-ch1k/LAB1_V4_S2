using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1_V4_S2_CLASSES {
    public class V4DataList : V4Data {
        public List<DataItem> DataList { get; set; }
        public V4DataList(string name, DateTime date) : base(name, date) {
            DataList = new List<DataItem>();
        }

        public bool Add(float x, float v1, float v2) {
            foreach (DataItem item in DataList) {
                if (item.Coord == x)
                    return false;
            }
            DataList.Add(new DataItem(x, v1, v2));
            return true;
        }

        public int AddDefaults(int nItems, F2Float func) {
            int cnt = 0;
            Random random = new Random();
            for (int i = 0; i < nItems; i++) {
                //float coord = (float)random.NextDouble();
                float coord = (float)i;
                float[] val = func(coord);
                if (Add(coord, val[0], val[1])) {
                    cnt++;
                }
            }
            return cnt;
        }

        public override float MaxAbsValue {
            get {
                float[] maxarr = new float[DataList.Count];
                int i = 0;
                foreach (DataItem item in DataList) {
                    maxarr[i++] = Math.Max(Math.Abs(item.val[0]), Math.Abs(item.val[1]));
                }
                return maxarr.Max();
            }
        }

        public override string ToString() => "V4DataList: " + base.ToString() + $"{DataList.Count}";

        public override string ToLongString(string format) {
            string info = "";
            foreach (DataItem item in DataList) {
                info += $"\nCoord = {item.Coord.ToString(format)}, Comp1 = {item.val[0].ToString(format)}, Comp2 = {item.val[1].ToString(format)}";
            }
            return ToString() + info;
        }

        //----------------------Lab2----------------------//
        public override IEnumerator<DataItem> GetEnumerator() => DataList.GetEnumerator();
        //----------------------Lab1_S2-------------------//
        public void AddDefaults(int nItems, FuncEnum F) {
            
            for (int i = 0; i < nItems; i++) {
                float coord = i;
                float[] val = new float[2];

                if (F == FuncEnum.CreateLinGrid) {
                    val[0] = i;
                    val[1] = i;
                }
                else if (F == FuncEnum.CreateSqrGrid) {
                    val[0] = i * i;
                    val[1] = i * i;
                }
                
                if (!Add(coord, val[0], val[1])) {
                    throw new Exception();
                }

            }
        }
    }

    public delegate float[] F2Float(float x);

    public static class Del_Func {
        static public float[] CreateVals(float x) {
            return new float[2] { x, x };
        }
    }
}
