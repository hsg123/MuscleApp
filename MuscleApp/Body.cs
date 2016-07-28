using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MuscleApp
{
    class Body
    {
        private List<Muscle> muscles = new List<Muscle>();
        
     
        public List<Muscle> Muscles
        {

            get
            {
                return muscles;
            }

            set
            {
                muscles = value;
            }
        }

        public void Scale(double actualWidth, double actualHeight)
        {
            foreach(Muscle m in muscles)
            {
                m.Scale(actualWidth,actualHeight);
            }
        }
    }

    internal class Muscle
    {
        private Polygon muscleShape;

        public Muscle()
        {
            
        }

        public bool CanSee
        {
            set
            {
                if (value)
                    MuscleShape.Opacity = 100;
                else
                    MuscleShape.Opacity = 0;
            }
        }

        public bool IsSelected
        {
            set
            {
                if (value)
                    MuscleShape.Opacity = 100;
                else
                    MuscleShape.Opacity = 0;
            }
        }

        public Polygon MuscleShape
        {
            get
            {
                return muscleShape;
            }

            set
            {
                muscleShape = value;
            }
        }

        public void Scale(double actualWidth, double actualHeight)
        {
            for (int i = 0; i < muscleShape.Points.Count; i++)
            {
                muscleShape.Points[i] = new Point(muscleShape.Points[i].X * actualWidth,
                    muscleShape.Points[i].Y * actualHeight); 
            }
        }
    }
}
