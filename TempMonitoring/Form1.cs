using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.IO;
using System.IO.Ports;

namespace TempMonitoring
{
    public partial class Form1 : Form
    {
        public static bool isOkbtn = false;
        private DataProcess dp;
        private NodeData nd;// 
        private CurveConfig curveDis;
        private Thread tPro;
        private Thread tCon;
        HoldIntegerSynchronized holdInteger;
        Producer pro;
        Consumer con;
        RS232 port = new RS232();

        public Form1()
        {
            //System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false; 
            InitializeComponent();
            
            dp = new DataProcess();//initiate database processing class
            nd = new NodeData()// initiate struct NodeData
            {
                Start=0x2F,
                NodeNumber = -1,
                Voltage = new float[7] { (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0 },
                Currency = new float[7] { (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0 },
                Resistor = new float[6] { (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0 },
                Temperature = (float)0.0,
                Humidity = (float)0.0,
                End = 0x0D,
                CRCValue = 0x00             
            };

            
            curveDis = new CurveConfig()
            {

            };

            holdInteger = new HoldIntegerSynchronized(15);//

            pro = new Producer(holdInteger);
            tPro = new Thread(new ThreadStart(pro.Produce));

            con = new Consumer(holdInteger, chart1, curveDis);
            tCon = new Thread(con.Consume);

            tPro.Start();
            tCon.Start();

            RS232.port = dp.SelectComParas();
            

        }
  
        
           
        //private bool isFirstForm=false;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Producer.PortClosing = true;
            //if ((!pro.IsComOpen) && isFirstForm)
            //{
            //    if(tPro.ThreadState==ThreadState.Suspended)
            //        tPro.Resume();
            //    if (tCon.ThreadState == ThreadState.Suspended)
            //        tCon.Resume();
            //}
            tPro.Abort();
            tCon.Abort();
        }

        
        private void 打开串口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RS232.IsComOpen)//open com
            {
                if (RS232.OpenCom())
                {
                    打开串口ToolStripMenuItem.Text = "关闭串口";
                }
                else
                {
                    return;
                }
            }
            else//close com
            {
                RS232.CloseCom();
                打开串口ToolStripMenuItem.Text = "打开串口";
            }
        }

        private void 修改chart参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurveParas frm = new CurveParas();
            frm.ShowDialog();
            if(isOkbtn)
            {
                HistroyFigureOut(Consumer.PastDT);
            }
            
        }

        /// <summary>
        /// voltage
        /// </summary>
        private Series[] seriesV = new Series[7];
        /// <summary>
        /// currency
        /// </summary>
        private Series[] seriesC = new Series[7];
        /// <summary>
        /// resistor
        /// </summary>
        private Series[] seriesR = new Series[6];
        /// <summary>
        /// temperature
        /// </summary>
        private Series seriesT;
        /// <summary>
        /// humidity
        /// </summary>
        private Series seriesH;

        private Legend[] lgdV = new Legend[7];
        private Legend[] lgdC = new Legend[7];
        private Legend[] lgdR = new Legend[6];
        private Legend lgdT;
        private Legend lgdH;

        /// <summary>
        /// history data figure
        /// </summary>
        private void HistroyFigureOut(DataTable dt)
        {
            
            if (Consumer.curve.isHistory)
            {
                if (dt.Rows.Count < 1)
                {
                    chart1.Titles["tNodeName"].Text = "未发现任何数据！";
                    return;
                }
                chart1.Series.Clear();
                chart1.Legends.Clear();
                chart1.Titles["tNodeName"].Text = "测量节点 " + Consumer.curve.NodeNum.ToString() + " 参数";
                for (int i = 0; i < 7; i++)
                {
                    if(Consumer.curve.V[i])
                    {
                        seriesV[i] = new Series("电压" + (i + 1).ToString());
                        seriesV[i].Points.DataBind(dt.AsEnumerable(), "DateTime", "Voltage"+i.ToString(), "");
                        SetSeries(seriesV[i]);
                        chart1.Series.Add(seriesV[i]);

                        lgdV[i] = new Legend(seriesV[i].Name);
                        SetLegend(lgdV[i]);
                        chart1.Legends.Add(lgdV[i]);

                        seriesV[i].Legend = lgdV[i].Name;

                    }
                }
                for(int i=0;i<7;i++)
                {
                    if(Consumer.curve.C[i])
                    {
                        seriesC[i] = new Series("电流" + (i + 1).ToString());
                        seriesC[i].Points.DataBind(dt.AsEnumerable(), "DateTime", "Currency" + i.ToString(), "");
                        SetSeries(seriesC[i]);
                        chart1.Series.Add(seriesC[i]);

                        lgdC[i] = new Legend(seriesC[i].Name);
                        SetLegend(lgdC[i]);
                        chart1.Legends.Add(lgdC[i]);

                        seriesC[i].Legend = lgdC[i].Name;
                    }
                }
                for(int i=0;i<6;i++)
                {
                    if(Consumer.curve.R[i])
                    {
                        seriesR[i] = new Series("电阻" + (i + 1).ToString());
                        seriesR[i].Points.DataBind(dt.AsEnumerable(), "DateTime", "Resistor" + i.ToString(), "");
                        SetSeries(seriesR[i]);
                        chart1.Series.Add(seriesR[i]);

                        lgdR[i] = new Legend(seriesR[i].Name);
                        SetLegend(lgdR[i]);
                        chart1.Legends.Add(lgdR[i]);

                        seriesR[i].Legend = lgdR[i].Name;
                    }
                }
                if(Consumer.curve.T)
                {
                    seriesT = new Series("温度");
                    seriesT.Points.DataBind(dt.AsEnumerable(), "DateTime", "Temperature", "");
                    SetSeries(seriesT);
                    chart1.Series.Add(seriesT);

                    lgdT = new Legend(seriesT.Name);
                    SetLegend(lgdT);
                    chart1.Legends.Add(lgdT);

                    seriesT.Legend = lgdT.Name;
                }

                if (Consumer.curve.H)
                {
                    seriesH = new Series("湿度");
                    seriesH.Points.DataBind(dt.AsEnumerable(), "DateTime", "Humidity", "");
                    SetSeries(seriesH);
                    chart1.Series.Add(seriesH);

                    lgdH = new Legend(seriesH.Name);
                    SetLegend(lgdH);
                    chart1.Legends.Add(lgdH);

                    seriesH.Legend = lgdH.Name;
                }
            }          
        }

        private void SetLegend(Legend ll)
        {
            int n = chart1.Legends.Count;
            float w = 9;

            ll.Position.Auto = false;
            ll.Position = new ElementPosition(chart1.ChartAreas[0].Position.Width, 5 * n, w, 5);
        }

        private void SetSeries(Series ss)
        {
            ss.XValueType = ChartValueType.Date;
            ss.ChartType = SeriesChartType.Line;
            ss.MarkerStyle = MarkerStyle.Diamond;
            ss.MarkerSize = 10;
            ss.IsValueShownAsLabel = true;
        }

        private void 修改串口参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RS232.IsComOpen)
            {
                MessageBox.Show("关闭串口后配置串口参数！");
            }
            else
            {
                comParas frm = new comParas();
                //frm.MdiParent = this;
                frm.ShowDialog();
            }
        }

        private void 显示实时数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consumer.LastStatus = true;
            Consumer.curve.isHistory = false;
        }
    }
}
