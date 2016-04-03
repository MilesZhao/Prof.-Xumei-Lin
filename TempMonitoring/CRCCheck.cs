using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TempMonitoring
{
    class CRCCheck
    {
        /// <summary>
        /// calculate CRC 
        /// </summary>
        /// <param name="bytes">bytes being calculated</param>
        /// <param name="len">the length of byte</param>
        /// <returns>calculated CRC value</returns>
        public static ushort CRC_XModem(byte[] bytes, int len)
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
}
