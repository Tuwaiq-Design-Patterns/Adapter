using System;

namespace RefactoringGuru.DesignPatterns.Adapter.Conceptual
{
    public interface ITarget
    {
        string AdaptingCube(string w, string h);
    }


    class Adaptee3D
    {
        public string CubeIt(int width, int height, int depth)
        {
            return $"The Cube has been created by Adaptee3D.CubeIt with width: {width} height: {height} depth:{depth}";
        }
    }

    class ThreeDimensionsAdapter : ITarget
    {
        private readonly Adaptee3D _adaptee;

        public ThreeDimensionsAdapter(Adaptee3D adaptee)
        {
            this._adaptee = adaptee;
        }

        public string AdaptingCube(string w, string h)
        {
            int width = Int32.Parse(w);
            int height = Int32.Parse(h);
            int depth = Math.Max(width, height) / 2;
            return $"Adaptor log:  '{this._adaptee.CubeIt(width, height, depth)}'";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Adaptee3D adaptee = new Adaptee3D();
            ITarget target = new ThreeDimensionsAdapter(adaptee);


            Console.WriteLine("Enter the width:");
            var w = Console.ReadLine();
            Console.WriteLine("Enter the height: ");
            var h = Console.ReadLine();

            Console.WriteLine(target.AdaptingCube(w, h));
        }
    }
}