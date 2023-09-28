namespace UnitTestingSamples.Sample5;

public class Goods
{
  public int Price { get; set; }
  public string Name { get; set; }
}

public class DiscountModule
{
  public double Calculate(Goods[] goodsArray)
  {
    if (goodsArray.Length == 0)
      return 0;
    else if (goodsArray.Length == 1)
    {
      return goodsArray.Single().Price;
    }
    else if (goodsArray.Length == 2)
    {
      var twoItemsSorted = goodsArray.OrderBy(x => x.Price);
      return twoItemsSorted.First().Price * 0.8 + twoItemsSorted.Last().Price;
    }
    var sorted = goodsArray.OrderBy(x => x.Price);
    return sorted.First().Price * 0.7 + sorted.Skip(1).First().Price * 0.8 + sorted.Skip(2).Sum(x => x.Price);
  }
}

public class DiscountModuleTests
{
  /*
   * Test Cases:
   * EmptyCart -> Price=0
   * SingleGood(Price=100) -> Price=100
   * TwoGoods(Price=100, Price=200) -> Price=280
   * TwoGoods(Price=200, Price=100) -> Price=280
   * ThreeGoods(Price=100, Price=200, Price=300) -> Price=70+160+300=530
   * ThreeGoods(Price=300, Price=200, Price=100) -> Price=300+160+70=530
   * ThreeGoods(Price=200, Price=300, Price=100) -> Price=300+160+70=530
   * FourGoods(Price=100, Price=200, Price=300, Price=400) -> Price=70+160+300+400=930
   */

  [Fact]
  public void EmptyCart_ShouldReturnZeroPrice()
  {
    // Arrange
    var cart = new Goods[0];
    var discountModule = new DiscountModule();

    // Act
    var price = discountModule.Calculate(cart);

    // Assert
    Assert.Equal(0, price);
  }

  [Fact]
  public void SingleGood_ShouldReturnOriginalPrice()
  {
    // Arrange
    var cart = new Goods[] { new Goods { Price = 100 } };
    var discountModule = new DiscountModule();

    // Act
    var price = discountModule.Calculate(cart);

    // Assert
    Assert.Equal(100, price);
  }

  [Fact]
  public void TwoGoods_InDifferentOrder_ShouldApplyDiscount()
  {
    // Arrange
    var cart = new Goods[] { new Goods { Price = 200 }, new Goods { Price = 100 } };
    var discountModule = new DiscountModule();

    // Act
    var price = discountModule.Calculate(cart);

    // Assert
    Assert.Equal(280, price);
  }

  [Fact]
  public void ThreeGoods_InDifferentOrder_ShouldApplyDiscount()
  {
    // Arrange
    var cart = new Goods[] { new Goods { Price = 200 }, new Goods { Price = 300 }, new Goods { Price = 100 } };
    var discountModule = new DiscountModule();

    // Act
    var price = discountModule.Calculate(cart);

    // Assert
    Assert.Equal(530, price);
  }

  [Fact]
  public void FourGoods_ShouldApplyDiscount()
  {
    // Arrange
    var cart = new Goods[] { new Goods { Price = 100 }, new Goods { Price = 200 }, new Goods { Price = 300 }, new Goods { Price = 400 } };
    var discountModule = new DiscountModule();

    // Act
    var price = discountModule.Calculate(cart);

    // Assert
    Assert.Equal(930, price);
  }
}