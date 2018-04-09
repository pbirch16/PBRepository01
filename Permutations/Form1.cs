using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Permutations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        void GetPer(char[] acList)
        {
            int x = acList.Length - 1;
            GetPer(acList, 0, x);
        }

        void GetPer(char[] acList, int k, int m)
        {
            if (k == m)
            {
                Console.WriteLine(acList);
            }
            else
            {
                for (int i = k; i <= m; i++)
                {
                    Swap(ref acList[k], ref acList[i]);
                    GetPer(acList, k + 1, m);
                    Swap(ref acList[k], ref acList[i]);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string str = "ADNWO";
            string str = "ABCD";
            
            char[] acArr = str.ToCharArray();
            GetPer(acArr);
            Console.ReadKey();
        }
    }
}
