using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gma.System.Windows;
namespace KeyboardHook
{
    public partial class Form1 : Form
    {
        UserActivityHook actHook;
        public Form1()
        {
            InitializeComponent();
            actHook = new UserActivityHook(); // crate an instance with global hooks
            //hang on events
            actHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
            actHook.KeyDown += new KeyEventHandler(MyKeyDown);
            actHook.KeyPress += new KeyPressEventHandler(MyKeyPress);
            actHook.KeyUp += new KeyEventHandler(MyKeyUp);
            actHook.Start();
        }

        private void MyKeyUp(object sender, KeyEventArgs e)
        {
            richTextBox1.AppendText("KeyUp: " + e.KeyData.ToString() + "\n");
            richTextBox1.ScrollToCaret();
        }
        private void MyKeyPress(object sender, KeyPressEventArgs e)
        {
            richTextBox1.AppendText("KeyPress: " + e.KeyChar.ToString() + "\n");
            richTextBox1.ScrollToCaret();
        }
        private void MyKeyDown(object sender, KeyEventArgs e)
        {
            richTextBox1.AppendText("KeyDown: " + e.KeyData.ToString() + "\n");
            richTextBox1.ScrollToCaret();
        }
        private void MouseMoved(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = "X: " + e.X.ToString();
            toolStripStatusLabel2.Text = "Y:" + e.Y.ToString();
            if (e.Clicks > 0)
            {
                richTextBox1.AppendText("Mouse: " + e.Button.ToString() + "\n");
                richTextBox1.ScrollToCaret();
            }

        }
    }
}
