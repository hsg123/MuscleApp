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

        //private Polygon p = new Polygon();
        private double imgWidth, imgHeight;
        private Image img;
        private Body body;

        public MainWindow()
        {
            InitializeComponent(); 
            img = ((Image)FindName("imgBody"));
            
            Loaded += delegate
            {
                imgWidth = img.ActualWidth;
                imgHeight = img.ActualHeight;
                // access ActualWidth and ActualHeight here
                body = FileHandler.GetPolygonsFromFile("Body.xml");
                initBodyPolygons();
                //initPolygons();
                canvas.Width = img.ActualWidth;
                canvas.Height = img.ActualHeight;
                //canvas.Children.Add(p);
                desc.Visibility = Visibility.Hidden;         
                desc.Text = "Hello";
                desc.Height = imgHeight * (0.13919 - 0.043956);
                desc.Width = imgWidth * (0.665 - 0.3112);
                desc.RenderTransform = new TranslateTransform
                {
                    X = imgWidth * 0.3112,
                    Y = imgHeight * 0.043956
                };
                canvas.Children.Add(body.Muscles[0].MuscleShape);
            };
        }

        private void initBodyPolygons()
        {
            body.Scale(img.ActualWidth, img.ActualHeight);
        }

        private void Image_DragOver(object sender, DragEventArgs e)
        {
            
        }

       
        /*public void initPolygons()
        {
            // Create a blue and a black Brush
            SolidColorBrush yellowBrush = new SolidColorBrush();
            yellowBrush.Color = Colors.Yellow;
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;
            p.Stroke = blackBrush;
            p.Fill = yellowBrush;
            p.StrokeThickness = 0;
            p.Points.Add(new Point(0,0));//top left corner
            p.Points.Add(new Point(imgWidth/10, 0));//top right corner
            p.Points.Add(new Point(imgWidth / 10, img.ActualHeight/10));//bottom right corner
            p.Points.Add(new Point(0, imgHeight/10));//bottom left corner
            p.Opacity = 0;
        }
        */
        
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            //p.Opacity = 100;
            desc.Visibility = Visibility.Visible;
        }

        private void canvas_MouseLeave(object sender, MouseEventArgs e)
        {      
            //p.Opacity = 0;
            desc.Visibility = Visibility.Hidden;
        }

        
    }
}
