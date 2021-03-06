﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;

namespace Graphics
{
    class Program
    {
        
        static Bitmap ReadyMainPic()
        {
            string[] filePicName = Directory.GetFiles("Pic\\WorkPic");
            Bitmap tempPic = new Bitmap(filePicName[0]);
            Bitmap mainPic = new Bitmap(tempPic.Width,tempPic.Height*filePicName.Length);
            return mainPic;
        }
        static void CutPic(int x, int y, int width, int height)
        {
            string[] filePicName = Directory.GetFiles("Pic");
            Rectangle cutArea = new Rectangle(x,y,width,height);
            int count = 0;
            foreach (string PicName in filePicName)
            {
                Bitmap tempPic = new Bitmap(PicName);
                tempPic = tempPic.Clone(cutArea, tempPic.PixelFormat);
                tempPic.Save("Pic\\WorkPic\\"+count+PicName.Substring(PicName.Length-4));
                count++;
            }
        }
        static Dictionary<string,int> GetInput()
        {
            Dictionary<string,int> Area = new Dictionary<string,int>();
            Console.WriteLine("Please input \"x\"");
            Area.Add("x",Convert.ToInt16(Console.ReadLine()));
            Console.WriteLine("Please input \"y\"");
            Area.Add("y", Convert.ToInt16(Console.ReadLine()));
            Console.WriteLine("Please input \"width\"");
            Area.Add("width", Convert.ToInt16(Console.ReadLine()));
            Console.WriteLine("Please input \"height\"");
            Area.Add("height", Convert.ToInt16(Console.ReadLine()));
            return Area;
        }
        static void Main(string[] args)
        {
            string[] D_Picture = Directory.GetFiles("Pic\\WorkPic");
            foreach (string file in D_Picture)
            {
                File.Delete(file);
            }
            Dictionary<string,int> Area =  GetInput();
            CutPic(Area["x"], Area["y"], Area["width"], Area["height"]);
            Bitmap mainPic = ReadyMainPic();
            string[] filePicName = Directory.GetFiles("Pic\\WorkPic");
            Bitmap[] Pic = new Bitmap[filePicName.Length];
            for (int i = 0; i < filePicName.Length; i++)
            {
                Pic[i] =new Bitmap(filePicName[i]);
            }
            

            foreach (Bitmap pic in Pic)
            {
                
            }
        }
        
    }
}
