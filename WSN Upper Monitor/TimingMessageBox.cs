using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSN_Upper_Monitor
{
    public partial class TimingMessageBox : Form
    {
        public TimingMessageBox()
        {
            InitializeComponent();  //窗口初始化
        }
        private int second;

        private int counter;
        public TimingMessageBox(string message, int second)    //弹出窗口提醒
        {
            InitializeComponent();
            this.labelMessage.Text = message;
            this.second = second;
            this.counter = 0;
            this.buttonOK.Text = string.Format("确定({0})", this.second - this.counter);   //弹窗时长

            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Start();
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();   //点击确定即关闭
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.counter <= this.second)
            {
                this.buttonOK.Text = string.Format("确定({0})", this.second - this.counter);
                this.Refresh();                   //时间刷新
                this.counter++;    
            }
            else
            {
                this.timer1.Enabled = false;
                this.timer1.Stop();
                this.Close();
            }
        }

        private void TimingMessageBox_Load(object sender, EventArgs e)
        {

        }
    }
}
