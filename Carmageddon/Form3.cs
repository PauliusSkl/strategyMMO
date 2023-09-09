using Carmageddon.Forms.Decorator;
using Carmageddon.Forms.Composite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carmageddon.Forms
{
    public partial class Form3 : Form
    {
        private string selectedButton = "";
        private string carType = "";
        private string carColor = "";
        private string background = "";
        private string grid = "";
        private Image _car;
        private Image _background;
        private Image _grid;
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
    }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string carpath = Directory.GetCurrentDirectory() + "\\Resources\\small.png";
            using (var bmpTemp = new Bitmap(carpath))
            {
                _car = new Bitmap(bmpTemp);
            }
            pictureBox1.Image = _car;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button8.Visible = true;
            carType = "small";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string carpath = Directory.GetCurrentDirectory() + "\\Resources\\medium.png";
            using (var bmpTemp = new Bitmap(carpath))
            {
                _car = new Bitmap(bmpTemp);
            }
            pictureBox1.Image = _car;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button8.Visible = true;
            carType = "medium";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string carpath = Directory.GetCurrentDirectory() + "\\Resources\\big.png";
            using (var bmpTemp = new Bitmap(carpath))
            {
                _car = new Bitmap(bmpTemp);
            }
            pictureBox1.Image = _car;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button8.Visible = true;
            carType = "big";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string carpath = Directory.GetCurrentDirectory() + "\\Resources\\Models\\"+ carType +"_green.png";
            using (var bmpTemp = new Bitmap(carpath))
            {
                _car = new Bitmap(bmpTemp);
            }
            pictureBox1.Image = _car;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            carColor = "_green";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string carpath = Directory.GetCurrentDirectory() + "\\Resources\\Models\\" + carType + "_purple.png";
            using (var bmpTemp = new Bitmap(carpath))
            {
                _car = new Bitmap(bmpTemp);
            }
            pictureBox1.Image = _car;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            carColor = "_purple";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string carpath = Directory.GetCurrentDirectory() + "\\Resources\\Models\\" + carType + "_yellow.png";
            using (var bmpTemp = new Bitmap(carpath))
            {
                _car = new Bitmap(bmpTemp);
            }
            pictureBox1.Image = _car;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            carColor = "_yellow";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Visible = false;
            if (selectedButton == "background")
            {
                string imagePathNew = Directory.GetCurrentDirectory() + "\\Resources\\Models\\" + background;
                string removePathOld = Directory.GetCurrentDirectory() + "\\Resources\\background.png";
                if (File.Exists(removePathOld) && File.Exists(imagePathNew))
                {
                    File.Delete(removePathOld);
                    File.Copy(imagePathNew, removePathOld);
                    label1.Text = "background image updated!";
                    pictureBox1.Image = null;
                }
            }

            if (selectedButton == "grid")
            {
                string imagePathNew = Directory.GetCurrentDirectory() + "\\Resources\\Models\\" + grid;
                string removePathOld = Directory.GetCurrentDirectory() + "\\Resources\\500x500.png";
                if (File.Exists(removePathOld) && File.Exists(imagePathNew))
                {
                    File.Delete(removePathOld);
                    File.Copy(imagePathNew, removePathOld);
                    label1.Text = "grid updated!";
                    pictureBox1.Image = null;
                }
            }

            if (selectedButton == "car")
            {
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button8.Visible = false;
                string imagePathNew = Directory.GetCurrentDirectory() + "\\Resources\\Models\\" + carType + carColor + ".png";
                string removePathOld = Directory.GetCurrentDirectory() + "\\Resources\\" + carType + ".png";
                if (File.Exists(removePathOld) && File.Exists(imagePathNew))
                {
                    File.Delete(removePathOld);
                    File.Copy(imagePathNew, removePathOld);
                    label1.Text = carType + " car has been updated!";
                    pictureBox1.Image = null;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string smallCar = Directory.GetCurrentDirectory() + "\\Resources\\Models\\small_default.png";
            string mediumCar = Directory.GetCurrentDirectory() + "\\Resources\\Models\\medium_default.png";
            string bigCar = Directory.GetCurrentDirectory() + "\\Resources\\Models\\big_default.png";

            string smallCarNew = Directory.GetCurrentDirectory() + "\\Resources\\small.png";
            string mediumCarNew = Directory.GetCurrentDirectory() + "\\Resources\\medium.png";
            string bigCarNew = Directory.GetCurrentDirectory() + "\\Resources\\big.png";

            string gridOld = Directory.GetCurrentDirectory() + "\\Resources\\Models\\white.png";
            string gridNew = Directory.GetCurrentDirectory() + "\\Resources\\500x500.png";

            string backgroundOld = Directory.GetCurrentDirectory() + "\\Resources\\Models\\default.png";
            string backgroundNew = Directory.GetCurrentDirectory() + "\\Resources\\background.png";


            if (File.Exists(smallCarNew) && File.Exists(mediumCarNew) && File.Exists(bigCarNew)
                && File.Exists(gridNew) && File.Exists(backgroundNew))
            {
                File.Delete(smallCarNew);
                File.Delete(mediumCarNew);
                File.Delete(bigCarNew);
                File.Delete(gridNew);
                File.Delete(backgroundNew);

                File.Copy(smallCar, smallCarNew);
                File.Copy(mediumCar, mediumCarNew);
                File.Copy(bigCar, bigCarNew);
                File.Copy(gridOld, gridNew);
                File.Copy(backgroundOld, backgroundNew);
                pictureBox1.Image = null;
                label1.Text = "all settings have been reset!";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            button9.Visible = false;
            button8.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button10.Visible = true;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button11.Visible = true;
            selectedButton = "car";

        }

        private void button10_Click(object sender, EventArgs e)
        {
            ButtonComposite _buttonComposite = new ButtonComposite(button10);
            _buttonComposite.Add(new Leaf(button12));
            _buttonComposite.Add(new Leaf(button13));
            _buttonComposite.Add(new Leaf(button14));
            _buttonComposite.Display();

            pictureBox1.Image = null;
            button9.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
            button10.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button11.Visible = true;
            selectedButton = "background";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            button11.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
            button15.Visible = true;
            button16.Visible = true;
            button17.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            selectedButton = "grid";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string backPath = Directory.GetCurrentDirectory() + "\\Resources\\Models\\default.png";
            using (var bmpTemp = new Bitmap(backPath))
            {
                _background = new Bitmap(bmpTemp);
            }
            pictureBox1.Image = _background;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            background = "default.png";
            button8.Visible = true;

        }

        private void button13_Click(object sender, EventArgs e)
        {
            string backPath = Directory.GetCurrentDirectory() + "\\Resources\\Models\\blue.png";
            using (var bmpTemp = new Bitmap(backPath))
            {
                _background = new Bitmap(bmpTemp);
            }
            pictureBox1.Image = _background;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            background = "blue.png";
            button8.Visible = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string backPath = Directory.GetCurrentDirectory() + "\\Resources\\Models\\old.png";
            using (var bmpTemp = new Bitmap(backPath))
            {
                _background = new Bitmap(bmpTemp);
            }
            pictureBox1.Image = _background;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            background = "old.png";
            button8.Visible = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //string backPath = Directory.GetCurrentDirectory() + "\\Resources\\Models\\white.png";
            //using (var bmpTemp = new Bitmap(backPath))
            //{
            //    _grid = new Bitmap(bmpTemp);
            //}
            var gridComp = new GridComponent();
            var decorator = new WhiteGridDecorator();
            decorator.SetComponent(gridComp);


            pictureBox1.Image = decorator.GetImage();
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            grid = "white.png";
            button8.Visible = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var gridComp = new GridComponent();
            var decorator = new InvertedGridDecorator();
            decorator.SetComponent(gridComp);


            pictureBox1.Image = decorator.GetImage();
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            grid = "inverted.png";
            button8.Visible = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var gridComp = new GridComponent();
            var decorator = new ColorfulGridDecorator();
            decorator.SetComponent(gridComp);


            pictureBox1.Image = decorator.GetImage();
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            grid = "colorful.png";
            button8.Visible = true;
        }
    }
}
