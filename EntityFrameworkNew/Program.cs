using EntityFrameworkNew;
using EntityFrameworkNew.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;



//using (var db = new ApplicationContext())
//{
//    // create 2 objects of Customers
//    Customer2 tom = new Customer2 { Name = "Tom", Address = "Davtashen 2 rd taxamas", ContactNumber = "+374-94-336-974", Email = "TomAgaja@mail.ru" };
//    Customer2 alice = new Customer2 { Name = "Alice", Address = "Xorenatsi street", ContactNumber = "+374-94-341-144", Email = "AliceGrvoryan@mail.ru" };

//    // Adding them to the database
//    db.Customers2.Add(tom);
//    db.Customers2.Add(alice);
//    db.SaveChanges();
//    Console.WriteLine("Saved");

//    var customers = db.Customers2.ToList();
//    Console.WriteLine("objects:");
//    foreach (Customer2 item in customers)
//    {
//        Console.WriteLine($"{item.CustomerId}.{item.Name} - {item.Address}-{item.ContactNumber}-{item.Email}");
//    }
//}



//using (var db = new ApplicationContext())
//{
//    // create 2 objects of Customers
//    Product product1 = new Product { Name = "Telephone", Price = 250000 };
//    Product product2 = new Product { Name = "TV", Price = 450000 };

//    // Adding them to the database
//    db.products.Add(product1);
//    db.products.Add(product2);
//    db.SaveChanges();
//    Console.WriteLine("Saved");

//    var products = db.products.ToList();
//    Console.WriteLine("objects:");
//    foreach (var item in products)
//    {
//        Console.WriteLine($"{item.Productid}.{item.Name} - {item.Price}");
//    }
//}





//using (var db = new ApplicationContext())
//{


//    Order order1 = new Order { Orderid =1, OrderDate = DateTime.Now, Customerld=2, TotalAmount =25000,};

//    db.Orders.Add(order1);

//    db.SaveChanges();
//    Console.WriteLine("Saved");

//    var orders = db.Orders.ToList();
//    Console.WriteLine("objects:");
//    foreach (var item in orders)
//    {
//        Console.WriteLine($"{item.Orderid}.{item.OrderDate} - {item.TotalAmount}");
//    }
//}



//Task1-Retrieve all active customers from the "Customers" table using filtering. 
using (ApplicationContext db = new ApplicationContext())
{
    var customers = db.Customers2.Where(p => p.IsActive == true);

    foreach (var item in customers)
        Console.WriteLine($"{item.Name}");

}


//Task2  Retrieve products from the "Products" table with a price higher than $100.
using (ApplicationContext db = new ApplicationContext())
{

    var products = db.products.Where(p => p.Price > 100);
    foreach (var item in products)
    {
        Console.WriteLine($"{item.Name}-{item.Price}$");
    }
}

//Task 3  Retrieve orders from the "Orders" table placed in the last 7 days. OrderDate 
using (ApplicationContext db = new ApplicationContext())
{
   
    var orders = db.Orders.Where(o => o.OrderDate > DateTime.Today.AddDays(-7) && o.OrderDate < DateTime.Today);
    foreach (var item in orders)
    {
        Console.WriteLine($"{item.Customer}-{item.OrderDate}");

    }
}

//Task 4 Retrieve products from the "Products" table and sort them by price in ascendin order.
using (ApplicationContext db = new ApplicationContext())
{
  
    var products = from p in db.products
                   orderby p.Price ascending
                   select p;
    foreach (var item in products)
    {
        Console.WriteLine($"{item.Name} -{item.Price}");
    }
}

//Task 5 Retrieve orders from the "Orders" table and sort them by total amount in descending order.

using (ApplicationContext db = new ApplicationContext())
{
    
    var orders = db.Orders.OrderByDescending(u => u.TotalAmount);
    foreach (var item in orders)
    {
        Console.WriteLine($"{item.Orderid},{item.TotalAmount}");
    }
}

//Task 6 Retrieve customers from the "Customers" table and sort them by name alphabetically.
using (ApplicationContext db = new ApplicationContext())
{
    
    var customers = db.Customers2.OrderBy(c => c.Name);
    foreach (var item in customers)
    {
        Console.WriteLine($"Name is {item.Name}");
    }
}

//Task 7  Retrieve orders along with the corresponding customer details using a join between the "Orders" and "Customers" tables.?

using (ApplicationContext db = new ApplicationContext())
{
    var OrdersAndCustomers = db.Orders.Join(db.Customers2,
        o => o.Customerld,
        c => c.CustomerId,
        (o, c) => new
        {
            Customer = c.Name,
        });

    foreach (var o in OrdersAndCustomers)
        Console.WriteLine($"{o.Customer} ");


}

