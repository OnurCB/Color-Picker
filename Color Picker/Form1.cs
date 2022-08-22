using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_Picker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Color ColorPicker(Point coord)
        {
            Bitmap bitmap = new Bitmap(1, 1);
            Graphics grap = Graphics.FromImage(bitmap);
            grap.CopyFromScreen(coord,new Point(0,0),new Size(1,1));

            return bitmap.GetPixel(0,0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Color CP = ColorPicker(new Point(MousePosition.X,MousePosition.Y));
            textBox1.Text = "#" + CP.R.ToString("X2") + CP.G.ToString("X2") + CP.B.ToString("X2");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F)
            {
                timer2.Start();
                Clipboard.SetText(textBox1.Text);
            }
        }

        int ani = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if(ani == 1)
            {
                label1.Visible = true;
            }

            if(ani > 5)
            {
                ani = 0;
                label1.Visible = false;
                timer2.Stop();
            }
            else
            {
                ani++;
            }

        }
    }
}
