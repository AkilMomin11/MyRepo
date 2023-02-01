namespace DAL;
using BOL;
using System.Data;
using MySql.Data.MySqlClient; 

public static class MySqlRepository
{
    public static string conString=@"server=localhost;port=3306;user=root;password=dac123;database=ecommerce";
    public static List<Product> GetAll(){
        List<Product> products=new List<Product>();
        string query = "SELECT * FROM products";
        IDbConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        IDbCommand cmd =new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText=query;
        try{
            con.Open();
            IDataReader reader = cmd.ExecuteReader();
            while(reader.Read()){
                int id=int.Parse(reader["productid"].ToString());
                string title=reader["title"].ToString();
                string picture=reader["picture"].ToString();
                string description=reader["description"].ToString();
                int unitPrice=int.Parse(reader["unitPrice"].ToString());
                int categoryid=int.Parse(reader["categoryid"].ToString());
                int unitinstock=int.Parse(reader["unitinstock"].ToString());
                Product product=new Product{
                    ProductId=id,
                    Title=title,
                    Description=description,
                    UnitPrice=unitPrice,
                    Categoryid=categoryid,
                    Unitinstock=unitinstock,
                   
                };
                products.Add(product);
 
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally{
            con.Close();
        }
        return products;
    }

        public static Product GetById(int id)
        {
            List<Product> products =GetAll();
             var theProduct= from prod in products
                          where prod.ProductId == id
                          select prod;
         return theProduct.First<Product>();
        }


}