//Task 8 Retrieve orders along with the products included in each order using a join between the "Orders," "OrderItems," and "Products" tables.?
using (ApplicationContext db = new ApplicationContext())
{

    var ordersWithProducts = db.Orders.Join(db.orderItems,
        o => o.Orderid,
        oi => oi.OrderID,
        (o, oi) => new
        {
            order = o,
            OrderItem = oi
        }).Join(db.products,
                    combined => combined.OrderItem.ProductID,
                    p => p.Productid,
                    (combined, p) => new
                    {
                        Order = combined.order,
                        OrderItem = combined.OrderItem,
                        Product = p
                    }).ToList();
    foreach (var item in ordersWithProducts)
    {
        Console.WriteLine($"{item.Order},{item.OrderItem},{item.Product}");
    }

}

//Task 9 Retrieve customer details along with their recent order information using a join between the "Customers" and "Orders" tables.
using (ApplicationContext db = new ApplicationContext())
{
    var CustomersAndTheirOrders = db.Customers2.Join(db.Orders,
        c => c.CustomerId,
        o => o.CustomerId,
        (c, o) => new
        {
            Customer2 = c,
            Order = o,
        });
    foreach (var item in CustomersAndTheirOrders)
    {
        Console.WriteLine($"Order ID: {item.Order.Orderid}, Name is {item.Customer2.Name}");
    }
}


//Task 10 Group orders from the "Orders" table by their status and calculate the count of orders in each group.
using (ApplicationContext db = new ApplicationContext())
{
    var groups = db.Orders.GroupBy(o => o.Status).Select(g => new
    {
        Status = g.Key,
        Count = g.Count(),
    });
    foreach (var item in groups)
    {
        Console.WriteLine($"{item.Status},{item.Count}");
    }
}
//Task 11  Group products from the "Products" table by their category and calculate the average price in each category.
using (ApplicationContext db = new ApplicationContext())
{
    var groups = db.products.GroupBy(p => p.Category).Select(g => new
    {
        Category = g.Key,
        AvgCount = g.Average(p => p.Price),
    });
    foreach (var item in groups)
    {
        Console.WriteLine($"{item.Category}, {item.AvgCount}");
    }
}

//Task 12 Group customers from the "Customers" table by their country and calculate the total count of customers in each country.
using (ApplicationContext db = new ApplicationContext())
{
    var groups = db.Customers2.GroupBy(c => c.Country).Select(g => new
    {

        Country = g.Key,
        Count = g.Count(), // nerkayacnuma et xmbi hajaxordneri tivy

    });
    foreach (var item in groups)
    {
        Console.WriteLine($"{item.Country},{item.Count}");
    }
}

//Task 13 Retrieve unique customers from both the "Customers" and "NewCustomers" tables using a UNION operation.
using (ApplicationContext db = new ApplicationContext())
{
    var uniqueCustomers = db.Customers2
      .Select(c => new { c.Name, c.Country })
      .Union(db.NewCustomers.Select(newCustomer => new { newCustomer.Name, newCustomer.Country }))
      .GroupBy(customer => new { customer.Name, customer.Country })
      .Select(group => group.First())
      .ToList();
    foreach (var user in uniqueCustomers)
        Console.WriteLine(user.Name);
}

//Task 14 Retrieve products that exist in both the "FeaturedProducts" and "BestSellerProducts" tables using an INTERSECT operation.
using (ApplicationContext db = new ApplicationContext())
{
    var product = db.featuredProducts.Select(f => new { f.Name, f.Price, f.productDetails })
        .Intersect(db.bestSellerProducts.Select(b => new { b.Name, b.Price, b.productDetails }))
        .ToList();
    foreach (var item in product)
    {
        Console.WriteLine($"Name is { item.Name}, Price is { item.Price}");
    }
}

//Task 15 Retrieve orders from the "Orders" table that do not appear in the "CancelledOrders" table using an EXCEPT operation.
using (ApplicationContext db = new ApplicationContext())
{
    var featureproduct = db.featuredProducts.Select(f => new { f.Name, f.Price, f.productDetails });
    var bestSellerProduct = db.bestSellerProducts.Select(b => new { b.Name, b.Price, b.productDetails });
    var products = featureproduct
        .Except(bestSellerProduct)
        .ToList();
    foreach (var item in products)
    {
        Console.WriteLine($"{item.Name}, {item.Price}, {item.productDetails}");
    }
}

