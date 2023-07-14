using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TWE_Config_JSON
{
    public struct Point
    {
        public int Coord_X;
        public int Coord_Y;
        public int Coord_Z;

        public Point(int x, int y, int z)
        {
            Coord_X = x;
            Coord_Y = y;
            Coord_Z = z;
        }
    }

    class Program
    {
        static void Main()
        {
            var testPoints = new List<Point>()
            {
                new Point(0, 0, 0),
                new Point(1, 2, 3),
                new Point(2, 4, 6),
                new Point(3, 6, 9)
            };

            Console.WriteLine("\n*** EXAMPLE # 1 ***\n");

            var jsonPoints = new List<string>();

            foreach (var point in testPoints)
            {
                string jsonPoint = JsonConvert.SerializeObject(point, Formatting.Indented);
                Console.WriteLine("POINT: {0}", jsonPoint);
                jsonPoints.Add(jsonPoint);
            }

            string outputJsonFile = "points.json";

            StreamWriter jsonWriter = new StreamWriter(outputJsonFile);
            jsonWriter.WriteLine("[\n" + string.Join(",\n", jsonPoints) + "\n]\n");
            jsonWriter.Close();
            Console.WriteLine("JSON objects were written to 'points.json' file.");

            StreamReader jsonReader = new StreamReader(outputJsonFile);
            string jsonPointsView = jsonReader.ReadToEnd();
            Console.WriteLine("JSON objects were read from 'points.json' file.");

            List<Point> myPoints = JsonConvert.DeserializeObject<List<Point>>(jsonPointsView);
            foreach (var point in myPoints)
            {
                Console.WriteLine("My Deserialized Point: X = {0}, Y = {1}, Z = {2}", point.Coord_X, point.Coord_Y, point.Coord_Z);
            }


            Console.WriteLine("\n*** EXAMPLE # 2 ***\n");

            Point myPoint = new Point(25, 50, 100);
            string myPointAsJson = JsonConvert.SerializeObject(myPoint);
            Console.WriteLine("My Point as JSON String: {0}\n", myPointAsJson);

            Point myPointAsObject = JsonConvert.DeserializeObject<Point>(myPointAsJson);
            Console.WriteLine("My Deserialized Point: X = {0}, Y = {1}, Z = {2}\n", myPointAsObject.Coord_X, myPointAsObject.Coord_Y, myPointAsObject.Coord_Z);

            Console.WriteLine();
        }
    }
}
