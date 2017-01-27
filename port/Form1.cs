using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;

namespace port
{
    public struct CurveConfig
    {
        public int i;
    }
    public partial class Form1 : Form
    {

        private NodeData nd;// 
        CurveConfig cc;

        public Form1()
        {
            InitializeComponent();
            cc = new CurveConfig()
            {
                i = 1,
            };
            nd = new NodeData()// innitiate struct NodeData
            {
                Start = 0x2F,
                NodeNumber = 0,
                Voltage = new float[7] { (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0 },
                Currency = new float[7] { (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0 },
                Resistor = new float[6] { (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0, (float)0.0 },
                Temperature = (float)0.0,
                Humidity = (float)0.0,
                End = 0x0D,
                CRCValue = 0x00
            };




        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "openCom")
            {
                button1.Text = "closeCom";
                serialPort1.Open();
                timer1.Start();
            }
            else if (button1.Text == "closeCom")
            {
                timer1.Stop();
                button1.Text = "openCom";
                serialPort1.Close();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random ra = new Random();
            nd.NodeNumber = ra.Next(0, 29);
            for (int i = 0; i < 7; i++)
            {
                nd.Voltage[i] = ra.Next(0, 50);
            }
            for (int i = 0; i < 7; i++)
            {
                nd.Currency[i] = ra.Next(0, 50);
            }
            for (int i = 0; i < 6; i++)
            {
                nd.Resistor[i] = ra.Next(0, 50);
            }
            nd.Temperature = ra.Next(0, 50);
            nd.Humidity = ra.Next(0, 50);
            //label1.Text = nd.NodeNumber.ToString();
            byte[] bytes = NodeData.StructToBytes(nd);
            nd.CRCValue = CRC_XModem(bytes, 100);
            bytes = NodeData.StructToBytes(nd);

            label1.Text = bytes.Length.ToString();
            label2.Text = nd.CRCValue.ToString();

            serialPort1.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// calculate CRC 
        /// </summary>
        /// <param name="bytes">bytes being calculated</param>
        /// <param name="len">the length of byte</param>
        /// <returns>calculated CRC value</returns>
        private static ushort CRC_XModem(byte[] bytes, int len)
        {
            ushort crc = 0x00;          // initial value
            const ushort polynomial = 0x1021;
            for (int index = 0; index < len; index++)
            {
                byte b = bytes[index];
                for (int i = 0; i < 8; i++)
                {
                    Boolean bit = ((b >> (7 - i) & 1) == 1);
                    Boolean c15 = ((crc >> 15 & 1) == 1);
                    crc <<= 1;
                    if (c15 ^ bit) crc ^= polynomial;
                }
            }
            crc &= 0xffff;
            //return crc;
            return (ushort)(((crc & 0xff) << 8) | ((crc >> 8) & 0xff));
        }

    }
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct NodeData
    {
        public int Start;
        public int NodeNumber;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public float[] Voltage;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public float[] Currency;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public float[] Resistor;

        public float Temperature;
        public float Humidity;
        public int End;
        public ushort CRCValue;
        //// <summary>
        /// 结构体转byte数组
        /// </summary>
        /// <param name="structObj">要转换的结构体</param>
        /// <returns>转换后的byte数组</returns>
        public static byte[] StructToBytes(object structObj)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(structObj);
            //创建byte数组
            byte[] bytes = new byte[size];
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(structObj, structPtr, false);
            //从内存空间拷到byte数组
            Marshal.Copy(structPtr, bytes, 0, size);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回byte数组
            return bytes;
        }
        /// byte数组转结构体
        /// </summary>
        /// <param name="bytes">byte数组</param>
        /// <param name="type">结构体类型</param>
        /// <returns>转换后的结构体</returns>
        public static object BytesToStuct(byte[] bytes, Type type)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(type);
            //byte数组长度小于结构体的大小
            if (size > bytes.Length)
            {
                //返回空
                return null;
            }
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将byte数组拷到分配好的内存空间
            Marshal.Copy(bytes, 0, structPtr, size);
            //将内存空间转换为目标结构体
            object obj = Marshal.PtrToStructure(structPtr, type);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回结构体
            return obj;
        }
    }
}
