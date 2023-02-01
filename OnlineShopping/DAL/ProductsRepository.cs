namespace DAL;
using BOL;

public static class ProductsRepository
{
    public static List<Product>GetAll()
    {
        List<Product> allProducts=new List<Product>();
        allProducts.Add(new Product { ProductId = 1, Title = "Apple MacBook Air 2020", Description = "Apple M1", UnitPrice = 83900, Category = "Laptop", StockAvailable = 10 });
        allProducts.Add(new Product { ProductId = 2, Title = "Apple M2 chip", Description = "Apple M2", UnitPrice = 120900, Category = "Laptop", StockAvailable = 10 });
        allProducts.Add(new Product { ProductId = 3, Title = "Apple MacBook Pro 2022", Description = "Apple PRO", UnitPrice = 140900, Category = "Laptop", StockAvailable = 15 });
        allProducts.Add(new Product { ProductId = 4, Title = "Apple MacBook Air with M2 chip", Description = "Apple AIR", UnitPrice = 99999, Category = "Laptop", StockAvailable = 12 });
        return allProducts;
    }

    public static Product GetById(int id)
    {
        Console.WriteLine(id);
        List<Product> products=GetAll();
          var theProduct= from prod in products
                          where prod.ProductId == id
                          select prod;
         return theProduct.First<Product>();
    }

     public static bool  Insert(Product product){
         bool status=false;
         List<Product> products=GetAll();
         products.Add(product);
         status=true;
         return status;
    }

     public static bool Delete(int id){
         bool status=false;
         List<Product> products=GetAll();
         Product theProduct=GetById(id);
         products.Remove(theProduct);
         status=true;
         return status;
    }
}
