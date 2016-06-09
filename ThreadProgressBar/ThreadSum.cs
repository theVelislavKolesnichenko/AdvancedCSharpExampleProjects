using System.Collections.Generic;

namespace ThreadProgressBar
{
    public class ThreadSum
    {
        private List<int> listInt_1;
        private List<int> listInt_2;
        private List<int> listInt_3;

        public string Result
        {
            get
            {
                return string.Join<int>(";", listInt_3);
            }

        }

        public ThreadSum(List<int> listInt_1, List<int> listInt_2)
        {
            this.listInt_1 = new List<int>();
            this.listInt_1.AddRange(listInt_1);
            this.listInt_2 = new List<int>();
            this.listInt_2.AddRange(listInt_2);
        }

        public void Sum()
        {
            this.listInt_3 = new List<int>();
            for(int i = 0; i < this.listInt_1.Count; i++)
            {
                this.listInt_3.Add(this.listInt_1[i] + this.listInt_2[i]);
            }
        }
    }
}
