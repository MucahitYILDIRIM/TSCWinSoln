using System;
using System.Collections.Generic;
using System.Linq;
using TSC.Entity;
using Xunit;

namespace TSC.Entity.Tests
{
    public class CartTests
    {
        private readonly Category food = new Category("Food", null);
        private readonly Category electronics = new Category("Electronics", null);
        private readonly Product apple;
        private readonly Product bread;
        private readonly Product phone;
        private readonly Cart cart = new Cart();

        public CartTests()
        {
            apple = new Product("Apple", 10, food);
            bread = new Product("Bread", 5, food);
            phone = new Product("Phone", 1000, electronics);
        }

        private static List<Campaign> Campaigns(params Campaign[] campaigns) => campaigns.ToList();

        #region Constructor

        [Fact]
        public void Constructor_InitializesEmptyLists()
        {
            Assert.NotNull(cart.ShoppingCartList);
            Assert.Empty(cart.ShoppingCartList);
            Assert.NotNull(cart.UsedCoupon);
            Assert.Empty(cart.UsedCoupon);
        }

        #endregion

        #region addItem

        [Fact]
        public void AddItem_NewProduct_AddsLineWithQuantity()
        {
            cart.addItem(apple, 3);

            var item = Assert.Single(cart.ShoppingCartList);
            Assert.Same(apple, item.Product);
            Assert.Equal(3, item.Quantity);
        }

        [Fact]
        public void AddItem_SameProductTwice_MergesQuantityIntoSingleLine()
        {
            cart.addItem(apple, 3);
            cart.addItem(apple, 2);

            var item = Assert.Single(cart.ShoppingCartList);
            Assert.Equal(5, item.Quantity);
        }

        [Fact]
        public void AddItem_DifferentProducts_AddsSeparateLines()
        {
            cart.addItem(apple, 1);
            cart.addItem(phone, 1);

            Assert.Equal(2, cart.ShoppingCartList.Count);
        }

        [Fact]
        public void AddItem_ProductsAreComparedByReference_NotByTitle()
        {
            var appleCopy = new Product("Apple", 10, food);

            cart.addItem(apple, 1);
            cart.addItem(appleCopy, 1);

            Assert.Equal(2, cart.ShoppingCartList.Count);
        }

        #endregion

        #region removeItem

        [Fact]
        public void RemoveItem_LessThanCurrentQuantity_DecreasesQuantity()
        {
            cart.addItem(apple, 5);

            cart.removeItem(apple, 2);

            Assert.Equal(3, Assert.Single(cart.ShoppingCartList).Quantity);
        }

        [Fact]
        public void RemoveItem_EqualToCurrentQuantity_RemovesLine()
        {
            cart.addItem(apple, 5);

            cart.removeItem(apple, 5);

            Assert.Empty(cart.ShoppingCartList);
        }

        [Fact]
        public void RemoveItem_MoreThanCurrentQuantity_RemovesLine()
        {
            cart.addItem(apple, 2);

            cart.removeItem(apple, 10);

            Assert.Empty(cart.ShoppingCartList);
        }

        [Fact]
        public void RemoveItem_OnlyAffectsGivenProduct()
        {
            cart.addItem(apple, 2);
            cart.addItem(bread, 4);

            cart.removeItem(apple, 2);

            var item = Assert.Single(cart.ShoppingCartList);
            Assert.Same(bread, item.Product);
            Assert.Equal(4, item.Quantity);
        }

        [Fact]
        public void RemoveItem_ProductNotInCart_Throws()
        {
            cart.addItem(apple, 1);

            Assert.Throws<InvalidOperationException>(() => cart.removeItem(phone, 1));
        }

        #endregion

        #region applyCoupon

        [Fact]
        public void ApplyCoupon_TotalAboveMinimum_AddsCoupon()
        {
            cart.addItem(apple, 20); // 200
            var coupon = new Coupon(100, 10, DiscountType.Amount);

            cart.applyCoupon(coupon);

            Assert.Same(coupon, Assert.Single(cart.UsedCoupon));
        }

        [Fact]
        public void ApplyCoupon_TotalEqualToMinimum_AddsCoupon()
        {
            cart.addItem(apple, 10); // 100
            var coupon = new Coupon(100, 10, DiscountType.Amount);

            cart.applyCoupon(coupon);

            Assert.Single(cart.UsedCoupon);
        }

