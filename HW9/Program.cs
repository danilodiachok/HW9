namespace HW9
{
    

    

    class Program
    {
        static void Main(string[] args)
        {
            //Part A

            
            List<Shape> shapes = new List<Shape>
        {
            new Circle("Circle 1", 13.0),
            new Square("Square 1", 4.0),
            new Circle("Circle 2", 3.0),
            new Square("Square 2", 2.0),
            new Circle("Circle 3", 2.5),
            new Square("Square 3", 3.5)
        };

            //shapes with area in the range [10, 100]
            var shapesInRange = shapes.Where(shape => shape.Area() >= 10 && shape.Area() <= 100).ToList();
            Console.WriteLine("Shapes with area in the range [10, 100]:");
            foreach (var shape in shapesInRange)
            {
                Console.WriteLine($"Name: {shape.Name}, Area: {shape.Area()}, Perimeter: {shape.Perimeter()}");
            }
            WriteShapesToFile("ShapesInRange.txt", shapesInRange);
            Console.WriteLine("");
            



            //shapes with names containing the letter 'a' and write them to a file
            var shapesWithA = shapes.Where(shape => shape.Name.ToLower().Contains("a")).ToList();
            Console.WriteLine("Shapes with names containing 'a':");
            foreach (var shape in shapesWithA)
            {
                Console.WriteLine($"Name: {shape.Name}, Area: {shape.Area()}, Perimeter: {shape.Perimeter()}");
            }
            WriteShapesToFile("ShapesWithA.txt", shapesWithA);
            Console.WriteLine("");

            // Remove shapes with a perimeter less than 5
            shapes.RemoveAll(shape => shape.Perimeter() < 5);

            //the result list to the console
            Console.WriteLine("Shapes with a perimeter greater than or equal to 5:");
            foreach (var shape in shapes)
            {
                Console.WriteLine($"Name: {shape.Name}, Area: {shape.Area()}, Perimeter: {shape.Perimeter()}");
            }
            Console.WriteLine("");



            //B

            //all lines of text from a file into an array of strings
            string[] lines = File.ReadAllLines("C:\\Fileshow.txt");

            //the number of symbols in every line
            Console.WriteLine("\nNumber of symbols in each line:");
            foreach (var line in lines)
            {
                Console.WriteLine($"Line: {line}, Symbols: {line.Length}");
            }

            //the longest and the shortest lines
            string longestLine = lines.OrderByDescending(line => line.Length).First();
            string shortestLine = lines.OrderBy(line => line.Length).First();
            Console.WriteLine("\nLongest Line: " + longestLine);
            Console.WriteLine("Shortest Line: " + shortestLine);

            //lines that consist of the word "var"
            var linesWithVar = lines.Where(line => line.Contains("var")).ToList();
            Console.WriteLine("\nLines containing 'var':");
            foreach (var line in linesWithVar)
            {
                Console.WriteLine(line);
            }
        }

        
        static void WriteShapesToFile(string filename, List<Shape> shapes)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var shape in shapes)
                {
                    writer.WriteLine($"Name: {shape.Name}, Area: {shape.Area()}, Perimeter: {shape.Perimeter()}");
                }
            }
        }
    }
}