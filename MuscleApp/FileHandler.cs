using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;

namespace MuscleApp
{
    class FileHandler
    {
        public static Body GetPolygonsFromFile(String fileName)
        {
            Body currentBody = null;
            Muscle currentMuscle= null;
            Point currentPoint = new Point();
            Polygon currentPolygon = null;
           
            StringBuilder output = new StringBuilder();
            using (XmlReader reader = XmlReader.Create(new StringReader(File.ReadAllText(fileName))))
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                //ws.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(output, ws))
                {
                    
                  
                    // Parse the file and display each of the nodes.
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {  
                            case XmlNodeType.Element:
                                if (reader.Name.Equals("Body"))
                                {
                                    currentBody = new Body();
                                }
                                else if (reader.Name.Equals("Muscle"))
                                {
                                    currentMuscle = new Muscle();
                                }
                                else if (reader.Name.Equals("Polygon"))
                                {
                                    currentPolygon = new Polygon();
                                    // Create a blue and a black Brush
                                    SolidColorBrush yellowBrush = new SolidColorBrush();
                                    yellowBrush.Color = Colors.Yellow;
                                    SolidColorBrush blackBrush = new SolidColorBrush();
                                    blackBrush.Color = Colors.Black;
                                    currentPolygon.Stroke = blackBrush;
                                    currentPolygon.Fill = yellowBrush;
                                    currentPolygon.StrokeThickness = 0;
                                }
                                else if (reader.Name.Equals("Point"))
                                {
                                    double d,d2;
                                    Double.TryParse(reader[0], out d); //X
                                    Double.TryParse(reader[1], out d2); //Y
                                    currentPoint = new Point(d,d2);
                                    currentPolygon.Points.Add(currentPoint);
                                }
                                break;
                            case XmlNodeType.Text:
                                break;
                            case XmlNodeType.XmlDeclaration:
                            case XmlNodeType.ProcessingInstruction:
                                
                                break;
                            case XmlNodeType.Comment:
                              
                                break;
                            case XmlNodeType.EndElement:
                                if (reader.Name.Equals("Point"))
                                {
                                    currentPolygon.Points.Add(currentPoint);
                                } else if (reader.Name.Equals("Polygon"))
                                {
                                    currentMuscle.MuscleShape = currentPolygon;
                                }
                                else if (reader.Name.Equals("Muscle"))
                                {
                                    currentBody.Muscles.Add(currentMuscle);
                                }
                                else if (reader.Name.Equals("Body"))
                                {
                                    return currentBody;
                                }
                                break;
                        }
                    }

                }
            }
            return null;
        }
    }
}