//Task16  Calculate the total amount of all orders in the "Orders" table.
using (ApplicationContext db = new ApplicationContext())
{
    var totalAmount = db.Orders.Sum(o => o.TotalAmount);
    Console.WriteLine(totalAmount);

}

//Task17 Find the maximum price among all products in the "Products" table.
using (ApplicationContext db = new ApplicationContext())
{
    var maxPrice = db.products.Max(p => p.Price);
    Console.WriteLine(maxPrice);
}

//Task 18 Calculate the average call duration in the "CallDetails" table. 
using (ApplicationContext db = new ApplicationContext())
{
    decimal averageCallDuration = db.callDetails.Average(cd => cd.CallDuration);
    Console.WriteLine(averageCallDuration);
}

//Task 19 Retrieve customers from the "Customers" table while enabling tracking to allow changes to be tracked.
using (ApplicationContext db = new ApplicationContext())
{
    var customer = db.Customers2.FirstOrDefault();

    if (customer != null)
    {
        customer.Name = "Tom";
        db.SaveChanges();
    }

    var customers = db.Customers2.ToList();
    foreach (var item in customers)
        Console.WriteLine($"{item.Name} ({item.Address})");
}

//Task21: Implement a soft delete mechanism by applying a query filter to exclude logically deleted records from the "Customers" table.
using (ApplicationContext db = new ApplicationContext())
{
    var customer = db.Customers2.FirstOrDefault();

    if (customer != null)
    {
        customer.IsDeleted = true; 
        db.SaveChanges();
    }
    var activeCustomers = db.Customers2.Where(c => !c.IsDeleted).ToList();
    foreach (var item in activeCustomers)
        Console.WriteLine($"{item.Name} ({item.Address})");

}

//Task 20   Retrieve products from the "Products" table without enabling tracking to improve performance
using (ApplicationContext db = new ApplicationContext())
{
    var product = db.products.AsNoTracking().FirstOrDefault();
    if (product != null)
    {
        product.Price = 5000;
    }
    var products = db.products.ToList();
    foreach (var item in products)
        Console.WriteLine($"{item.Name}, {item.Price}");
}

//Tasl 22 Update the prices of products in the "Products" table by applying a percentage increase.
using (ApplicationContext db = new ApplicationContext())
{
    decimal newPrice = 5000;
    decimal percentageIncreaser = db.products.ExecuteUpdate(p => p.SetProperty(p => p.Price, u => ((newPrice - u.Price) / u.Price) * 100));
    Console.WriteLine(percentageIncreaser);
}

//Task 23:  Delete orders from the "Orders" table that were placed more than a year ago

using (ApplicationContext db = new ApplicationContext())
{

    var orders = db.Orders.Where(o => o.OrderDate < DateTime.Today.AddDays(-365)).ExecuteDelete();
}












//Task1 Use FromSqlRaw to retrieve products with prices greater than a specified value from the "Products" table.

using (ApplicationContext db = new ApplicationContext())
{
    
    var price = 50000;
    var products= db.products.FromSqlRaw("SELECT * FROM Products WHERE Price > {0}", price).ToList();
    foreach (var item in products)
    Console.WriteLine(item.Name);
}

//Task 2  Use ExecuteSqlRaw to update product prices by a fixed amount for products in a certain category.

using (ApplicationContext db = new ApplicationContext())
{
    decimal newPrice = 8000;
    decimal productPrice = 9000;
    int numberOfRowUpdated = db.Database.ExecuteSqlRaw("UPDATE Products SET Price={0} WHERE Price={1}", newPrice, productPrice);


}

//Task3  Use FromSqlInterpolated to retrieve customers with contact numbers containing a specific substring from the "Customers" table.

using (ApplicationContext db = new ApplicationContext())
{
    var name = "%Tom%";
    var customers = db.Customers2.FromSqlInterpolated($"SELECT * FROM Customers WHERE Name LIKE {name} ").ToList();
    foreach (var item in customers)
        Console.WriteLine(item.Name);
}

//Task 4 Use ExecuteSqlInterpolated to delete customers from the "Customers" table who have not placed any orders in the last six months. ?
using(ApplicationContext db = new ApplicationContext())
{
    DateTime date = DateTime.Today.AddMonths(-6);
    int numberOfRowDeleted = db.Database.ExecuteSqlRaw("DELETE FROM Customers2 WHERE Orders.OrderDate<{0}", date);
   
}

//Task 5 Utilize a scalar-valued stored function to calculate the age of a specific customer based on their birthdate
