﻿using System.Collections.Generic;

namespace RefactoringKata
{
    public class Order
    {
        private readonly int _id;
        private readonly List<Product> _products = new List<Product>();

        public Order(int id)
        {
            _id = id;
        }

        public int GetOrderId()
        {
            return _id;
        }

        public int GetProductsCount()
        {
            return _products.Count;
        }

        public Product GetProduct(int j)
        {
            return _products[j];
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
    }
}