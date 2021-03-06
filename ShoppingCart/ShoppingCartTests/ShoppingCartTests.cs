﻿using System.Collections.Generic;
using NUnit.Framework;

namespace ShoppingCart.Tests
{
	[TestFixture()]
	public class ShoppingCartTests
	{
		private Dictionary<int, string> _bookName = new Dictionary<int, string>()
		{
			{0,"HarryPoter1"},
			{1,"HarryPoter2"},
			{2,"HarryPoter3"},
			{3,"HarryPoter4"},
			{4,"HarryPoter5"}
		};

		[TestCase(new[] { 1, 0, 0, 0, 0 }, ExpectedResult = 100, TestName = "BuyOneBookShouldBe100")]
		[TestCase(new[] { 1, 1, 0, 0, 0 }, ExpectedResult = 190, TestName = "BuyTwoDifferentBookShouldBe190")]
		[TestCase(new[] { 1, 1, 1, 0, 0 }, ExpectedResult = 270, TestName = "BuyThreeDifferentBookShouldBe270")]
		[TestCase(new[] { 1, 1, 1, 1, 0 }, ExpectedResult = 320, TestName = "BuyFourDifferentBookShouldBe320")]
		[TestCase(new[] { 1, 1, 1, 1, 1 }, ExpectedResult = 375, TestName = "BuyFiveDifferentBookShouldBe375")]
		[TestCase(new[] { 1, 1, 2, 0, 0 }, ExpectedResult = 370, TestName = "BuyThreeDifferentBookAndOneSameShouldBe370")]
		[TestCase(new[] { 1, 2, 2, 0, 0 }, ExpectedResult = 460, TestName = "BuyThreeDifferentBookAndAddTwoSameBookShouldBe460")]
		public int ShoppingCartTest(int[] bookArray)
		{
			var target = new ShoppingCart();
			for (var i = 0; i < 5; i++)
			{
				if (bookArray[i] > 0)
				{
					target.AddBook(_bookName[i], bookArray[i]);
				}
			}
			return target.GetPrice();
		}
	}
}