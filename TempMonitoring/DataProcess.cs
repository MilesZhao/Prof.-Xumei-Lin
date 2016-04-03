using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Ports;

namespace TempMonitoring
{
    class DataProcess
    {
        private OleDbConnection myconn;

        public DataProcess()
        {
            myconn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                + "EnvironmentalMonitoring.mdb" + ";Persist Security Info=False");
            
        }

        public void AddData(NodeData nd,DateTime dt)
        {
            if (myconn.State == ConnectionState.Open)
            {
                myconn.Close();
            }
             
            myconn.Open();

            string strSQL = "insert into EValues ([NodeNumber],[Voltage0],[Voltage1],[Voltage2],[Voltage3],[Voltage4],";
            strSQL += "[Voltage5],[Voltage6],[Currency0],[Currency1],[Currency2],[Currency3],";
            strSQL += "[Currency4],[Currency5],[Currency6],[Resistor0],[Resistor1],[Resistor2],";
            strSQL += "[Resistor3],[Resistor4],[Resistor5],[Temperature],[Humidity],";
            strSQL += "[DateTime]) values(@NodeNumber,@Voltage0,@Voltage1,@Voltage2,@Voltage3,@Voltage4,@Voltage5,";
            strSQL += "@Voltage6,@Currency0,@Currency1,@Currency2,@Currency3,@Currency4,@Currency5,";
            strSQL += "@Currency6,@Resistor0,@Resistor1,@Resistor2,@Resistor3,@Resistor4,@Resistor5,";
            strSQL += "@Temperature,@Humidity,@DateTime)";
            OleDbCommand cmd = new OleDbCommand(strSQL, myconn);
            cmd.Parameters.Add("@NodeNumber", OleDbType.Integer).Value = nd.NodeNumber;
            cmd.Parameters.Add("@Voltage0", OleDbType.Double).Value = nd.Voltage[0];
            cmd.Parameters.Add("@Voltage1", OleDbType.Double).Value = nd.Voltage[1];
            cmd.Parameters.Add("@Voltage2", OleDbType.Double).Value = nd.Voltage[2];
            cmd.Parameters.Add("@Voltage3", OleDbType.Double).Value = nd.Voltage[3];
            cmd.Parameters.Add("@Voltage4", OleDbType.Double).Value = nd.Voltage[4];
            cmd.Parameters.Add("@Voltage5", OleDbType.Double).Value = nd.Voltage[5];
            cmd.Parameters.Add("@Voltage6", OleDbType.Double).Value = nd.Voltage[6];

            cmd.Parameters.Add("@Currency0", OleDbType.Double).Value = nd.Currency[0];
            cmd.Parameters.Add("@Currency1", OleDbType.Double).Value = nd.Currency[1];
            cmd.Parameters.Add("@Currency2", OleDbType.Double).Value = nd.Currency[2];
            cmd.Parameters.Add("@Currency3", OleDbType.Double).Value = nd.Currency[3];
            cmd.Parameters.Add("@Currency4", OleDbType.Double).Value = nd.Currency[4];
            cmd.Parameters.Add("@Currency5", OleDbType.Double).Value = nd.Currency[5];
            cmd.Parameters.Add("@Currency6", OleDbType.Double).Value = nd.Currency[6];

            cmd.Parameters.Add("@Resistor0", OleDbType.Double).Value = nd.Resistor[0];
            cmd.Parameters.Add("@Resistor1", OleDbType.Double).Value = nd.Resistor[1];
            cmd.Parameters.Add("@Resistor2", OleDbType.Double).Value = nd.Resistor[2];
            cmd.Parameters.Add("@Resistor3", OleDbType.Double).Value = nd.Resistor[3];
            cmd.Parameters.Add("@Resistor4", OleDbType.Double).Value = nd.Resistor[4];
            cmd.Parameters.Add("@Resistor5", OleDbType.Double).Value = nd.Resistor[5];

            cmd.Parameters.Add("@Temperature", OleDbType.Double).Value = nd.Temperature;
            cmd.Parameters.Add("@Humidity", OleDbType.Double).Value = nd.Humidity;
            cmd.Parameters.Add("@DateTime", OleDbType.VarChar).Value = dt.ToString("yy/MM/dd");
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }

