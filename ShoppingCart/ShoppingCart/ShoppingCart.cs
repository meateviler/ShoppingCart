using System.Collections.Generic;

namespace ShoppingCart
{
	public class ShoppingCart
	{
		private Dictionary<string, int> _shoppingProduct = new Dictionary<string, int>();

		private Dictionary<int, decimal> _discount = new Dictionary<int, decimal>()
		{
			{1,1.0m},
			{2,0.95m},
			{3,0.9m},
			{4,0.8m},
			{5,0.75m},
		};

		public ShoppingCart()
		{
		}

		public void AddBook(string productName, int amount)
		{
			_shoppingProduct.Add(productName, amount);
		}

		public int GetPrice()
		{
			int totalPrice = 0;
			int productCount = GetProductCount();
			while (productCount > 0)
			{
				totalPrice += (int)(productCount * 100 * _discount[productCount]);
				RemoveEveryProductOnce();
				productCount = GetProductCount();
			}

			return totalPrice;
		}

		private int GetProductCount()
		{
			return _shoppingProduct.Count;
		}

		private void RemoveEveryProductOnce()
		{
			var keys = new List<string>(_shoppingProduct.Keys);
			foreach (var key in keys)
			{
				_shoppingProduct[key] -= 1;
				if (_shoppingProduct[key] == 0)
				{
					_shoppingProduct.Remove(key);
				}
			}
		}
	}
}