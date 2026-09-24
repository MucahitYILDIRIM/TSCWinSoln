using TSC.Entity;
using Xunit;

namespace TSC.Entity.Tests
{
    public class EntityConstructorTests
    {
        [Fact]
        public void Category_Constructor_SetsTitleAndParent()
        {
            var parent = new Category("Electronics", null);
            var child = new Category("Phones", parent);

            Assert.Equal("Phones", child.Title);
            Assert.Same(parent, child.ParentCategory);
            Assert.Null(parent.ParentCategory);
        }

        [Fact]
        public void Product_Constructor_SetsAllProperties()
        {
            var category = new Category("Books", null);
            var product = new Product("Novel", 25.5, category);

            Assert.Equal("Novel", product.Title);
            Assert.Equal(25.5, product.Price);
            Assert.Same(category, product.Category);
        }

        [Fact]
        public void Coupon_Constructor_MapsArgumentsToProperties()
        {
            var coupon = new Coupon(100, 10, DiscountType.Rate);

            Assert.Equal(100, coupon.MinProductPurchase);
            Assert.Equal(10, coupon.DiscountPrice);
            Assert.Equal(DiscountType.Rate, coupon.Type);
        }

        [Fact]
        public void Campaign_Constructor_MapsArgumentsToProperties()
        {
            var category = new Category("Food", null);
            var campaign = new Campaign(category, 20, 3, DiscountType.Amount);

            Assert.Same(category, campaign.Category);
            Assert.Equal(20, campaign.DiscountPrice);
            Assert.Equal(3, campaign.MinProductQuantity);
            Assert.Equal(DiscountType.Amount, campaign.Type);
        }

        [Fact]
        public void CouponAndCampaign_AreDiscounts()
        {
            Assert.IsAssignableFrom<Discount>(new Coupon(0, 0, DiscountType.Amount));
            Assert.IsAssignableFrom<Discount>(new Campaign(null, 0, 0, DiscountType.Amount));
        }

        [Fact]
        public void DiscountType_DefaultValueIsRate()
        {
            // Rate is the first enum member, so an uninitialised Discount is a Rate discount.
            Assert.Equal(DiscountType.Rate, new Discount().Type);
        }

        [Fact]
        public void ShoppingChartItem_Constructor_SetsProductAndQuantity()
        {
            var product = new Product("Pen", 2, new Category("Office", null));
            var item = new ShoppingChartItem(product, 4);

            Assert.Same(product, item.Product);
            Assert.Equal(4, item.Quantity);
        }
    }
}
