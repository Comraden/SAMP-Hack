using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samp_Hack
{
    public partial class Form1 : Form
    {
        static VAMemory vam;
        static int aPlayer = 0x00B6F5F0;
        static int aUnlimRun = 0x00B7CEE4;
        static int aGravity = 0x00863984;
        static int oHealth = 0x00000540;
        static int oInvisible = 0x00000474;
        static int aInvisible;
        static int aHealth;

        public Form1()
        {
            InitializeComponent();
            try 
            {
                vam = new VAMemory("gta_sa");
                aInvisible = vam.ReadInt32((IntPtr)aPlayer) + oInvisible;
                aHealth = vam.ReadInt32((IntPtr)aPlayer) + oHealth;
            }
            catch { MessageBox.Show("Process not running! Please restart the game"); }
            updateHealth.Enabled = true;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            SetGravity(checkBox2.Checked);
            UnlimRun(checkBox3.Checked);
            SetInvisible(checkBox4.Checked);
        }
        private void Heal(bool flag) 
        {
            if(flag == true)
            {
                vam.WriteFloat((IntPtr)aHealth, 100f);
            }
        }
        private void SetGravity(bool flag) 
        {
            if (flag == true)
            {vam.WriteFloat((IntPtr)aGravity, 0.004f);}
            else
            {vam.WriteFloat((IntPtr)aGravity,0.008f);}
        }
        private void UnlimRun(bool flag) 
        {
            if (flag == true){vam.WriteByte((IntPtr)aUnlimRun, 1);}
            else
            {vam.WriteByte((IntPtr)aUnlimRun, 0);}
        }
        private void SetInvisible(bool flag) 
        {
            if (flag == true)
            { vam.WriteByte((IntPtr)aInvisible, 2); }
            else
            { vam.WriteByte((IntPtr)aInvisible, 1); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Heal(true);
        }

        private void updateHealth_Tick(object sender, EventArgs e)
        {
            float health = vam.ReadFloat((IntPtr)aHealth);
            label2.Text = Convert.ToString(health);
        }
    }
}
//Convert.ToDouble(textBox1.Text)
