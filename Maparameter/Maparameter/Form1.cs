using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using Microsoft.VisualBasic;

namespace Maparameter
{
    public partial class Form1 : Form
    {

        Image pic;
        Bitmap DrawArea;
        Graphics g;

        Dictionary<Point, String> lE;
        List<Point> lP0;
        List<Point> lP1;
        List<Point> lP2;
        Point sp;

        string filePath;

        public Form1()
        {
            InitializeComponent();
            lP0 = new List<Point>();
            lP1 = new List<Point>();
            lP2 = new List<Point>();
            lE = new Dictionary<Point, string>();
        }

        private void btnOpenPic_Click(object sender, EventArgs e)
        {
            OfdPic.ShowDialog();
            filePath = OfdPic.FileName;
            txtPath.Text = filePath;
            if (File.Exists(filePath))
            {
                pic = Image.FromFile(filePath);
                PbPic.Size = pic.Size;
                PbPic.BackgroundImage = pic;
                DrawArea = new Bitmap(pic.Size.Width, pic.Size.Height);
                PbPic.Image = DrawArea;
            }
        }



        private void PbPic_DoubleClick(object sender, EventArgs e)
        {
            System.Windows.Forms.MouseEventArgs me = (System.Windows.Forms.MouseEventArgs)e;
            switch (me.Button)
            {
                case MouseButtons.Left:
                    Zonage(me);
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:
                    StartZone(me);
                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    break;
            }
        }

        private void PbPic_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MouseEventArgs me = (System.Windows.Forms.MouseEventArgs)e;
            if (Keyboard.IsKeyDown(Key.LeftCtrl) | Keyboard.IsKeyDown(Key.RightCtrl))
            {
                ZoneEvent(me);
            }
            else
            {
                switch (me.Button)
                {
                    case MouseButtons.Left:
                        Zonage(me);
                        break;
                    case MouseButtons.None:
                        break;
                    case MouseButtons.Right:
                        StartZone(me);
                        break;
                    case MouseButtons.Middle:
                        break;
                    case MouseButtons.XButton1:
                        break;
                    case MouseButtons.XButton2:
                        break;
                    default:
                        break;
                }
            }
            
        }

        private void ZoneEvent(System.Windows.Forms.MouseEventArgs me)
        {
            Point coordinates = me.Location;
            int xVal = (int)(coordinates.X / NudBlockSize.Value);
            int yVal = (int)(coordinates.Y / NudBlockSize.Value);
            int blockSize = (int)NudBlockSize.Value;
            Point p = new Point(xVal, yVal);
            Pen mypen = new Pen(Color.Orange,2f);
            bool alreadyExist = false;

            g = Graphics.FromImage(DrawArea);


            string plop;
            alreadyExist = lE.TryGetValue(p, out plop);


            string res = Interaction.InputBox("Nom de l'event :", "Nouvel Evenement", alreadyExist?plop:"").Trim(' ');
            if (res != "")
            {
                lE.Add(new Point(xVal, yVal), res);
                g.DrawLine(mypen, xVal * blockSize, yVal * blockSize, xVal * blockSize + blockSize, yVal * blockSize + blockSize);
                g.DrawLine(mypen, xVal * blockSize + blockSize, yVal * blockSize, xVal * blockSize, yVal * blockSize + blockSize);
                PbPic.Image = DrawArea;
            }

            g.Dispose();
        }

        private void StartZone(System.Windows.Forms.MouseEventArgs me)
        {
            Point coordinates = me.Location;
            int xVal = (int)(coordinates.X / NudBlockSize.Value);
            int yVal = (int)(coordinates.Y / NudBlockSize.Value);
            int blockSize = (int)NudBlockSize.Value;
            Point p = new Point(xVal, yVal);
            Pen mypen = new Pen(Color.Green, 2f);

           
            g = Graphics.FromImage(DrawArea);

            
            g.DrawEllipse(mypen, xVal * blockSize, yVal * blockSize, blockSize, blockSize);
            sp = new Point(xVal , yVal );
            PbPic.Image = DrawArea;

            g.Dispose();
        }

        private void Zonage(System.Windows.Forms.MouseEventArgs me)
        {
            Point coordinates = me.Location;
            int xVal = (int)(coordinates.X / NudBlockSize.Value);
            int yVal = (int)(coordinates.Y / NudBlockSize.Value);
            int blockSize = (int)NudBlockSize.Value;
            Point p = new Point(xVal, yVal);
            Pen mypen = new Pen(Color.Black, 2f); ;

            int z0 = lP0.Contains(p) ? 1 : 0;
            int z1 = lP1.Contains(p) ? 2 : 0;
            int z2 = lP2.Contains(p) ? 4 : 0;

            switch (z0 + z1 + z2)
            {
                case 0:
                    lP1.Add(p);
                    mypen = new Pen(Color.Red, 2f);
                    break;

                case 1:
                    lP0.Remove(p);
                    lP1.Add(p);
                    mypen = new Pen(Color.Red, 2f);
                    break;

                case 2:
                    lP1.Remove(p);
                    lP2.Add(p);
                    mypen = new Pen(Color.Yellow, 2f);
                    break;


                case 4:
                    lP2.Remove(p);
                    lP0.Add(p);
                    mypen = new Pen(Color.Black, 2f);
                    break;

                default:
                    break;
            }


            g = Graphics.FromImage(DrawArea);


            g.DrawRectangle(mypen, xVal * blockSize, yVal * blockSize, blockSize, blockSize);

            PbPic.Image = DrawArea;

            g.Dispose();
        }

        

        private void BtnWrite_Click(object sender, EventArgs e)
        {
            WriteLevels();
            WriteEvents();
        }

        private void WriteLevels()
        {
            string picCsvLevels = filePath.Substring(0, filePath.Length - filePath.Split('.').Last().Length - 1) + "_levels.csv";
            List<string> levelsData = new List<string>
            {
                "Level;X;Y",
                "-1;" + sp.X.ToString() + ";" + sp.Y.ToString()
            };
            foreach (Point p in lP0)
            {
                levelsData.Add("0;" + p.X.ToString() + ";" + p.Y.ToString());
            }
            foreach (Point p in lP1)
            {
                levelsData.Add("1;" + p.X.ToString() + ";" + p.Y.ToString());
            }
            foreach (Point p in lP2)
            {
                levelsData.Add("2;" + p.X.ToString() + ";" + p.Y.ToString());
            }
            File.WriteAllLines(picCsvLevels, levelsData);
        }

        private void WriteEvents()
        {
            string picCsvEventss = filePath.Substring(0, filePath.Length - filePath.Split('.').Last().Length - 1) + "_events.csv";
            List<string> eventsData = new List<string>
            {
                "Name;X;Y",
            };
            foreach (Point p in lE.Keys)
            {
                eventsData.Add(lE[p] + ";" + p.X.ToString() + ";" + p.Y.ToString());
            }
            File.WriteAllLines(picCsvEventss, eventsData);

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            sp = new Point();
            lE = new Dictionary<Point, string>();
            lP0 = new List<Point>();
            lP1 = new List<Point>();
            lP2 = new List<Point>();
            DrawArea = new Bitmap(pic.Size.Width, pic.Size.Height);
            PbPic.Image = DrawArea;
        }

        private void BtnRedraw_Click(object sender, EventArgs e)
        {

        }
    }
}