        [Fact]
        public void ApplyCoupon_TotalBelowMinimum_DoesNotAddCoupon()
        {
            cart.addItem(apple, 9); // 90
            var coupon = new Coupon(100, 10, DiscountType.Amount);

            cart.applyCoupon(coupon);

            Assert.Empty(cart.UsedCoupon);
        }

        [Fact]
        public void ApplyCoupon_EmptyCart_OnlyZeroMinimumCouponIsAdded()
        {
            cart.applyCoupon(new Coupon(1, 10, DiscountType.Amount));
            cart.applyCoupon(new Coupon(0, 10, DiscountType.Amount));

            Assert.Equal(0, Assert.Single(cart.UsedCoupon).MinProductPurchase);
        }

        [Fact]
        public void ApplyCoupon_SameCouponTwice_IsAddedTwice()
        {
            // Current behaviour: there is no duplicate guard on UsedCoupon.
            cart.addItem(apple, 10);
            var coupon = new Coupon(50, 10, DiscountType.Amount);

            cart.applyCoupon(coupon);
            cart.applyCoupon(coupon);

            Assert.Equal(2, cart.UsedCoupon.Count);
        }

        #endregion

        #region getCouponDiscount

        [Fact]
        public void GetCouponDiscount_NoCoupons_ReturnsZero()
        {
            cart.addItem(apple, 10);

            Assert.Equal(0, cart.getCouponDiscount());
        }

        [Fact]
        public void GetCouponDiscount_AmountCoupon_ReturnsFixedAmount()
        {
            cart.addItem(apple, 10); // 100
            cart.applyCoupon(new Coupon(50, 15, DiscountType.Amount));

            Assert.Equal(15, cart.getCouponDiscount());
        }

        [Fact]
        public void GetCouponDiscount_RateCoupon_ReturnsPercentageOfCartTotal()
        {
            cart.addItem(apple, 10); // 100
            cart.addItem(bread, 20); // 100
            cart.applyCoupon(new Coupon(50, 10, DiscountType.Rate));

            Assert.Equal(20, cart.getCouponDiscount(), 6);
        }

        [Fact]
        public void GetCouponDiscount_MultipleCoupons_AreSummed()
        {
            cart.addItem(apple, 10); // 100
            cart.applyCoupon(new Coupon(0, 5, DiscountType.Amount));
            cart.applyCoupon(new Coupon(0, 10, DiscountType.Rate)); // 10

            Assert.Equal(15, cart.getCouponDiscount(), 6);
        }

        [Fact]
        public void GetCouponDiscount_CartDropsBelowMinimumAfterApplying_CouponIsIgnored()
        {
            cart.addItem(apple, 10); // 100
            cart.applyCoupon(new Coupon(100, 15, DiscountType.Amount));

            cart.removeItem(apple, 1); // 90

            Assert.Single(cart.UsedCoupon);
            Assert.Equal(0, cart.getCouponDiscount());
        }

        #endregion

        #region getCampaignDiscount

        [Fact]
        public void GetCampaignDiscount_NoCampaigns_ReturnsZero()
        {
            cart.addItem(apple, 10);

            Assert.Equal(0, cart.getCampaignDiscount(new List<Campaign>()));
        }

        [Fact]
        public void GetCampaignDiscount_AmountCampaignConditionMet_ReturnsFixedAmount()
        {
            cart.addItem(apple, 1);
            cart.addItem(bread, 1);

            var discount = cart.getCampaignDiscount(Campaigns(new Campaign(food, 20, 2, DiscountType.Amount)));

            Assert.Equal(20, discount);
        }

        [Fact]
        public void GetCampaignDiscount_RateCampaign_AppliesOnlyToCategoryItems()
        {
            cart.addItem(apple, 3); // 30 food
            cart.addItem(bread, 2); // 10 food
            cart.addItem(phone, 1); // 1000 electronics

            var discount = cart.getCampaignDiscount(Campaigns(new Campaign(food, 10, 2, DiscountType.Rate)));

            Assert.Equal(4, discount, 6);
        }

