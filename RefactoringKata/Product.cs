using System.Collections.Generic;

namespace RefactoringKata
{
    public class Product
    {
        public static int SizeNotApplicable = -1;
        public static Dictionary<int, string> ColorCodeMapping = new Dictionary<int, string>
        {
            {1, "blue"},
            {2, "red"},
            {3, "yellow"}
        };
        public static Dictionary<int, string> SizeCodeMapping = new Dictionary<int, string>
        {
            {1, "XS"},
            {2, "S"},
            {3, "M"},
            {4, "L"},
            {5, "XL"},
            {6, "XXL"}
        };

        public string Code { get; set; }
        public int Color { get; set; }
        public int Size { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }

        public Product(string code, int color, int size, double price, string currency)
        {
            Code = code;
            Color = color;
            Size = size;
            Price = price;
            Currency = currency;
        }

        public string GetColorInString()
        {
            return ColorCodeMapping.TryGetValue(Color, out var color) ? color : "no color";
        }

        public string GetSizeInString()
        {
            return SizeCodeMapping.TryGetValue(Size, out var size) ? size : "Invalid Size";
        }
    }
}
