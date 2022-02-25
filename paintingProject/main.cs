using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace paintingProject
{
    public class EntryPoint
    {

        [STAThread]
        public static void Main(string[] args)
        {
            MessageBox.Show("Hello from Main!");
            //Make a pop up for the text above
            var app = new paintingProject.App();
            app.InitializeComponent();
            app.Run();
        }

    }
}
