using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema3
{
    public partial class MACHandler : Form
    {
        private HMAC myMAC;
        ConversionHandler myConverter = new ConversionHandler();

         public MACHandler()
         {
             InitializeComponent();
         }
        public MACHandler(string name)
        {
            if (name.CompareTo("SHAl") == 0) {
                myMAC = new System.Security.Cryptography.HMACSHA1();
            }
            if (name.CompareTo("MDS" ) == 0) {
                myMAC = new System.Security.Cryptography.HMACMD5();
            }
            if (name.CompareTo("RIPEMD") == 0) {
                myMAC = new System.Security.Cryptography.HMACRIPEMD160();
            }
            if (name.CompareTo("SHA256")	==0) {
                myMAC = new System.Security.Cryptography.HMACSHA256();
            }
            if (name.CompareTo("SHA384")==	0) {
                myMAC = new HMACSHA384();
            }
            if (name.CompareTo("SHA512")==	0) {
                myMAC = new System.Security.Cryptography.HMACSHA512();
            }
        }

        public bool CheckAuthenticity(byte[] mes, byte[] mac, byte[] key)
        {
            myMAC.Key = key;
            if (CompareByteArrays(myMAC.ComputeHash(mes), mac, myMAC.HashSize / 8) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public byte[] ComputeMAC(byte[] mes, byte[] key)
        {
            myMAC.Key = key;
            return myMAC.ComputeHash(mes);
        }

        public int MACBytelength()
        {
            return myMAC.HashSize / 8;
        }

        private bool CompareByteArrays(byte[] a, byte[] b, int len)
        {
            for (int i = 0; i < len; i++)
                if (a[i] != b[i]) return false; return true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MACHandler mh = new MACHandler(comboBox1.Text);
            byte[] mac = mh.ComputeMAC(myConverter.StringToByteArray(textBox2.Text), myConverter.StringToByteArray(textBox1.Text));
            textBox3.Text = myConverter.ByteArrayToString(mac);
            textBox4.Text = myConverter.ByteArrayToHexString(mac);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MACHandler mh = new MACHandler(comboBox1.Text);
            if (mh.CheckAuthenticity(myConverter.StringToByteArray(textBox2.Text), myConverter.HexStringToByteArray(textBox4.Text), myConverter.StringToByteArray(textBox1.Text)) == true)
            {
                MessageBox.Show("MAC OK !!!");
            }
            else
            {
                MessageBox.Show("MAC NOT OK !!!");
            }
        }

    }
}

