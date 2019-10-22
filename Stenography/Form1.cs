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
        string FileName; // путь до файла
        Image LoadImage; // само изображение
        Bitmap Bitmap; // карта пикселей изображения

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void choosePic_Click(object sender, EventArgs e) // выбор изображения
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Изображения:|*.jpg;*.jpeg;*.bmp;*.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = dialog.FileName; 
                    LoadImage = Image.FromFile(FileName);
                    pictureBox1.Image = LoadImage; // вывод на экран
                }
            }
        }

        private void buttonCode_Click(object sender, EventArgs e) // кодирование в выбранное изображение
        {
            string bitString = GetStringOfBinaryCode();
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
                    if (bitString.Length == 0)
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
            
            using (SaveFileDialog dialog = new SaveFileDialog()) // выбор куда сохранять
            {
                dialog.Filter = "Изображения:|*.jpg;*.jpeg;*.bmp;*.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }

        private string GetStringOfBinaryCode() // получение строки двоичного кода для последующего кодирования
        {
            byte[] bytes = Encoding.ASCII.GetBytes(textToCode.Text);
            string bitString = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                bitString += Convert.ToString(bytes[i], 2).PadLeft(8, '0');
            }
            for (int i = 0; i < 8; i++)
            {
                bitString += '0';
            }

            return bitString;
        }

        void ChangeColor(ref string bitString, ref string color) // удаление последнего бита цвета и запись нужного
        {
            color = color.Remove(color.Length - 1);
            color += bitString[0];
            bitString = bitString.Remove(0, 1);
        }

        private void buttonDecode_Click(object sender, EventArgs e) // декодирование изображения
        {
            string decodeString = "";
            string decodePix = "";
            bool is_brake = false;
            Bitmap = new Bitmap(FileName, true);
            for(int x = 0; x < Bitmap.Width; x++)
            {
                for(int y = 0; y < Bitmap.Height; y++)
                {
                    Color pixelColor = Bitmap.GetPixel(x, y);
                    var R = Convert.ToString(pixelColor.R, 2).PadLeft(8, '0');
                    var G = Convert.ToString(pixelColor.G, 2).PadLeft(8, '0');
                    var B = Convert.ToString(pixelColor.B, 2).PadLeft(8, '0');

                    if (decodePix.Length != 8)
                    {
                        decodePix += R[7];
                    }
                    else if(decodePix == "00000000")
                    {
                        is_brake = true;
                        break;
                    }
                    else
                    {
                        decodeString += decodePix;
                        decodePix = "";
                        decodePix += R[7];
                    }

                    if (decodePix.Length != 8)
                    {
                        decodePix += G[7];
                    }
                    else if (decodePix == "00000000")
                    {
                        is_brake = true;
                        break;
                    }
                    else
                    {
                        decodeString += decodePix;
                        decodePix = "";
                        decodePix += G[7];
                    }

                    if (decodePix.Length != 8)
                    {
                        decodePix += B[7];
                    }
                    else if (decodePix == "00000000")
                    {
                        is_brake = true;
                        break;
                    }
                    else
                    {
                        decodeString += decodePix;
                        decodePix = "";
                        decodePix += B[7];
                    }
                }
                if (is_brake)
                    break;
            }

            int deStr_Size = decodeString.Length / 8; 
            byte[] bytes = new byte[deStr_Size];
            for(int i = 0; i < deStr_Size; i++) // цикл для перевода 8 битов двоичного кода в байтовое представление
            {
                var one_byte = decodeString.Substring(0, 8);
                var integerByte = Convert.ToInt32(one_byte, 2);
                bytes[i] = (byte)integerByte;
                decodeString = decodeString.Substring(8);
            }
            decodeString = Encoding.ASCII.GetString(bytes); // перевод из байтов в символы текста
            MessageBox.Show(decodeString);
        }
    }
}
