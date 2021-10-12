using System;
using System.Collections;
using System.Collections.Generic;

namespace Кораблики
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] lines = { "4", "8 2", "7 8", "2 3", "3 9", "4 5", "3" };
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\alecs\source\repos\Кораблики\Data1.txt");
            int shipsSum = Convert.ToInt32(lines[0]);//кол-во кораблей
            int radarDist = Convert.ToInt32(lines[lines.Length - 1]);//Дальность радара
            string centreSkanStr = (lines[shipsSum + 1]);//Координаты центра скана
            string centreSkanXStr = "";
            string centreSkanYStr = "";
            int ifSpase = 0;
            for (int i = 0; i < centreSkanStr.Length; i++)
            {
                if (centreSkanStr[i]==' ')
                {
                    ifSpase++;
                    continue;
                }
                if (ifSpase == 0)
                {
                    centreSkanXStr += Convert.ToString(centreSkanStr[i]);//X Координата центра скана
                }
                else if (ifSpase == 1)
                {
                    centreSkanYStr += Convert.ToString(centreSkanStr[i]);//Y Координата центра скана
                }
            }
            int centreSkanX = int.Parse(centreSkanXStr);
            int centreSkanY = int.Parse(centreSkanYStr);
            double closer = 10000000000.0;
            List<string> ShipsOnTheRadar = new List<string>();
            List<double> LenShip = new List<double>();
            int len = 1;
            int One = 0;
            for (int i = 1; i < shipsSum+1 ; i++)
            {
                string ship = lines[i];
                //int shipX = Int32.Parse(Convert.ToString(ship[0]));//X Координата корабля
                //int shipY = Int32.Parse(Convert.ToString(ship[2]));//Y Координата корабля
                string shipXStr = "";
                string shipYStr = "";
                int ifSpaseShip = 0;
                for (int o = 0; o < ship.Length; o++)
                {
                    if (ship[o] == ' ')
                    {
                        ifSpaseShip++;
                        continue;
                    }
                    if (ifSpaseShip == 0)
                    {
                        shipXStr += Convert.ToString(ship[o]);//X Координата центра скана
                    }
                    else if (ifSpaseShip == 1)
                    {
                        shipYStr += Convert.ToString(ship[o]);//Y Координата центра скана
                    }
                }
                int shipX = int.Parse(shipXStr);
                int shipY = int.Parse(shipYStr);
                int distX = Math.Abs(centreSkanX - shipX);//ближайший корабль по X
                int distY = Math.Abs(centreSkanY - shipY);//ближайший корабль по Y
                double dist = Math.Sqrt(Convert.ToDouble((distX* distX)+(distY* distY)));//Расстояние до ближайшего корабля
                
                if (closer > dist)
                {
                    closer = dist;
                }
                if (dist <= radarDist) {
                    LenShip.Add(dist);
                    for (int j = 0; j < len; j++)
                    {
                        if (LenShip[j]<dist|| One ==0)
                        {
                            
                            ShipsOnTheRadar.Insert(j, $"{shipX} {shipY}");
                            break;
                        }
                        
                    }
                    One++;
                }
            }
            
            closer = Math.Round(closer, 1);

            for (int i = 0; i < One; i++)
            {
                Console.Write(ShipsOnTheRadar[i]+" ");
            }
            Console.WriteLine(closer);
        }
    }
}
