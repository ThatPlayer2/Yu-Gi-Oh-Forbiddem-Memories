using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yu_Gi_Oh_FM_Save_Editor.Crc16
{
    public static class CalculateCustomCRC
    {
        public static ushort CalculateCustomCRC16(byte[] data, int offset, int length)
        {
            ushort polynomial = 0x1021;
            ushort crc = 0x0000;

            for (int i = 0; i < length; i++)
            {
                crc ^= (ushort)(data[offset + i] << 8);
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x8000) != 0)
                    {
                        crc = (ushort)((crc << 1) ^ polynomial);
                    }
                    else
                    {
                        crc <<= 1;
                    }
                }
            }

            return crc;
        }
    }
}
