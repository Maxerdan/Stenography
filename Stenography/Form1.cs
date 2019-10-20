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
            // добавить(изменить) текст из бокса
            byte[] bytes = Encoding.ASCII.GetBytes("Hello world! 404");
            string bitString = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                bitString += Convert.ToString(bytes[i], 2).PadLeft(8, '0');
            }
            for(int i = 0; i < 8; i++)
            {
                bitString += '0';
            }

            Bitmap = new Bitmap(FileName, true);
            bool is_brake = false;
            for (int x = 0; x < Bitmap.Width; x++)
            {
                for (int y = 0; y < Bitmap.Height; y++)
                {
                    Color pixelColor = Bitmap.GetPixel(x, y);
                    // метод изменяющий последний бит на нужный
                    var R = Convert.ToString(pixelColor.R, 2).PadLeft(8, '0');
                    var G = Convert.ToString(pixelColor.G, 2).PadLeft(8, '0');
                    var B = Convert.ToString(pixelColor.B, 2).PadLeft(8, '0');
                    if(bitString.Length == 0)
                    {
                        is_brake = true;
                        break;
                    }
                    ChangeColor(ref bitString, ref R);

                    if (bitString.Length == 0)
                    {
                        is_brake = true;
                        break;
                    }
                    ChangeColor(ref bitString, ref G);

                    if (bitString.Length == 0)
                    {
                        is_brake = true;
                        break;
                    }
                    ChangeColor(ref bitString, ref B);

                    Bitmap.SetPixel(x, y, Color.FromArgb(Convert.ToInt32(R, 2), Convert.ToInt32(G, 2), Convert.ToInt32(B, 2)));
                }
                if (is_brake)
                    break;
            }
            pictureBox1.Image = Bitmap;
            // добавить выбор куда сохранять
            Bitmap.Save("img.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        void ChangeColor(ref string bitString, ref string color)
        {
            color = color.Remove(color.Length - 1);
            color += bitString[0];
            bitString = bitString.Remove(0, 1);
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {

        }
    }
}
