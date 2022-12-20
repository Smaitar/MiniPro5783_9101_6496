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
    string path = "products.xml";

    public int Add(Product Or)
    {
        List<Product> prodLst = XmlTools.LoadListFromXMLSerializer<Product>(path);

        if (prodLst.Exists(x => x.ID == Or.ID))
            throw new NotExist("Product");

        prodLst.Add(Or);

        XmlTools.SaveListToXMLSerializer(prodLst, path);

        return Or.ID;
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

    public void Update(Product Or)
    {

        var newList = XmlTools.LoadListFromXMLSerializer<Product>(path);
        int index = newList.FindIndex(x => x.ID == Or.ID);
        if (index == -1)
            throw new NotExist("the order is't exsit\n");

        newList.Insert(index, Or);
        XmlTools.SaveListToXMLSerializer(newList, path);  
    }
}

