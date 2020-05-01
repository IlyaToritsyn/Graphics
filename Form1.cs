using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Point> P = new List<Point>();
        int R = 10;
        Color col  = Color.Blue;


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
           
            Graphics gr = CreateGraphics();
            Brush br = new SolidBrush(col);


            gr.FillEllipse(br, e.X - R / 2, e.Y - R/2 , R, R);

            Pen Our_pen = new Pen(col);
            foreach (Point p in P)
            {
                gr.DrawLine(Our_pen, e.Location, p);
            }

            P.Add(e.Location);
            gr.Dispose();


        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = CreateGraphics();

           

            Brush br = new SolidBrush(col);
            foreach (Point p in P)
                gr.FillEllipse(br, p.X - R/2, p.Y - R/2,R,R  );


            Pen Our_pen = new Pen(col);
            for (int i = 0; i < P.Count; i++)
                for (int j = i+1; j < P.Count; j++)
                    gr.DrawLine(Our_pen, P[i], P[j]);


            gr.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            col = colorDialog1.Color;
            Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            P.Clear();
            Refresh();
        }
    }
}
