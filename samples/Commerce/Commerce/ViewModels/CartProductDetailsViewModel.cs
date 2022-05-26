﻿namespace Commerce.ViewModels;


public partial class CartProductDetailsViewModel: ProductDetailsViewModel
{
	private readonly CartItem _cartItem;

	public CartProductDetailsViewModel(
		IProductService productService,
		CartItem cartItem) : base(productService,cartItem.Product)
	{
		_cartItem = cartItem;
	}

	public override IFeed<Product> Product => base.Product;

	public override IFeed<IImmutableList<Review>> Reviews => base.Reviews;
}