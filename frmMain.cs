using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace _8_Ball_Pool___Aim_Hack
{
    public partial class frmMain : Form
    {
        //1.0 - Pot Locations
        Point[] pots = new Point[] { new Point(42, 46), new Point(370, 40), new Point(696, 46), new Point(42, 367), new Point(370, 376), new Point(696, 369) };

        Point mousePosition = new Point();
        Pen pen = new Pen(Color.Red, 1);
        Graphics g;
        GlobalKeyboardHook gHook;

        bool transparent = false;

        public frmMain()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        protected override void OnMouseMove(MouseEventArgs mouseEv)
        {
            mousePosition = mouseEv.Location;
        }

        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            g.Clear(Color.White);
            foreach (Point p in pots)
            {
                g.DrawLine(pen, mousePosition, p);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            gHook = new GlobalKeyboardHook();
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);

            gHook.hook();
        }

        private void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.LShiftKey)
            {
                g.Clear(Color.White);
            }

            if (e.KeyValue == (char)Keys.LControlKey)
            {
                if (!transparent)
                {
                    this.TransparencyKey = Color.White;
                    this.Opacity = 1;
                } else
                {
                    this.TransparencyKey = Color.Black;
                    this.Opacity = 0.3;
                }
                transparent = !transparent;
            }
        }
    }
}
