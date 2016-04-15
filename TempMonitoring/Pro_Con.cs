using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.IO.Ports;
using System.Drawing;

namespace TempMonitoring
{

    public class HoldIntegerSynchronized
    {
        private NodeData[] buffer;// buffer zone of node data
        private int occupiedBufferCount = 0;
        private int readPosition = 0;// next position  reading data
        private int writePosition = 0;// next position writing data

        public HoldIntegerSynchronized(int capacity)
        {
            buffer = new NodeData[capacity];// define the length of buffer         
        }
        public HoldIntegerSynchronized()
        {
        }
        /// <summary>
        /// get buffer's length
        /// </summary>
        public int BufferSize
        {
            get
            {
                return buffer.Length;
            }
        }
        /// <summary>
        /// write and read data from buffer
        /// </summary>
        public NodeData Buffer
        {
            //read data from buffer
            get
            {
                NodeData bufferCopy;
                lock (this)
                {
                    while (occupiedBufferCount == 0)
                    {
                        Monitor.Wait(this);// if buffer is empty, all consumers wait 
                        //untill there are data in buffer
                    }
                    --occupiedBufferCount;//read once, occupiedBufferCount decrease 1
                    bufferCopy = buffer[readPosition];// get buffer value
                    readPosition = (readPosition + 1) % buffer.Length;//
                    Monitor.PulseAll(this);// let producers start to produce data 
                }//unlock
                return bufferCopy;
            }
            set
            {
                lock (this)
                {
                    while (occupiedBufferCount == buffer.Length)
                    {
                        Monitor.Wait(this);// if buffer is full, all producers stop producing data 
                        //untill data decreases
                    }
                    buffer[writePosition] = value;
                    ++occupiedBufferCount;
                    writePosition = (writePosition + 1) % buffer.Length;

                    Monitor.PulseAll(this);// let consumers start use data
                }
            }
        }

    }

    
    class Producer
    {
        private HoldIntegerSynchronized sharedLocation;
        private byte[] byt;      
        private NodeData nd;
        private const int bytelen = 102;

