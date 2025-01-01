using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortVisualizer
{
    public partial class Form1 : Form
    {
        enum StepType
        {
            Check,
            Swap,
        };

        //
        public Form1()
        {
            InitializeComponent();
        }
        
        Bitmap canvas;
        Graphics gfx;
        private void Form1_Load(object sender, EventArgs e)
        {
            canvas = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            gfx = Graphics.FromImage(canvas);
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            gfx.Clear(Color.DarkSlateGray);



            mainPictureBox.Image = canvas; 
        }
    }
}
