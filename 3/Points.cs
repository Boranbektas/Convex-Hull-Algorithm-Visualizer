using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static _3.Points;

namespace _3
{
    internal class Points : IDisposable
    {   
        bool IsDısposed = false;
        public Points() => drawingPoint = new List<DrawingPoint>();

        public List<DrawingPoint> drawingPoint { get; set; }

        public void Add(DrawingPoint NewPoint)
        {
            if (NewPoint.Dot.Size.Width > 1 && NewPoint.Dot.Size.Height > 1)
            {
                drawingPoint.Add(NewPoint);
            }
        }

        public void Clear() 
        {
            this.Dispose();
            this.drawingPoint.Clear();
            this.drawingPoint = new List<DrawingPoint>();

        }

        public void Remove(Point point)
        {
            Remove(this.drawingPoint.Select((p, i) => { if (p.Dot.Contains(point)) return i; return -1; }).First());
        }

        public void Remove(int index)
        {
            if(index > -1)
            {
                this.drawingPoint[index].Delete();
                this.drawingPoint.RemoveAt(index);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool isSafeDisposing)
        {
            if(isSafeDisposing && (!this.IsDısposed) && (this.drawingPoint.Count > 0))
            {
                foreach(DrawingPoint dp in this.drawingPoint)
                {
                    if (dp != null) dp.Delete();
                    
                }
            }
        }
        
       



        public class DrawingPoint 
        {
            Pen? pen = null;
            Rectangle dot = Rectangle.Empty;
            public int xCoordinate = 0;
            public int yCoordinate = 0;
            public bool isDeleted = false;

            public Pen DrawingPen { get => pen; set => this.pen = value;}
            public Rectangle Dot { get => this.dot; set => this.dot = value; }

            //Constructors//
            public DrawingPoint() : this(Point.Empty){}
            public DrawingPoint(Point newPoint)
            {
                this.pen = new Pen(Color.Red, 4);
                this.dot = new Rectangle(newPoint, new Size(4,4));

            }

           

            public void Delete()
            {
                if(this.pen != null)
                {
                    this.pen.Dispose();
                }
            }

            public void PrintCordinates()
            {
                Trace.WriteLine(this.xCoordinate.ToString() + " " + this.yCoordinate.ToString()+ "\n");
            } 


        }

        //Calculates the cross product//
        public int CrossProduct(DrawingPoint d1, DrawingPoint d2)
        {
            int res = (d1.xCoordinate * d2.yCoordinate) - (d1.yCoordinate * d2.xCoordinate);
            return res;
        }



        //Finds the point with lowest x and y coordinate to start the algorithm//
        public DrawingPoint FindStartingPoint(List<DrawingPoint> plist,ref int index)
        {

            DrawingPoint Min = new DrawingPoint();

            Min = plist[0];

            for (short i = 1; i < plist.Count(); i++)
            {
                if (Min.yCoordinate > plist[i].yCoordinate)
                {
                   Min = plist[i];
                   index = i;
                    
                }
                else if(Min.yCoordinate == plist[i].yCoordinate)
                {
                    if (Min.xCoordinate < plist[i].xCoordinate)
                    {
                        Min = plist[i];
                        index = i;
                    }

                }
            }

            return Min;
        }

        public List<DrawingPoint> GrahamScan(List<DrawingPoint> inputPoints) 
        {
            HelperClass helper = new HelperClass();   
            int OriginIndex = 0 ;
            List<DrawingPoint> stack =new List<DrawingPoint>();

            //Trivial Input .There is no need for a scan//
            if(inputPoints.Count()<3) return inputPoints;

            DrawingPoint Origin = new DrawingPoint();
            DrawingPoint Temp = new DrawingPoint();

            //Filtering out deleted points in our list//

            inputPoints=helper.FilterDeletedPoints(inputPoints);

            Origin = FindStartingPoint(inputPoints, ref OriginIndex);


            //Swapping origin point with the first point.(can be optimised)//
            Temp = inputPoints[0];
            inputPoints[0] = Origin;
            inputPoints[OriginIndex] = Temp;

            inputPoints = PolarSort(inputPoints,Origin);

            stack.Add(inputPoints[0]);
            stack.Add(inputPoints[1]);
            int counter = 2;

            while (counter < inputPoints.Count())
            {
                DrawingPoint a = stack[stack.Count()-2];
                DrawingPoint b = stack[stack.Count()-1];
                DrawingPoint c = inputPoints[counter];

                if (IsAngelConvex(a, b, c))
                {
                    stack.Add(c);
                    counter++;
                }
                else
                {   //Middle point does not lie on convex hull//
                    stack.RemoveAt(stack.Count()-1);
                    if (stack.Count() < 2)
                    {
                        stack.Add(c);
                        counter++;
                    }


                }
          



            }
            
            //If three collinear points are found at the end, we
            // remove the middle one.
            DrawingPoint p1 = stack[stack.Count() - 2];
            DrawingPoint p2 = stack[stack.Count() - 1];
            DrawingPoint first = stack[0];

            if (!IsAngelConvex(p1, p2, first))
            {
                stack.RemoveAt(stack.Count - 1);
            }

            //For drawing the last edge we add the first node//
            stack.Add(Origin);
            

            return stack;

        }

        bool IsAngelConvex(DrawingPoint a,DrawingPoint b,DrawingPoint c)
        {
            //Creating vectors//
            DrawingPoint ab =new DrawingPoint();
            DrawingPoint bc =new DrawingPoint();
            //Calculating dimensions of vectors//
            int abX =b.xCoordinate-a.xCoordinate;
            int abY =b.yCoordinate-a.yCoordinate;
            int bcX =c.xCoordinate-b.xCoordinate;
            int bcY =c.yCoordinate-b.yCoordinate;

            ab.xCoordinate = abX;
            ab.yCoordinate = abY;
            bc.xCoordinate = bcX;
            bc.yCoordinate = bcY;

            //Angle is a convex angle if cross product of vectors are positive//

            return CrossProduct(ab,bc)>0;

        }

        public List<DrawingPoint> PolarSort(List<DrawingPoint> inp, DrawingPoint origin)
        {
           
            
                List<DrawingPoint> sorted = new List<DrawingPoint>();

                var PointAngle = new List<Tuple<DrawingPoint, double>>();

                // Tupling Points with their angles relative to the origin
                for (short i = 0; i < inp.Count(); i++)
                {
                    Tuple<DrawingPoint, double> pAngle = new Tuple<DrawingPoint, double>(inp[i], CalculateArcTanget(inp[i], origin));
                    PointAngle.Add(pAngle);
                }

                // Ordering angles in ascending order
                PointAngle = PointAngle.OrderBy(p => p.Item2).ToList();

                for (var i = 0; i < PointAngle.Count; i++)
                {
                    sorted.Add(PointAngle[i].Item1);
                }

                return sorted;
            

            


        }

        public double CalculateArcTanget(DrawingPoint d1, DrawingPoint d2)
        {
            return Math.Atan2((d1.yCoordinate - d2.yCoordinate), (d1.xCoordinate - d2.xCoordinate));
        }




    }

    
   

   


}