        //public static bool PortClosing = false;
        public Producer(HoldIntegerSynchronized shared)
        {
            sharedLocation = shared;

            byt = new byte[bytelen];
            nd = new NodeData()// initiate struct NodeData
            {
                Start = 0x2F,
                NodeNumber = -1,
                Voltage = new float[7] { (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0 },
                Currency = new float[7] { (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0 },
                Resistor = new float[6] { (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0 },
                Temperature = (float)0.0,
                Humidity = (float)0.0,
                End = 0x0D,
                CRCValue=0x00
            };
            

        }

        public void Produce()
        {
            while (true)
            {
                if (RS232.IsComOpen)
                {
                    //if (PortClosing) return;//if port is closing, stop receiveing data
                    try
                    {
                        if (RS232.bytesToread >= bytelen)
                        {
                            RS232.read(byt, 0, bytelen);


                            int start = BitConverter.ToInt32(byt, 0);
                            int end = BitConverter.ToInt32(byt, bytelen - 6);
                            int crcValue = CRCCheck.CRC_XModem(byt, bytelen - 2);

                            if (start == 0x2F && end == 0x0D && (crcValue == BitConverter.ToUInt16(byt, bytelen - 2)))
                            {
                                nd = (NodeData)NodeData.BytesToStuct(byt, nd.GetType());
                                sharedLocation.Buffer = nd;
                            }
                            else//if data is not correct this time, read all data in the buffer zone of com 
                            {   //and wait next 

                                RS232.readall();
                            }
                        }
                    }
                    catch
                    { }
                    finally
                    {
                        byt = new byte[bytelen];
                    }
                }
                else
                {

                }
                Thread.Sleep(RS232.port.Internal);
            }
        }

    }

    class Consumer
    {
        /// <summary>
        /// curve configration
        /// </summary>
        public static CurveConfig curve;
        /// <summary>
        /// datatable for saving past data
        /// </summary>
        public static System.Data.DataTable PastDT;
        /// <summary>
        /// this is used to make the history data displayed in the chart only one time
        /// default=false, false means it can display, true means it has displayed, is not allowed this time
        /// </summary>
        //public static bool isFisrtPresent=false;
        /// <summary>
        /// check if port is receiving data or not
        /// </summary>
        //public static bool PortListening = false;

        private HoldIntegerSynchronized sharedLocation;
        /// <summary>
        /// voltage
        /// </summary>
        private Series[] seriesV = new Series[7];
        /// <summary>
        /// currency
        /// </summary>
        private Series[] seriesC=new Series[7];
        /// <summary>
        /// resistor
        /// </summary>
        private Series[] seriesR=new Series[6];
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
        private Chart chart;
        private delegate void mydeledate(NodeData dat);
        private NodeData nd;
        private DataProcess dp;

        public Consumer(HoldIntegerSynchronized shared, Chart objChart, CurveConfig curveDis)
        {
            nd = new NodeData()// initiate struct NodeData
            {
                Start = 0x2F,
                NodeNumber = -1,
                Voltage = new float[7] { (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0 },
                Currency = new float[7] { (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0 },
                Resistor = new float[6] { (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0 },
                Temperature = (float)0.0,
                Humidity = (float)0.0,
                End = 0x0D,
                CRCValue = 0x00
            };
            curve = new CurveConfig()
            {
                isHistory=false,
                dtStart=DateTime.Now,
                dtEnd=DateTime.Now,
                dtPresent=DateTime.Today,
                NodeNum=0,
                V=new bool[7]{true,false,false,false,false,false,false},
                C = new bool[7] { true, false, false, false, false, false, false },
                R = new bool[6] { true, false, false, false, false, false },
                T=false,
                H=false
            };
            dp = new DataProcess();

            sharedLocation = shared;        
            chart = objChart;          
           
        }

        private int index = -1;
        public void Consume()
        {
            while (true)
            {          
                if (this.chart.IsHandleCreated)
                {
                    //try
                    {
                        //PortListening = true;//start invoke application
                        nd=(NodeData)sharedLocation.Buffer;
                        curve.dtPresent = DateTime.Now;
                        mydeledate my = RealtimeFigureOut;
                        chart.Invoke(my, new object[] {  nd });
                        dp.AddData(nd, curve.dtPresent);
                    }
                    //finally
                    {
                        //PortListening = false;//stop invoke application
                    }
                }
                               
                Thread.Sleep(RS232.port.Internal);
            }
        }
        /// <summary>
        /// default is false 
        /// false add V series to chart
        /// true add data to V series
        /// </summary>
        private bool[] isCreateV = new bool[7] { false, false, false, false, false, false, false };
        /// <summary>
        /// default is false 
        /// false add C series to chart
        /// true add data to C series
        /// </summary>
        private bool[] isCreateC = new bool[7] { false, false, false, false, false, false, false };
        /// <summary>
        /// default is false 
        /// false add R series to chart
        /// true add data to R series
        /// </summary>
        private bool[] isCreateR = new bool[6] { false, false, false, false, false, false };
        /// <summary>
        /// default is false 
        /// false add T series to chart
        /// true add data to T series
        /// </summary>
        private bool isCreateT = false;
        /// <summary>
        /// default is false 
        /// false add H series to chart
        /// true add data to H series
        /// </summary>
        private bool isCreateH = false;

        public static int LastNodeNum=0;
        public static bool LastStatus = false;
        private void RealtimeFigureOut(NodeData dat)
        {

            if (curve.isHistory == false)//real time data curve
            {
                if (index <= chart.ChartAreas[0].AxisX.ScaleView.Size + 1)
                    chart.ChartAreas[0].AxisX.ScaleView.Position = 1;
                else
                    chart.ChartAreas[0].AxisX.ScaleView.Position =
                        index - chart.ChartAreas[0].AxisX.ScaleView.Size - 1;
                if (curve.NodeNum != LastNodeNum || LastStatus) // initialize new node set
                {
                    InitAll();
                    LastStatus = false;
                }
                if (curve.NodeNum == dat.NodeNumber )   // display one certain node
                {
                    index++;
                    chart.Titles["tNodeName"].Text = "测量节点 " + curve.NodeNum.ToString() + " 参数";
                    for (int i = 0; i < 7; i++)
                    {
                        if (curve.V[i] && !(isCreateV[i]))//add
                        {
                            seriesV[i] = new Series("电压" + (i + 1).ToString());
                            SetSeries(seriesV[i]);// set property of series
                            chart.Series.Add(seriesV[i]);
                            seriesV[i].Points.AddXY(index, dat.Voltage[i]);

                            lgdV[i] = new Legend(seriesV[i].Name);
                            SetLegend(lgdV[i]);
                            chart.Legends.Add(lgdV[i]);

                            seriesV[i].Legend = lgdV[i].Name;

                            isCreateV[i] = true;
                            
                        }
                        else if (curve.V[i] && isCreateV[i])//display
                        {
                            seriesV[i].Points.AddXY(index, dat.Voltage[i]);
                        }
                        else if (!(curve.V[i]) && isCreateV[i])//remove series
                        {
                            chart.Series.Remove(seriesV[i]);
                            seriesV[i].Dispose();

                            chart.Legends.Remove(lgdV[i]);
                            lgdV[i].Dispose();

                            isCreateV[i] = false;

                            SetLegend();
                        }
                    }

                    for (int i = 0; i < 7; i++)
                    {
                        if (curve.C[i] && !(isCreateC[i]))//add
                        {
                            seriesC[i] = new Series("电流" + (i + 1).ToString());
                            SetSeries(seriesC[i]);// set property of series
                            chart.Series.Add(seriesC[i]);
                            seriesC[i].Points.AddXY(index, dat.Currency[i]);

                            lgdC[i] = new Legend(seriesC[i].Name);
                            SetLegend(lgdC[i]);
                            chart.Legends.Add(lgdC[i]);

                            seriesC[i].Legend = lgdC[i].Name;

                            isCreateC[i] = true;                          
                        }
                        else if (curve.C[i] && isCreateC[i])//display
                        {
                            seriesC[i].Points.AddXY(index, dat.Currency[i]);
                        }
                        else if (!(curve.C[i]) && isCreateC[i])//remove series
                        {
                            chart.Series.Remove(seriesC[i]);
                            seriesC[i].Dispose();

                            chart.Legends.Remove(lgdC[i]);
                            lgdC[i].Dispose();

                            isCreateC[i] = false;
                            SetLegend();
                        }
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        if (curve.R[i] && !(isCreateR[i]))//add
                        {
                            seriesR[i] = new Series("电阻" + (i + 1).ToString());
                            SetSeries(seriesR[i]);// set property of series
                            chart.Series.Add(seriesR[i]);
                            seriesR[i].Points.AddXY(index, dat.Resistor[i]);

                            lgdR[i] = new Legend(seriesR[i].Name);
                            SetLegend(lgdR[i]);
                            chart.Legends.Add(lgdR[i]);

                            seriesR[i].Legend = lgdR[i].Name;

                            isCreateR[i] = true;                         
                        }
                        else if (curve.R[i] && isCreateR[i])//display
                        {
                            seriesR[i].Points.AddXY(index, dat.Resistor[i]);
                        }
                        else if (!(curve.R[i]) && isCreateR[i])//remove series
                        {
                            chart.Series.Remove(seriesR[i]);
                            seriesR[i].Dispose();

                            chart.Legends.Remove(lgdR[i]);
                            lgdR[i].Dispose();

                            isCreateR[i] = false;
                            SetLegend();
                        }
                    }
                    if (curve.T && !(isCreateT))//add
                    {
                        seriesT = new Series("温度");
                        SetSeries(seriesT);// set property of series
                        chart.Series.Add(seriesT);
                        seriesT.Points.AddXY(index, dat.Temperature);

                        lgdT = new Legend(seriesT.Name);
                        SetLegend(lgdT);
                        chart.Legends.Add(lgdT);

                        seriesT.Legend = lgdT.Name;

                        isCreateT = true;
                        
                    }
                    else if (curve.T && isCreateT)//display
                    {
                        seriesT.Points.AddXY(index, dat.Temperature);
                    }
                    else if (!(curve.T) && isCreateT)//remove series
                    {
                        chart.Series.Remove(seriesT);
                        seriesT.Dispose();

                        chart.Legends.Remove(lgdT);
                        lgdT.Dispose();

                        isCreateT = false;
                        SetLegend();
                    }// temperature

                    if (curve.H && !(isCreateH))//add
                    {
                        seriesH = new Series("湿度");
                        SetSeries(seriesH);// set property of series
                        chart.Series.Add(seriesH);
                        seriesH.Points.AddXY(index, dat.Humidity);

                        lgdH = new Legend(seriesH.Name);
                        SetLegend(lgdH);
                        chart.Legends.Add(lgdH);

                        seriesH.Legend = lgdH.Name;

                        isCreateH = true;
                        
                    }
                    else if (curve.H && isCreateH)//display
                    {
                        seriesH.Points.AddXY(index, dat.Humidity);
                    }
                    else if (!(curve.H) && isCreateH)//remove series
                    {
                        chart.Series.Remove(seriesH);
                        seriesH.Dispose();

                        chart.Legends.Remove(lgdH);
                        lgdH.Dispose();

                        isCreateH = false;
                        SetLegend();
                    }//humandity
                }
                LastNodeNum = curve.NodeNum;// record last node No.
            }//real time data curve
            //else //if(curve.isHistory==true  &&
            //      //  isFisrtPresent==true)//past data curve
            //{
                                
            //}//past data curve
        }
        /// <summary>
        /// set the created legend right now
        /// </summary>
        /// <param name="ll">target legend</param>
        private void SetLegend( Legend ll)
        {
            int n = chart.Legends.Count;
            float w=9;
            
            ll.Position.Auto = false;
            ll.Position = new ElementPosition(chart.ChartAreas[0].Position.Width, 5*n, w, 5);
        }
        /// <summary>
        /// set rest legends when remove one legend
        /// </summary>
        private void SetLegend()
        {
            int n = 0;
            float w = 9;
            foreach (Legend lgd in chart.Legends)
            {
                lgd.Position.Auto = false;
                lgd.Position = new ElementPosition(chart.ChartAreas[0].Position.Width, 5 * (n++), w, 5);
            }
        }
        private void SetSeries(Series ss)
        {
            ss.ChartType = SeriesChartType.Line;
            ss.BorderWidth = 1;
            //ss.MarkerStyle = MarkerStyle.Diamond;
            //ss.MarkerSize = 10;
            //ss.IsValueShownAsLabel = true;
        }

        private void InitAll()
        {
            index = -1;
            chart.Series.Clear();
            chart.Legends.Clear();
            chart.Titles["tNodeName"].Text = "";
            isCreateV = new bool[7] { false, false, false, false, false, false, false };
            isCreateC = new bool[7] { false, false, false, false, false, false, false };
            isCreateR = new bool[6] { false, false, false, false, false, false };
            isCreateT = false;
            isCreateH = false;
            //curve.V = new bool[7] { true, false, false, false, false, false, false };
            //curve.C = new bool[7] { true, false, false, false, false, false, false };
            //curve.R = new bool[6] { true, false, false, false, false, false };
            //curve.T = false;
            //curve.H = false;
        }
    }

    /// <summary>
    /// configuration of curve disply
    /// </summary>
    public struct CurveConfig
    {
        /// <summary>
        /// default is false,false: real-time, true: history
        /// </summary>
        public bool isHistory;
        public DateTime dtStart;
        public DateTime dtEnd;
        public DateTime dtPresent;
        public int NodeNum;
        public bool[] V;
        public bool[] C;
        public bool[] R;
        public bool T;
        public bool H;
    }
}
