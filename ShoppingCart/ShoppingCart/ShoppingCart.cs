using System.Collections.Generic;

namespace ShoppingCart
{
	public class ShoppingCart
	{
		private Dictionary<string, int> _shoppingProduct = new Dictionary<string, int>();

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
				if (productCount == 2)
				{
					totalPrice += (int)(productCount * 100 * 0.95);
				}
				else if (productCount == 3)
				{
					totalPrice +=  (int)(productCount * 100 * 0.9);
				}
				else if (productCount == 4)
				{
					totalPrice +=  (int)(productCount * 100 * 0.8);
				}
				else if (productCount == 5)
				{
					totalPrice += (int)(productCount * 100 * 0.75);
				}
				else
				{
					totalPrice += 100;
				}
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