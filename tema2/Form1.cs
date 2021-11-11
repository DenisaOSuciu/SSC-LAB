using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;



namespace tema2 
{

    public partial class Form1 : Form
    {
       ConversionHandler myConverter = new ConversionHandler();
        SymmetricAlgorithm mySymmetricAlg;
        
        public Form1()
        {
            InitializeComponent();
        }
        public void Generate(string cipher)
        {

            switch (cipher)
            {
                case "DES":
                    mySymmetricAlg = DES.Create();
                    break;
                case "3DES":
                    mySymmetricAlg = TripleDES.Create();
                    break;
                case "Rijndael":
                    mySymmetricAlg = Rijndael.Create();
                    break;
            }
            mySymmetricAlg.GenerateIV(); mySymmetricAlg.GenerateKey();
        }
        public byte[] Encrypt(byte[] mess, byte[] key, byte[] iv)
        {
            mySymmetricAlg.Key = key;
            mySymmetricAlg.IV = iv;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, mySymmetricAlg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(mess, 0, mess.Length); cs.Close();
            return ms.ToArray();
        }

        public byte[] Decrypt(byte[] mess, byte[] key, byte[] iv)
        {
            byte[] plaintext = new byte[mess.Length];
            mySymmetricAlg.Key = key; 
            mySymmetricAlg.IV = iv;
            MemoryStream ms = new MemoryStream(mess);
            CryptoStream cs = new CryptoStream(ms, mySymmetricAlg.CreateDecryptor(), CryptoStreamMode.Read);
            cs.Read(plaintext, 0, mess.Length); cs.Close();
            return plaintext;
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            Generate(comboBox1.Text); 
            textBox1.Text =myConverter.ByteArrayToHexString(mySymmetricAlg.Key); 
            textBox2.Text =myConverter.ByteArrayToHexString(mySymmetricAlg.IV);



        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] ciphertext = Encrypt(myConverter.StringToByteArray(textBox3.Text), myConverter.HexStringToByteArray(textBox1.Text), myConverter.HexStringToByteArray(textBox2.Text)); 
            textBox5.Text = myConverter.ByteArrayToString(ciphertext); 
            textBox6.Text =myConverter.ByteArrayToHexString(ciphertext); 
            textBox3.Text =myConverter.ByteArrayToHexString(myConverter.StringToByteArray(textBox3.Text));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] plaintext = Decrypt(myConverter.HexStringToByteArray(textBox6.Text),myConverter.HexStringToByteArray(textBox1.Text), myConverter.HexStringToByteArray(textBox2.Text));
            textBox3.Text = myConverter.ByteArrayToString(plaintext);
            textBox4.Text = myConverter.ByteArrayToHexString(plaintext);

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            mySymmetricAlg.GenerateIV(); // generates a fresh IV
            mySymmetricAlg.GenerateKey(); // generates a fresh Key

            MemoryStream ms =new MemoryStream(); 
            CryptoStream cs= new CryptoStream(ms,mySymmetricAlg.CreateEncryptor(), CryptoStreamMode.Write);
            byte[] mes_block = new byte[8];
            long start_time = DateTime.Now.Ticks; int count = 10000000;
            for (int i = 0; i < count; i++)
            {
                cs.Write(mes_block, 0, mes_block.Length);
            }
            cs.Close();
            double operation_time = (DateTime.Now.Ticks - start_time); 
            operation_time = operation_time / (10 * count);
            
            label9.Text = "Time for encryption of a message block: " + operation_time.ToString() + "  us" ;

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            mySymmetricAlg.GenerateIV(); // generates a fresh IV
            mySymmetricAlg.GenerateKey(); // generates a fresh Key

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, mySymmetricAlg.CreateDecryptor(), CryptoStreamMode.Read);
            byte[] mes_block = new byte[8];
            long start_time = DateTime.Now.Ticks; int count = 10000000;
            for (int i = 0; i < count; i++)
            {
                cs.Read(mes_block, 0, mes_block.Length);
            }
            cs.Close();
            double operation_time = (DateTime.Now.Ticks - start_time);
            operation_time = operation_time / (10 * count);

            label10.Text = "Time for decryption of a message block: " + operation_time.ToString() + "  us";

        }
    }
}

