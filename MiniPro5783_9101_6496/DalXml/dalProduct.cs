using Dal;
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Dal;

//short implementation with XMLTools functions
internal class dalProduct : IProduct
{
    string path = @"..\products.xml";
    string configPath = @"..\config.xml";

    XElement productRoot;

    public dalProduct()
    {
        LoadData();
    }

    private void LoadData()
    {
        try
        {
            if (File.Exists(path))
                productRoot = XElement.Load(path);
            else
            {
                productRoot = new XElement("products");
                productRoot.Save(path);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("product File upload problem" + ex.Message);
        }
    }

    public int Add(Product product)
    {

        List<Product> ordrList = XmlTools.LoadListFromXMLSerializer<Product>(path);

        if (ordrList.Exists(x => x.ID == product.ID))
            throw new NotExist("product");

        XElement Id = new XElement("ID", product.ID);
        XElement name = new XElement("Name", product.Name);
        XElement category = new XElement("Category", product.Category);
        XElement inStock = new XElement("InStock", product.InStock);
        XElement price = new XElement("Price", product.Price);


        productRoot.Add(new XElement("Product", Id, name, category, price, inStock));
        productRoot.Save(path);

        return product.ID;
    }

    public void Delete(int id)
    {
        var newList = XmlTools.LoadListFromXMLSerializer<Product>(path);
        int index = newList.FindIndex(x => x.ID == id);
        if (index == -1)
            throw new NotExist("the order is't exsit\n");

        newList.RemoveAt(index);
        XmlTools.SaveListToXMLSerializer(newList, path);
    }

    public Product GetByCondition(Func<Product?, bool>? cond)
    {
        return (from item in XmlTools.LoadListFromXMLSerializer<Product>(path)
                where cond(item)
                select item).FirstOrDefault();
    }

    public IEnumerable<Product?> GetAll(Func<Product?, bool>? cond = null)
    {
        List<DO.Product?> prodList = XmlTools.LoadListFromXMLSerializer<DO.Product?>(path);

        if (cond == null)
            return prodList.AsEnumerable().OrderByDescending(p => p?.ID);

        return prodList.Where(cond).OrderByDescending(p => p?.ID);

    }

    public Product GetByID(int id)
    {
        return (from item in XmlTools.LoadListFromXMLSerializer<Product>(path)
                where item.ID == id
                select item).FirstOrDefault();
    }

    public void Update(Product Pr)
    {

        var newList = XmlTools.LoadListFromXMLSerializer<Product>(path);
        int index = newList.FindIndex(x => x.ID == Pr.ID);
        if (index == -1)
            throw new NotExist("the order is't exsit\n");

        newList[index] = Pr ;
        XmlTools.SaveListToXMLSerializer(newList, path);  
    }
}

