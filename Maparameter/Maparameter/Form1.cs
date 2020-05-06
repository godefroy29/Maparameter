using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maparameter
{
    public partial class Form1 : Form
    {

        Image pic;
        Bitmap DrawArea;
        Graphics g;

        List<Point> lP0;
        List<Point> lP1;
        List<Point> lP2;

        string filePath;

        public Form1()
        {
            InitializeComponent();
            lP0 = new List<Point>();
            lP1 = new List<Point>();
            lP2 = new List<Point>();
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
            MouseEventArgs me = (MouseEventArgs)e;
            zonage(me);
        }

        private void PbPic_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            zonage(me);
        }

        private void zonage(MouseEventArgs me)
        {
            Point coordinates = me.Location;
            int xVal = (int)(coordinates.X / NudBlockSize.Value);
            int yVal = (int)(coordinates.Y / NudBlockSize.Value);
            int blockSize = (int)NudBlockSize.Value;
            Point p = new Point(xVal, yVal);
            Pen mypen = new Pen(Color.Black); ;

            int z0 = lP0.Contains(p) ? 1 : 0;
            int z1 = lP1.Contains(p) ? 2 : 0;
            int z2 = lP2.Contains(p) ? 4 : 0;

            switch (z0 + z1 + z2)
            {
                case 0:
                    lP1.Add(p);
                    mypen = new Pen(Color.Red);
                    break;

                case 1:
                    lP0.Remove(p);
                    lP1.Add(p);
                    mypen = new Pen(Color.Red);
                    break;

                case 2:
                    lP1.Remove(p);
                    lP2.Add(p);
                    mypen = new Pen(Color.Yellow);
                    break;


                case 4:
                    lP2.Remove(p);
                    lP0.Add(p);
                    mypen = new Pen(Color.Black);
                    break;

                default:
                    break;
            }


            g = Graphics.FromImage(DrawArea);


            g.DrawRectangle(mypen, xVal * blockSize, yVal * blockSize, blockSize, blockSize);

            PbPic.Image = DrawArea;

            g.Dispose();
        }

        private void BtnSaveLevel_Click(object sender, EventArgs e)
        {
            RtbLevel.ResetText();
            RtbLevel.Text = "Level;X;Y";
            foreach (Point p in lP0)
            {
                RtbLevel.AppendText(Environment.NewLine + "0;" + p.X.ToString() + ";" + p.Y.ToString());
            }
            foreach (Point p in lP1)
            {
                RtbLevel.AppendText(Environment.NewLine + "1;" + p.X.ToString() + ";" + p.Y.ToString());
            }
            foreach (Point p in lP2)
            {
                RtbLevel.AppendText(Environment.NewLine + "2;" + p.X.ToString() + ";" + p.Y.ToString());
            }

        }

        private void BtnWrite_Click(object sender, EventArgs e)
        {
            string picCsv = filePath.Substring(0, filePath.Length - filePath.Split('.').Last().Length - 1) + ".csv";
            File.WriteAllLines(picCsv, RtbLevel.Lines);
        }
    }
}
