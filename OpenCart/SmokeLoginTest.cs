﻿using System.Threading;
using NUnit.Framework;
using OpenCart.Actions.User;
using OpenCart.Pages;
using OpenCart.Data.Commons;
using OpenCart.Data.Products;

namespace OpenCart
{
	[TestFixture]
	public class SmokeLoginTest : TestRunner
	{
		private static readonly object[] SearchProduct =
				{
			new object[] { ProductRepository.macBook(), CurrencyRepository.Euro() },
			new object[] { ProductRepository.macBook(), CurrencyRepository.PoundSterling() },
			new object[] { ProductRepository.macBook(), CurrencyRepository.USDollar() }
		};

		[Test, TestCaseSource("SearchProduct")]
		public void VerifySearchByCurrency(Product product, string currencyName)
		{
			//HomeActions homeActions = Application.Get().LoadHomeActions();
			//SuccesSearchActions searchActions = homeActions.SuccesSearchProduct(product.Name);
			//
			// Precondition
			SuccesSearchActions searchActions = Application.Get()
													.LoadHomeActions()
													.SuccesSearchProduct(product.Name);
			// Steps
			searchActions = searchActions.ChooseCurrencyByPartialName(currencyName);
			// Verify
			Assert.AreEqual(product.GetPrice(currencyName), searchActions.GetPriceByProductName(product.Name), 0.01);
			// Return to previous state
			//searchActions.GotoHomeActions();
			//
			Thread.Sleep(2000);
		}

		//private static readonly object[] CategoriesItems =
		//{
		//	new object[] { CategoryItemsRepository.Desktops() }
		//};

		//[Test, TestCaseSource("CategoriesItems")]
		//public void VerifySuccessLogin(CategoryItems categoryItems)
		//{
		//	// Precondition
		//	// Steps
		//	HomeActions homeActions = Application.Get().LoadHomeActions();
		//	// Verify
		//	foreach (ElementItem elementItem in homeActions.GetAllElementItemsByCategoryName(categoryItems.Name))
		//	{
		//		Console.WriteLine("elementItem.Name" + elementItem.Name +

		//			 "   elementItem.Count" + elementItem.Count);
		//	}
		//}
	}
}