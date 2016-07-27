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


namespace MuscleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Polygon p = new Polygon();
        private double imgWidth, imgHeight;
        private Image img; 

        public MainWindow()
        {
            InitializeComponent(); 
            img = ((Image)FindName("imgBody"));
            
            Loaded += delegate
            {
                imgWidth = img.ActualWidth;
                imgHeight = img.ActualHeight;
                // access ActualWidth and ActualHeight here
                initPolygons();
                canvas.Width = img.ActualWidth;
                canvas.Height = img.ActualHeight;
               // TextBox tb = new TextBox();
                canvas.Children.Add(p);
                desc.Visibility = Visibility.Hidden;
                //canvas.Children.Add(tb);
                //tb.Text = "Hello";

                //tb.Height = imgHeight * (0.13919 - 0.043956);
                //tb.Width = imgWidth * (0.665 - 0.3112);
                /*tb.RenderTransform = new TranslateTransform
                {
                    X = imgWidth * 0.3112,
                    Y = imgHeight * 0.043956
                };*/
               
                desc.Text = "Hello";

                desc.Height = imgHeight * (0.13919 - 0.043956);
                desc.Width = imgWidth * (0.665 - 0.3112);
                desc.RenderTransform = new TranslateTransform
                {
                    X = imgWidth * 0.3112,
                    Y = imgHeight * 0.043956
                };
            };

         
           

        }

        private void Image_DragOver(object sender, DragEventArgs e)
        {
            
        }

       
        public void initPolygons()
        {
            // Create a blue and a black Brush
            SolidColorBrush yellowBrush = new SolidColorBrush();
            yellowBrush.Color = Colors.Yellow;
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;

           
           
            p.Stroke = blackBrush;
            p.Fill = yellowBrush;
            p.StrokeThickness = 4;
            p.Points.Add(new Point(0,0));//top left corner
            p.Points.Add(new Point(imgWidth/10, 0));//top right corner
            p.Points.Add(new Point(imgWidth / 10, img.ActualHeight/10));//bottom right corner
            p.Points.Add(new Point(0, imgHeight/10));//bottom left corner
        }
        
        
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            /* Point mousePt = e.GetPosition((Canvas)sender);//mouse point relative to image
             if (pnpoly(p.Points.Count, mousePt.X, mousePt.Y))
             {
                 p.Opacity = 0;
                 desc.Visibility = Visibility.Visible; 
             }else
             {
                 //p.Visibility = Visibility.Hidden;
                 desc.Visibility = Visibility.Hidden;
             }*/
            p.Opacity = 100;
            //desc.Opacity = 100;

            desc.Visibility = Visibility.Visible;
        }

        private void canvas_MouseLeave(object sender, MouseEventArgs e)
        {
            /*Point mousePt = e.GetPosition((Canvas)sender);//mouse point relative to image
            if (pnpoly(p.Points.Count, mousePt.X, mousePt.Y))
            {
                p.Opacity = 0;
                desc.Visibility = Visibility.Visible;
            }
            else
            {
                //p.Visibility = Visibility.Hidden;
                desc.Visibility = Visibility.Hidden;
            }*/
            p.Opacity = 0;
            //desc.Opacity = 0;

            desc.Visibility = Visibility.Hidden;
        }

        bool pnpoly(int nvert, double testx, double testy)
        {
            int i, j;
            bool c = false;
            for (i = 0, j = nvert - 1; i < nvert; j = i++)
            {
                if (((p.Points.ElementAt(i).Y > testy) != (p.Points.ElementAt(j).Y > testy)) &&
                 (testx < (p.Points.ElementAt(j).X - p.Points.ElementAt(i).X) * (testy - p.Points.ElementAt(i).Y) / (p.Points.ElementAt(j).Y - p.Points.ElementAt(i).Y) + p.Points.ElementAt(i).X))
                    c = !c;
            }
            return c;
        }
    }
}
