using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TempMonitoring
{
    public partial class CurveParas : Form
    {
        private DataProcess dp = new DataProcess();
        private bool TabStatus = false;
        public CurveParas()
        {
            InitializeComponent();
            InitListBox();
            cbmRNodeNumber.SelectedIndex = Consumer.LastNodeNum;
            cmbHNodeNumber.SelectedIndex = Consumer.LastNodeNum;           
        }
        private void InitListBox()
        {       
            if (tabControl1.SelectedIndex == 0)
            {              
                this.AddItem(listBox3, listBox4, "电压", Consumer.curve.V);
                this.AddItem(listBox3, listBox4, "电流", Consumer.curve.C);
                this.AddItem(listBox3, listBox4, "电阻", Consumer.curve.R);

                if (!Consumer.curve.T)
                {
                    this.listBox3.Items.Add("温度");
                }
                else
                {
                    this.listBox4.Items.Add("温度");
                }

                if (!Consumer.curve.H)
                {
                    this.listBox3.Items.Add("湿度");
                }
                else
                {
                    this.listBox4.Items.Add("湿度");
                }
            }

        }
        private void AddItem(ListBox Source,ListBox Dest, string str, bool[] val)
        {
            for (int i = 0; i < val.Length; i++)
            {
                if (!val[i])
                {
                    Source.Items.Add(str + (i + 1).ToString());
                }
                else
                {
                    Dest.Items.Add(str + (i + 1).ToString());
                }
            }
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex != -1)
            {
                while (this.listBox1.SelectedItems.Count > 0)
                {
                    int index = this.listBox1.Items.IndexOf(this.listBox1.SelectedItem);
                    string item = this.listBox1.SelectedItem.ToString();
                    this.listBox1.Items.RemoveAt(index);
                    this.listBox2.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("请先选中一项");
            }
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            if (this.listBox2.SelectedIndex != -1)
            {
                while (this.listBox2.SelectedItems.Count > 0)
                {
                    int index = this.listBox2.Items.IndexOf(this.listBox2.SelectedItem);
                    string item = this.listBox2.SelectedItem.ToString();
                    this.listBox2.Items.RemoveAt(index);
                    this.listBox1.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("请先选中一项");
            }
        }


        private void btnRA_Click(object sender, EventArgs e)
        {
            if (this.listBox3.SelectedIndex != -1)
            {
                while (this.listBox3.SelectedItems.Count > 0)
                {
                    int index = this.listBox3.Items.IndexOf(this.listBox3.SelectedItem);
                    string item = this.listBox3.SelectedItem.ToString();
                    this.listBox3.Items.RemoveAt(index);
                    this.listBox4.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("请先选中一项");
            }
        }

        private void btnRD_Click(object sender, EventArgs e)
        {
            if (this.listBox4.SelectedIndex != -1)
            {
                while (this.listBox4.SelectedItems.Count > 0)
                {
                    int index = this.listBox4.Items.IndexOf(this.listBox4.SelectedItem);
                    string item = this.listBox4.SelectedItem.ToString();
                    this.listBox4.Items.RemoveAt(index);
                    this.listBox3.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("请先选中一项");
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Form1.isOkbtn = false;
        }
        /// <summary>
        /// bubble sort
        /// </summary>
        /// <param name="val">input array</param>
        private void BubbleSort(ref int[] val)
        {
            int temp;
            int n = val.Length;
            for (int i = 0; i < n-1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (val[j] > val[j + 1])
                    {
                        temp = val[j];
                        val[j] = val[j + 1];
                        val[j + 1] = temp;
                    }
                }
            }
        }
        /// <summary>
        /// set true in the right listbox item
        /// </summary>
        /// <param name="val"></param>
        /// <param name="lb"></param>
        /// <param name="findStr"></param>
        private void SetTrue(ref bool[] val,ListBox lb,string findStr)
        {
            int[] SaveBackup = new int[7] { -1, -1, -1, -1, -1, -1, -1 };
            int[] Save;
            int index = 0;
            int count = 0;
            int n = lb.Items.Count;

            for (int i = 0; i < n; i++)// find items with certain string
            {
                string str = lb.Items[i].ToString();
                if (str.Substring(0, 2) == findStr)
                {
                    string str1 = str.Substring(str.Length - 1, 1);
                    SaveBackup[index++] = Int32.Parse(str1) - 1;
                    count++;
                }
            }
            Save = new int[count];
            for (int i = 0; i < Save.Length; i++)
            {
                Save[i] = SaveBackup[i];
            }
            this.SetFalse(val);
            for (int i = 0; i < val.Length; i++)
            {
                for (int j = 0; j < Save.Length; j++)
                {
                    if (i == Save[j])
                    {
                        val[i] = true;
                        break;
                    }                       
                }
            }       
                  
        }

        private void btnOK_Click(object sender, EventArgs e)
        {           
            if (tabControl1.SelectedIndex == 0)
            {
                int n = listBox4.Items.Count;
            
                this.SetTrue(ref Consumer.curve.V, listBox4, "电压");
                this.SetTrue(ref Consumer.curve.C, listBox4, "电流");
                this.SetTrue(ref Consumer.curve.R, listBox4, "电阻");
                
                for (int i = 0; i < n; i++)
                {
                    string str = listBox4.Items[i].ToString();
                    if (str == "温度")
                    {
                        Consumer.curve.T = true;
                        break;
                    }
                    else
                    {
                        Consumer.curve.T = false;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    string str = listBox4.Items[i].ToString();
                    if (str == "湿度")
                    {
                        Consumer.curve.H = true;
                        break;
                    }
                    else
                    {
                        Consumer.curve.H = false;
                    }
                }
                Consumer.curve.NodeNum = Int32.Parse(cbmRNodeNumber.Text);

            }// tab 0
            else if (tabControl1.SelectedIndex == 1)
            {
                int n = listBox2.Items.Count;
                
                this.SetTrue(ref Consumer.curve.V, listBox2, "电压");
                this.SetTrue(ref Consumer.curve.C, listBox2, "电流");
                this.SetTrue(ref Consumer.curve.R, listBox2, "电阻");

                for (int i = 0; i < n; i++)
                {
                    string str = listBox2.Items[i].ToString();
                    if (str == "温度")
                    {
                        Consumer.curve.T = true;
                        break;
                    }
                    else
                    {
                        Consumer.curve.T = false;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    string str = listBox2.Items[i].ToString();
                    if (str == "湿度")
                    {
                        Consumer.curve.H = true;
                        break;
                    }
                    else
                    {
                        Consumer.curve.H = false;
                    }
                }
                Consumer.PastDT = dp.SelectData(dtHSTime.Value, dtHETime.Value, Int32.Parse(cmbHNodeNumber.Text));
            }// tab 1
            Consumer.curve.isHistory = TabStatus;
            this.Close();
            Form1.isOkbtn = true;
        }
        
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 0)
            {
                TabStatus = false;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                this.AddItem(listBox1, listBox2, "电压", Consumer.curve.V);
                this.AddItem(listBox1, listBox2, "电流", Consumer.curve.C);
                this.AddItem(listBox1, listBox2, "电阻", Consumer.curve.R);

                if (!Consumer.curve.T)
                {
                    this.listBox1.Items.Add("温度");
                }
                else
                {
                    this.listBox2.Items.Add("温度");
                }

                if (!Consumer.curve.H)
                {
                    this.listBox1.Items.Add("湿度");
                }
                else
                {
                    this.listBox2.Items.Add("湿度");
                }
                TabStatus = true;
            }
        }

        private void SetFalse(bool[] val)
        {
            int n = val.Length;
            for (int i = 0; i < n; i++)
            {
                val[i] = false;
            }
        }
    }
}
