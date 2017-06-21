using System.Collections.Generic;

namespace ShoppingCart
{
	public class ShoppingCart
	{
		private readonly Dictionary<string, int> _shoppingProduct = new Dictionary<string, int>();

		public ShoppingCart()
		{
		}

		public void AddBook(string productName, int amount)
		{
			_shoppingProduct.Add(productName, amount);
		}

		public int GetPrice()
		{
			if (_shoppingProduct.Count == 2)
			{
				return (int)(_shoppingProduct.Count * 100 * 0.95);
			}
			else if (_shoppingProduct.Count == 3)
			{
				return (int)(_shoppingProduct.Count * 100 * 0.9);
			}
			else if (_shoppingProduct.Count == 4)
			{
				return (int)(_shoppingProduct.Count * 100 * 0.8);
			}
			return 100;
		}
	}
}