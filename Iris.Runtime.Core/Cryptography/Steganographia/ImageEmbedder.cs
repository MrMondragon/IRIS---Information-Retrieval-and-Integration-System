
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using Iris.Generators;
using System.Collections;
using Iris.Cryptography;
using System.Runtime.InteropServices;
using System.IO;


namespace Iris.Steganographia
{

  public static class ImageEmbedder
  {
    public static EditableBitmap ResizeToFit(Bitmap bmp, int size)
    {
      PixelFormat pfx = bmp.PixelFormat;
      int pfxSize = Bitmap.GetPixelFormatSize(pfx);
      size = Convert.ToInt32(Math.Sqrt((size/3)+2)); 
      size = size + (4 - (size % 4));
      int h;
      int w;

      if ((size > bmp.Width) || (size > bmp.Height))
      {

        Single factor;
        if (bmp.Width > bmp.Height)
        {
          factor = (Single)bmp.Width / bmp.Height;
          h = size;
          w = Convert.ToInt32((Single)size * factor);
        }
        else
        {
          factor = (Single)bmp.Height / bmp.Width;
          h = Convert.ToInt32((Single)size * factor);
          w = size;
        }

        bmp = new Bitmap(bmp, w, h);
      }
      else
      {
        h = bmp.Height;
        w = bmp.Width;
      }

      EditableBitmap ebmp = new EditableBitmap(bmp, pfx);
      return ebmp;
    }



    public static Bitmap Embed(Byte[] bytes, Bitmap bmp, string key)
    {
      int pfx = Bitmap.GetPixelFormatSize(bmp.PixelFormat);

      BitList bitArray = new BitList(bytes);
      EditableBitmap ebmp = ResizeToFit(bmp, bitArray.Length);
      int[] seq = GenBase.ScrambleSequence(bitArray.Length, key);

      for (int i = 0; i < bitArray.Length; i++)
      {
        int idx = seq[i];
        byte v = ebmp.Bits[idx];
        BinaryValue bValue = new BinaryValue(v);
        bValue[0] = bitArray[i];

        ebmp.Bits[idx] = bValue.ByteValue;
      }

      return ebmp.Bitmap;
    }

    public static Byte[] Extract(Bitmap bmp, string key, int size)
    {
      EditableBitmap ebmp = new EditableBitmap(bmp);
      byte[] bytes = new byte[size];
      BitList bitArray = new BitList(bytes);
      int[] seq = GenBase.ScrambleSequence(bitArray.Length, key);

      for (int i = 0; i < bitArray.Length; i++)
      {
        int idx = seq[i];
        bitArray[i] = (ebmp.Bits[idx] % 2) == 1;
      }

      bytes = bitArray.GetBytes();
      return bytes;
    }

  }
}