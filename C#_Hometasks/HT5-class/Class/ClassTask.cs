using System;
using System.Collections.Generic;
using System.Linq;

namespace Class
{
    class Rectangle
    {
        private double sideA;
        private double sideB;

        public Rectangle(double a, double b)
        {
            this.sideA = a;
            this.sideB = b;
        }

        public Rectangle(double a)
        {
            this.sideA = a;
            this.sideB = 5;
        }

        public Rectangle()
        {
            this.sideA = 4;
            this.sideB = 3;
        }

        public double GetSideA()
        {
            return sideA;
        }

        public double GetSideB()
        {
            return sideB;
        }

        public double Area()
        {
            return GetSideA() * GetSideB();
        }

        public double Perimeter()
        {
            return (sideA + sideB) * 2;
        }

        public bool IsSquare()
        {
            if (GetSideA() != GetSideB())
            {
                return false;
            }
            return true;
        }

        public void ReplaceSides()
        {
            double temp = sideA;
            sideA = sideB;
            sideB = temp;
        }
    }


    class ArrayRectangles
    {
        private readonly Rectangle[] rectangle_array;

        public ArrayRectangles(int n)
        {
            rectangle_array = new Rectangle[n];
        }

        public ArrayRectangles(params Rectangle[] rectangle_array)
        {
            this.rectangle_array = rectangle_array;
        }

        public bool AddRectangle(Rectangle rectangle)
        {
            for (int i = 0; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] == null)
                {
                    rectangle_array[i] = rectangle;
                    return true;
                }
            }
            return false;
        }

        public int NumberMaxArea()
        {
            double maxArea = 0;
            int indexMaxArea = 0;
            for (int i = 0; i < rectangle_array.Length; i++)
            {
                var temp = rectangle_array[i].Area();
                if (temp > maxArea)
                {
                    maxArea = temp;
                    indexMaxArea = i;
                }
            }
            return indexMaxArea;
        }

        public int NumberMinPerimeter()
        {
            double minPerim = rectangle_array[0].Perimeter();
            int indexMinPerim = 0;
            for (int i = 0; i < rectangle_array.Length; i++)
            {
                var temp = rectangle_array[i].Perimeter();
                if (temp < minPerim)
                {
                    minPerim = temp;
                    indexMinPerim = i;
                }
            }
            return indexMinPerim;
        }

        public int NumberSquare()
        {
            int count = rectangle_array.Count(rectangle => rectangle.IsSquare());
            return count;
        }
    }
}
