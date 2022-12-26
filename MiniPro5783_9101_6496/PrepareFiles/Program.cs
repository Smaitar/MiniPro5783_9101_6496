// See https://aka.ms/new-console-template for more information


using Dal;

Console.WriteLine("Hello, World!");
Dal.XmlTools.SaveListToXMLSerializer(DataSource.ProductsList, "orders.xml");
Dal.XmlTools.SaveListToXMLSerializer(DataSource.ProductsList, "products.xml");
Dal.XmlTools.SaveListToXMLSerializer(DataSource.orderitemsList, "ordersItems.xml");