        [Fact]
        public void GetCampaignDiscount_NotEnoughItemsInCategory_ReturnsZero()
        {
            cart.addItem(apple, 1);
            cart.addItem(phone, 1);

            var discount = cart.getCampaignDiscount(Campaigns(new Campaign(food, 20, 2, DiscountType.Amount)));

            Assert.Equal(0, discount);
        }

        [Fact]
        public void GetCampaignDiscount_MinQuantityCountsCartLines_NotUnits()
        {
            // Current behaviour: MinProductQuantity is compared against the number of distinct
            // cart lines in the category, not the summed Quantity of those lines.
            cart.addItem(apple, 5);

            var discount = cart.getCampaignDiscount(Campaigns(new Campaign(food, 20, 2, DiscountType.Amount)));

            Assert.Equal(0, discount);
        }

        [Fact]
        public void GetCampaignDiscount_SubCategoryProducts_DoNotCountForParentCategory()
        {
            var fruit = new Category("Fruit", food);
            cart.addItem(new Product("Pear", 10, fruit), 1);
            cart.addItem(new Product("Plum", 10, fruit), 1);

            var discount = cart.getCampaignDiscount(Campaigns(new Campaign(food, 20, 1, DiscountType.Amount)));

            Assert.Equal(0, discount);
        }

        [Fact]
        public void GetCampaignDiscount_MultipleCampaigns_AreSummed()
        {
            cart.addItem(apple, 10); // 100 food
            cart.addItem(phone, 1);  // 1000 electronics

            var discount = cart.getCampaignDiscount(Campaigns(
                new Campaign(food, 10, 1, DiscountType.Rate),          // 10
                new Campaign(electronics, 50, 1, DiscountType.Amount))); // 50

            Assert.Equal(60, discount, 6);
        }

        [Fact]
        public void GetCampaignDiscount_ZeroMinQuantityAmountCampaign_AppliesEvenToEmptyCart()
        {
            // Current behaviour: 0 >= 0 satisfies the condition with no matching items.
            var discount = cart.getCampaignDiscount(Campaigns(new Campaign(food, 25, 0, DiscountType.Amount)));

            Assert.Equal(25, discount);
        }

        #endregion

        #region getTotalAmountAfterDiscounts / getDeliveryCost

        [Fact]
        public void GetTotalAmountAfterDiscounts_ReturnsSumOfCouponAndCampaignDiscounts()
        {
            // Despite its name, this method returns the total discount, not the discounted amount.
            cart.addItem(apple, 10); // 100
            cart.addItem(bread, 2);  // 10
            cart.applyCoupon(new Coupon(100, 5, DiscountType.Amount));
            var campaigns = Campaigns(new Campaign(food, 10, 2, DiscountType.Rate)); // 11

            Assert.Equal(16, cart.getTotalAmountAfterDiscounts(campaigns), 6);
        }

        [Fact]
        public void GetTotalAmountAfterDiscounts_NoDiscounts_ReturnsZero()
        {
            cart.addItem(apple, 10);

            Assert.Equal(0, cart.getTotalAmountAfterDiscounts(new List<Campaign>()));
        }

        [Fact]
        public void GetDeliveryCost_ReturnsCartTotalMinusDiscounts()
        {
            // Despite its name, this method returns the cart total after discounts.
            cart.addItem(apple, 10); // 100
            cart.addItem(bread, 2);  // 10
            cart.applyCoupon(new Coupon(100, 5, DiscountType.Amount));
            var campaigns = Campaigns(new Campaign(food, 10, 2, DiscountType.Rate)); // 11

            Assert.Equal(94, cart.getDeliveryCost(campaigns), 6);
        }

        [Fact]
        public void GetDeliveryCost_EmptyCartWithoutDiscounts_ReturnsZero()
        {
            Assert.Equal(0, cart.getDeliveryCost(new List<Campaign>()));
        }

        [Fact]
        public void GetDeliveryCost_DiscountsExceedTotal_ReturnsNegative()
        {
            // Current behaviour: result is not clamped at zero.
            cart.addItem(bread, 1); // 5
            cart.applyCoupon(new Coupon(0, 20, DiscountType.Amount));

            Assert.Equal(-15, cart.getDeliveryCost(new List<Campaign>()));
        }

        #endregion
    }
}
