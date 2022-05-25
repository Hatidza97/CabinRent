﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.WinUI.Helper
{
    public class ImageHelper
    {
        public static byte[] FromImageToByte(Image slika)
        {
            MemoryStream ms = new MemoryStream();
            slika.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public static Image FromByteToImage(byte[] slika)
        {
            MemoryStream ms = new MemoryStream(slika);
            return Image.FromStream(ms);
        }
    }
}
