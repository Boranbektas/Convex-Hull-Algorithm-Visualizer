using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using static _3.Points;

namespace _3
{
    internal class HelperClass
    {
        public int FindPoint(List<DrawingPoint> inp, int X, int Y)
        {
            int index = -1;
            int minDistance = 1;
            

            for(var i =0; i <inp.Count(); i++)
            {
                int dis = CalculateDistance(inp[i], X, Y);

                if(dis < minDistance)
                {
                    minDistance=dis;
                    index = i;
                }

            }

            
            return index;
        }

        public List<DrawingPoint> FilterDeletedPoints(List<DrawingPoint> inp)
        {
            List<DrawingPoint> newlist = new List<DrawingPoint>();

            for(var i=0; i < inp.Count(); i++)
            {
                if (inp[i].isDeleted == false)
                {
                    newlist.Add(inp[i]);
                }
            }
            
            return newlist;
        }

        public int CalculateDistance(DrawingPoint d1 ,int x,int y)
        {
            int distance = 0;

            int dx = d1.xCoordinate - x;
            int dy = d1.yCoordinate - y;
            distance = dx*dx + dy*dy;   
            return Convert.ToInt32(Math.Sqrt(distance));

        }

        public List<DrawingPoint> GetRandomDrawingPointList(Control c1,Control c2,Random r,int size)
        {
            List<DrawingPoint> RandomList = new List<DrawingPoint>();

            for(var i = 0; i < size; i++)
            {
                //Subtracting the region where we dont want our nodes tı spawn//
                int randx = r.Next(c1.Width-c2.Width);
                int randy = r.Next(c1.Height);

                DrawingPoint d = new DrawingPoint();
                d.xCoordinate = randx;
                d.yCoordinate = randy;
                d.Dot = new Rectangle(new Point(randx, randy), new Size(6, 6));
                d.DrawingPen = new Pen(Color.Red, 4);
                RandomList.Add(d);

            }

            return RandomList;

        }


    }


}
