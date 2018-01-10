using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace RefactoringKata
{
    public class OrdersWriter
    {
        private readonly Orders _orders;

        public OrdersWriter(Orders orders)
        {
            _orders = orders;
        }

        public string DictionaryToJson(Dictionary<string, string> dictionary)
        {
            var entries = dictionary.Select(d => $"\"{d.Key}\": \"{string.Join(",", d.Value)}\"");
            return "{" + string.Join(",", entries) + "}";
        }

        public string GetContents()
        {
            var sb = new StringBuilder("{\"orders\": [");

            for (var i = 0; i < _orders.GetOrdersCount(); i++)
            {
                if (i != 0)
                    sb.Append(",");
                var order = _orders.GetOrder(i);
                sb.Append("{");
                sb.Append("\"id\": ");
                sb.Append(order.GetOrderId());
                sb.Append(", ");
                sb.Append("\"products\": [");

                var dic = new Dictionary<string, string>();
                for (var j = 0; j < order.GetProductsCount(); j++)
                {
                    if (j != 0)
                    {
                        sb.Append(",");
                    }

                    var product = order.GetProduct(j);
                    dic.Add("code", product.Code);
                    dic.Add("color", product.GetColorInString());
                    if (product.Size != Product.SizeNotApplicable)
                    {
                        dic.Add("size", product.GetSizeInString());
                    }
                    dic.Add("price", product.Price.ToString(CultureInfo.InvariantCulture));
                    dic.Add("currency", product.Currency);
                    sb.Append(DictionaryToJson(dic));
                }

                sb.Append("]}");
            }

            return sb.Append("]}").ToString();
        }
    }
}