            myconn.Close();

        }
        /// <summary>
        /// history data
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="nodeNum"></param>
        /// <returns></returns>
        public DataTable SelectData(DateTime start,DateTime end,int nodeNum)
        {
            if (myconn.State == ConnectionState.Open)
            {
                myconn.Close();
            }
            string s=start.ToString("yy/MM/dd");
            string e=end.ToString("yy/MM/dd");

            string strSQL = "select * from EValues where [DateTime]>='"+s+"' and [DateTime]<='"+e+"'";
            strSQL += "and [NodeNumber]=" + (int)nodeNum + " order by [DateTime] asc";// if the field is not string, there is no need to use '', like above
            OleDbDataAdapter DA = new OleDbDataAdapter(strSQL, myconn);
            DataTable dt = new DataTable();
            DA.Fill(dt);

            return dt;
        }

        public void DeleteData()
        {
            if (myconn.State == ConnectionState.Open)
            {
                myconn.Close();
            }
        }

        public void UpdateComParas(ComConfig com)
        {
            if (myconn.State == ConnectionState.Open)
            {
                myconn.Close();
            }

            myconn.Open();

            string strSQL = "update PortInfo set [Name]=@Name,[BaudRate]=@baudRate, [dataBits]=@dataBits,";
            strSQL += "[stopBits]=@stopBits,[parity]=@parity where [ID]=1";
            OleDbCommand cmd = new OleDbCommand(strSQL, myconn);
            cmd.Parameters.Add("@name", OleDbType.VarChar).Value = com.portName;
            cmd.Parameters.Add("@baudRate", OleDbType.VarChar).Value=com.baudRate.ToString();
            cmd.Parameters.Add("@dataBits", OleDbType.VarChar).Value = com.dataBits.ToString();
            if (com.stopBits == StopBits.One)
            {
                cmd.Parameters.Add("@stopBits", OleDbType.VarChar).Value = "1";
            }
            else if (com.stopBits == StopBits.OnePointFive)
            {
                cmd.Parameters.Add("@stopBits", OleDbType.VarChar).Value = "1.5";
            }
            else if (com.stopBits == StopBits.Two)
            {
                cmd.Parameters.Add("@stopBits", OleDbType.VarChar).Value = "2";
            }

            if (com.parity == Parity.None)
            {
                cmd.Parameters.Add("@parity", OleDbType.VarChar).Value = "None";
            }
            else if (com.parity == Parity.Even)
            {
                cmd.Parameters.Add("@parity", OleDbType.VarChar).Value = "Even";
            }
            else if (com.parity == Parity.Odd)
            {
                cmd.Parameters.Add("@parity", OleDbType.VarChar).Value = "Odd";
            }
            else if (com.parity == Parity.Mark)
            {
                cmd.Parameters.Add("@parity", OleDbType.VarChar).Value = "Mark";
            }
            else if (com.parity == Parity.Space)
            {
                cmd.Parameters.Add("@parity", OleDbType.VarChar).Value = "Space";
            }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                myconn.Close();
            }
        }

        public ComConfig SelectComParas()
        {
            ComConfig port = new ComConfig()
            {
                baudRate = 9600,
                portName = "COM1",
                dataBits = 8,
                stopBits = StopBits.One,
                parity = Parity.None
            };
            if (myconn.State == ConnectionState.Open)
            {
                myconn.Close();
            }

            myconn.Open();

            string strSQL = "select * from PortInfo where [ID] =1";
            OleDbDataAdapter DA = new OleDbDataAdapter(strSQL, myconn);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            port.portName = dt.Rows[0][1].ToString();
            port.baudRate = Int32.Parse(dt.Rows[0][2].ToString());
            port.dataBits = Int32.Parse(dt.Rows[0][3].ToString());
            string str1 = dt.Rows[0][4].ToString();//stopbits
            if (str1 == "1")
            {
                port.stopBits = StopBits.One;
            }
            else if (str1 == "1.5")
            {
                port.stopBits = StopBits.OnePointFive;
            }
            else if (str1 == "2")
            {
                port.stopBits = StopBits.Two;
            }
            string str2 = dt.Rows[0][5].ToString();//parity
            if (str2 == "None")
            {
                port.parity=Parity.None;
            }
            else if (str2 == "Even")
            {
                port.parity = Parity.Even;
            }
            else if (str2 == "Odd")
            {
                port.parity = Parity.Odd;
            }
            else if (str2 == "Mark")
            {
                port.parity = Parity.Mark;
            }
            else if (str2 == "Space")
            {
                port.parity = Parity.Space;
            }

            return port;
        }


    }
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct NodeData
    {
        public int Start;//0x2F
        //memcpy
        public int NodeNumber;//0-29

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public float[] Voltage;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public float[] Currency;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public float[] Resistor;

        public float Temperature;

        public float Humidity;

        public int End;//0x0D

        public ushort CRCValue;//
       // public ushort space;//invalid data
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
