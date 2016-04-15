﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace TempMonitoring
{
    public partial class comParas : Form
    {
        private DataProcess dp;
        private int save;
        public comParas()
        {
            InitializeComponent();
            dp = new DataProcess();

            cbBPortName.Text = RS232.port.portName;
            cbBBaudRate.Text = RS232.port.baudRate.ToString();
            cbBDataBit.Text = RS232.port.dataBits.ToString();
            tbInternal.Text = RS232.port.Internal.ToString();
            StopBits sb = RS232.port.stopBits;
            if (sb == StopBits.One)
            {
                cbBStopBit.Text = "1";
            }
            else if (sb == StopBits.OnePointFive)
            {
                cbBStopBit.Text = "1.5";
            }
            else if (sb == StopBits.Two)
            {
                cbBStopBit.Text = "2";
            }

            Parity p = RS232.port.parity;
            if (p == Parity.None)
            {
                cbBCheckBit.Text = "None";
            }
            else if (p == Parity.Even)
            {
                cbBCheckBit.Text = "Even";
            }
            else if (p == Parity.Odd)
            {
                cbBCheckBit.Text = "Odd";
            }
            else if (p == Parity.Mark)
            {
                cbBCheckBit.Text = "Mark";
            }
            else if (p == Parity.Space)
            {
                cbBCheckBit.Text = "Space";
            }
        }

        private Parity parity_String2Enum(string str)
        {
            switch (str)
            {
                case "None":
                    return Parity.None;
                case "Even":
                    return Parity.Even;
                case "Odd":
                    return Parity.Odd;
                case "Mark":
                    return Parity.Mark;
                case "Space":
                    return Parity.Space;
                default:
                    return Parity.None;

            }
        }

        private StopBits stopBits_String2Enum(string str)
        {
            StopBits sb = StopBits.None;
            switch (str)
            {
                case "1":
                    sb = StopBits.One;
                    break;
                case "1.5":
                    sb = StopBits.OnePointFive;
                    break;
                case "2":
                    sb = StopBits.Two;
                    break;
            }
            return sb;
        }

        private void cbBPortName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RS232.port.portName = cbBPortName.Text;
        }

        private void cbBBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            RS232.port.baudRate = Int32.Parse(cbBBaudRate.Text);
        }

        private void cbBDataBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            RS232.port.dataBits = Int32.Parse(cbBDataBit.Text);
        }

        private void cbBCheckBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            RS232.port.parity = parity_String2Enum(cbBCheckBit.Text);
        }

        private void cbBStopBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            RS232.port.stopBits = stopBits_String2Enum(cbBStopBit.Text);
            //MessageBox.Show(cbBStopBit.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            RS232.port.Internal = save;
            dp.UpdateComParas(RS232.port);
            this.Close();
        }

        private void tbInternal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                save = int.Parse(tbInternal.Text);
            }
            catch//(Exception ex)
            {
                //MessageBox.Show("please input number!");
            }
        }
    }
}
