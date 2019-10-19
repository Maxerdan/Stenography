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

namespace Stenography
{
    public partial class Form1 : Form
    {
        string FileName;
        Image LoadImage;
        Bitmap Bitmap;

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void choosePic_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Изображения:|*.jpg;*.jpeg;*.bmp;*.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = dialog.FileName;
                    LoadImage = Image.FromFile(FileName);
                    pictureBox1.Image = LoadImage;
                }
            }
        }

        private void buttonCode_Click(object sender, EventArgs e)
        {
            byte[] bytes = Encoding.ASCII.GetBytes("Hello world! 404");
            string bitString = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                string bits = Convert.ToString(bytes[i], 2);
                if (bits.Length < 8)
                {
                    int len = bits.Length;
                    bits = ReverseString(bits);
                    for (; len < 8; len++)
                    {
                        bits += "0";
                    }
                    bits = ReverseString(bits);
                }
                bitString += bits;
            }

            Bitmap = new Bitmap(FileName, true);

            for (int x = 0; x < Bitmap.Width; x++)
            {
                for (int y = 0; y < Bitmap.Height; y++)
                {
                    Color pixelColor = Bitmap.GetPixel(x, y);
                    // метод изменяющий последний бит на нужный
                    


                    Color newColor = Color.FromArgb(0, 0, 0);
                    Bitmap.SetPixel(x, y, newColor);
                    MessageBox.Show(Convert.ToString(bytes[12], 2));
                    //MessageBox.Show(Convert.ToString(bytes[0], 2)); //Метод для перевода в двоичную систему

                }
            }
            pictureBox1.Image = Bitmap;
        }
    }
}
