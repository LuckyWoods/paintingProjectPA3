using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using paintingProject;

namespace paintingProject
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        public int changeRedCol = 0; //this is a private variable, used as a counter for changing the color values of red.
        public int changeGreenCol = 0; //this is a private variable, used as a counter for changing the color values of green.
        public int changeBlueCol = 0; //this is a private variable, used as a counter for changing the color values of blue.
        public double changePen = 0; //this is a private variable, used as a counter for changing the pens size.


        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Canvy.Strokes.Clear(); //this helps clear the entire canvas board.
        }


        private void Pen_Red_Click(object sender, RoutedEventArgs e)
        {
            changeRedCol++; //Adds a counter to the variable

            if (changeRedCol == 3)
            {
                changeRedCol = 0;  //Resets counter to zero.
            }

            if (changeRedCol == 0 || changeRedCol == 3)
            {
                Canvy.DefaultDrawingAttributes.Color = Canvy.DefaultDrawingAttributes.Color - Color.FromRgb(255, 0, 0);  //removes red colors value
            }

            else if (changeRedCol == 1)
            {
                Canvy.DefaultDrawingAttributes.Color = Canvy.DefaultDrawingAttributes.Color + Color.FromRgb(127, 0, 0); //Adds red color value by around half, 127
            }

            else if (changeRedCol == 2)
            {
                Canvy.DefaultDrawingAttributes.Color = Canvy.DefaultDrawingAttributes.Color + Color.FromRgb(128, 0, 0); //Adds remaining red color value, 128
            }

        }

        private void Pen_Green_Click(object sender, RoutedEventArgs e)
        {
            changeGreenCol++; //Adds a counter to the variable

            if (changeGreenCol == 3)
            {
                changeGreenCol = 0; //Resets counter to zero.
            }

            if (changeGreenCol == 0)
            {
                Canvy.DefaultDrawingAttributes.Color = Canvy.DefaultDrawingAttributes.Color - Color.FromRgb(0, 255, 0); //removes green color value
            }

            else if (changeGreenCol == 1)
            {
                Canvy.DefaultDrawingAttributes.Color = Canvy.DefaultDrawingAttributes.Color + Color.FromRgb(0, 127, 0); //Adds green color value by around half, 127
            }

            else if (changeGreenCol == 2)
            {
                Canvy.DefaultDrawingAttributes.Color = Canvy.DefaultDrawingAttributes.Color + Color.FromRgb(0, 128, 0); //Adds remaining green color value, 128
            }

        }

        private void Pen_Blue_Click(object sender, RoutedEventArgs e)
        {
            changeBlueCol++; //Adds a counter to the variable

            if (changeBlueCol == 3)
            {
                changeBlueCol = 0; //Resets counter to zero.
            }

            if (changeBlueCol == 0)
            {
                Canvy.DefaultDrawingAttributes.Color = Canvy.DefaultDrawingAttributes.Color - Color.FromRgb(0, 0, 255); //removes blue color value.
            }

            else if (changeBlueCol == 1)
            {
                Canvy.DefaultDrawingAttributes.Color = Canvy.DefaultDrawingAttributes.Color + Color.FromRgb(0, 0, 127); //Adds blue color value by around half, 127
            }

            else if (changeBlueCol == 2)
            {
                Canvy.DefaultDrawingAttributes.Color = Canvy.DefaultDrawingAttributes.Color + Color.FromRgb(0, 0, 128); //Adds remaining blue color value, 128
            }

        }

        private void Pen_ColReset_Click(object sender, RoutedEventArgs e)
        {

            Canvy.DefaultDrawingAttributes.Color = Color.FromRgb(0, 0, 0);
            mySliderRed.Value = 0;
            mySliderGreen.Value = 0;
            mySliderBlue.Value = 0;

        }


        private void Thickness_Click(object sender, RoutedEventArgs e)
        {

            changePen = changePen + 0.5; //Adds 0.5 to the variable

            if (changePen > 5)
            {
                changePen = 0.5; //resets it back to 0.5 for the pen size being smaller
            }

            Canvy.DefaultDrawingAttributes.Width = changePen; //updates pen width.
            Canvy.DefaultDrawingAttributes.Height = changePen; //updates pen size


        }

        private void Thickness_Reset_Click(object sender, RoutedEventArgs e)
        {
            changePen = 1; //resets the pen size to 1.
            Canvy.DefaultDrawingAttributes.Width = changePen; //updates pen width.
            Canvy.DefaultDrawingAttributes.Height = changePen; //updates pen size
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ILineShape getShape(Shape nameShape)
            {
                if ((Shape)0 == nameShape)
                {
                    return new Line(); //returns that a Line is drawn
                    changePen = 1;
                    Canvy.DefaultDrawingAttributes.Width = changePen; //updates pen width.
                    Canvy.DefaultDrawingAttributes.Height = changePen; //updates pen size

                }

                else if ((Shape)1 == nameShape)
                {
                    return new Horizontal(); //returns that a Circle is drawn
                    Canvy.DefaultDrawingAttributes.Width = 20;
                }

                else if ((Shape)2 == nameShape)
                {

                    return new Vertical(); //returns that a Rectangle is drawn
                    Canvy.DefaultDrawingAttributes.Height = 20;

                }

                else
                {
                    return null; //Returns Null
                }
            }
        }

        double changeRed = 0;
        byte redB = 0;

        double changeBlue = 0;
        byte blueB = 0;
        public virtual void mySlider_BlueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            changeBlue = mySliderBlue.Value;

            blueB = Convert.ToByte(changeBlue);

            Canvy.DefaultDrawingAttributes.Color = Color.FromRgb(redB, greenB, blueB);
        }

        double changeGreen = 0;
        byte greenB = 0;
        public virtual void mySlider_GreenChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            changeGreen = mySliderGreen.Value;

            greenB = Convert.ToByte(changeGreen);

            Canvy.DefaultDrawingAttributes.Color = Color.FromRgb(redB, greenB, blueB);
        }

        public virtual void mySlider_RedChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            changeRed = mySliderRed.Value;

            redB = Convert.ToByte(changeRed);


            Canvy.DefaultDrawingAttributes.Color = Color.FromRgb(redB, greenB, blueB);
        }


        private void mySlider_GreyChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //ChangeColor colors = new ChangeColor(sender, e);
            redB = Convert.ToByte(mySliderGrey.Value) ;
            greenB = Convert.ToByte(mySliderGrey.Value);
            blueB = Convert.ToByte(mySliderGrey.Value);
            mySliderRed.Value = mySliderGrey.Value;
            mySliderBlue.Value = mySliderGrey.Value;
            mySliderGreen.Value = mySliderGrey.Value;

            Canvy.DefaultDrawingAttributes.Color = Color.FromRgb(redB, greenB, blueB);
        }

    }

    class ChangeColor : MainWindow
    {
        public ChangeColor(object sender, RoutedPropertyChangedEventArgs<double> e) : base(){
        }



        public override void mySlider_GreenChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Byte greenB = Convert.ToByte(mySliderRed.Value);
            mySliderGreen.Value = mySliderRed.Value;

        }

        public override void mySlider_BlueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Byte blueB = Convert.ToByte(mySliderRed.Value);
            mySliderBlue.Value = mySliderRed.Value;
        }
    }

   

}