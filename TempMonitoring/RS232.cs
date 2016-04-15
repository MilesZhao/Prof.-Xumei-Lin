using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
//using System.Windows;
using System.Windows.Forms;

namespace TempMonitoring
{
    class RS232
    {
        private static SerialPort com;
        public static ComConfig port;

        public RS232()
        {
            com = new SerialPort();
            port = new ComConfig()
            {
                baudRate = 9600,
                portName = "COM1",
                dataBits = 8,
                stopBits = StopBits.One,
                parity = Parity.None,
                Internal = 1000
            };
        }

        public static void readall()
        {
            com.ReadExisting();
        }

        public static void read(byte[] buf, int offset, int size)
        {
            com.Read(buf, offset, size);
        }

        public static int bytesToread
        {
            get { return com.BytesToRead; }
        }

        public static bool IsComOpen
        {
            get { return com.IsOpen; }
        }

        public static string ComName
        {
            get { return com.PortName; }
        }

        public static bool OpenCom()
        {
            com.PortName = port.portName;
            com.BaudRate = port.baudRate;
            com.DataBits = port.dataBits;
            com.StopBits = port.stopBits;
            com.Parity = port.parity;

            try
            {
                com.Open();
                return true;
            }
            catch
            {
                MessageBox.Show("串口不存在或被占用！");
                return false;
            }

        }

        public static void CloseCom()
        {
            com.Close();
        }
    }

    /// <summary>
    /// configurations of com
    /// </summary>
    public struct ComConfig
    {
        public int baudRate;
        public string portName;
        public int dataBits;
        public StopBits stopBits;
        public Parity parity;
        public int Internal;
    }

}
