using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace _3
{


    public partial class formMain : Form
    {

        Points mPoints = new Points();
        List<Points.DrawingPoint> ConvexHull = new List<Points.DrawingPoint>();
        int drawoption = 0;
        Stopwatch Watch = new Stopwatch();
        HelperClass helper = new HelperClass();
        int NodeCounter = 0;
        int TraverseCounter = 0;
        int RandomSize = 0;
        Random rand = new Random(17);
        


        public formMain()
        {

            InitializeComponent();

            
        }


        private void Grid_MouseWheel(object? sender, MouseEventArgs e)//???///
        {
            drawoption = -1; // Do nothing while in paint//
            if (e.Delta != 0)       //is middle mouse button activated?
            {
                Grid.Width = Convert.ToInt32(Grid.Width * e.Delta / 100);
                Grid.Height = Convert.ToInt32(Grid.Height * e.Delta / 100);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Grid_MouseUp(object sender, MouseEventArgs e)
        {

            (sender as Control).Invalidate();
            if (e.Button == MouseButtons.Left)
            {

                //Add New Node//
                Points.DrawingPoint newPoint = new Points.DrawingPoint();
                newPoint.Dot = new Rectangle(e.Location, new Size(6, 6));
                newPoint.xCoordinate = e.Location.X;
                newPoint.yCoordinate = e.Location.Y;
                newPoint.DrawingPen = new Pen(Color.Red, 4);
                mPoints.drawingPoint.Add(newPoint);
                NodeCounter++;    

            }
            else if (e.Button == MouseButtons.Right)
            {

                drawoption = 2;

                //Delete Node//
                int Location = helper.FindPoint(mPoints.drawingPoint, e.X, e.Y);
                if (Location != -1)
                {
                    mPoints.drawingPoint[Location].isDeleted = true;
                }

            }

            (sender as Control).Update();

        }

        private void Grid_Click(object sender, EventArgs e)
        {

        }

        private void buttonGrahamScan_Click(object sender, EventArgs e)
        {
            Watch.Start();
            ConvexHull = mPoints.GrahamScan(mPoints.drawingPoint);
            Watch.Stop();
            labelExecutionTime.Text = Watch.ElapsedMilliseconds.ToString() + "ms";
            drawoption = 1;
            Grid.Invalidate();
        }

        private void Grid_Paint(object sender, PaintEventArgs e)
        {
            switch (drawoption)
            {

                case -1:
                    {
                        break;
                    }


                case 0:
                    {
                        //painting points to the screen//
                        foreach (Points.DrawingPoint i in mPoints.drawingPoint)
                        {
                            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            e.Graphics.DrawEllipse(i.DrawingPen, i.Dot);
                            labelPointCounter.Text = NodeCounter.ToString();
                            Grid.Update();

                        }

                        break;
                    }

                case 1:
                    {
                        //Drawing Nodes//
                        foreach (Points.DrawingPoint i in mPoints.drawingPoint)
                        {
                            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            e.Graphics.DrawEllipse(i.DrawingPen, i.Dot);
                            labelPointCounter.Text = NodeCounter.ToString();
                        }

                        //Drawing the convex hull//
                        int j = 0;
                        Pen blackpen = new Pen(Color.Black, 2);

                        while (j < ConvexHull.Count() - 1)
                        {
                            e.Graphics.DrawLine(blackpen, ConvexHull[j].xCoordinate, ConvexHull[j].yCoordinate, ConvexHull[j + 1].xCoordinate, ConvexHull[j + 1].yCoordinate);
                            j++;
                            Grid.Update();

                        }
                        break;


                    }
                case 2:
                    {
                        NodeCounter = 1;
                        //Deleting a node//
                        foreach (Points.DrawingPoint i in mPoints.drawingPoint)
                        {
                            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            if (!i.isDeleted)
                            {
                                e.Graphics.DrawEllipse(i.DrawingPen, i.Dot);
                                NodeCounter++;
                            }

                            labelPointCounter.Text = (NodeCounter - 1).ToString();
                        }

                        break;
                    }
                case 3:
                    {
                        //Drawing Nodes//
                        foreach (Points.DrawingPoint i in mPoints.drawingPoint)
                        {
                            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            e.Graphics.DrawEllipse(i.DrawingPen, i.Dot);
                            labelPointCounter.Text = NodeCounter.ToString();
                        }

                        //Showing Steps of algorithm//
                        Pen bpen = new Pen(Color.Black, 2);

                        for (var i = 0; i < TraverseCounter - 1; i++)
                        {
                            e.Graphics.DrawLine(bpen, ConvexHull[i].xCoordinate, ConvexHull[i].yCoordinate, ConvexHull[i + 1].xCoordinate, ConvexHull[i + 1].yCoordinate);
                            Grid.Update();
                        }

                        break;
                    }
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mPoints.Dispose();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {

            ConvexHull = mPoints.GrahamScan(mPoints.drawingPoint);

            if (TraverseCounter < ConvexHull.Count)
            {
                drawoption = 3;
                TraverseCounter++;
                Grid.Invalidate();
            }
            else
            {
                TraverseCounter = 0;
            }

        }



        private void textBoxRandomNumberSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAddRandomNumber_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(textBoxRandomNumberSize.Text);
            mPoints.drawingPoint = helper.GetRandomDrawingPointList(Grid, panel1, rand, size);
            drawoption = 0;
            NodeCounter = size;
            Grid.Invalidate();

        }   


        private void buttonClear_Click(object sender, EventArgs e)
        {

            NodeCounter = 0;
            mPoints.Clear();
            drawoption = 0;
            labelPointCounter.Text = NodeCounter.ToString();
            Grid.Invalidate();


        }





    }
}