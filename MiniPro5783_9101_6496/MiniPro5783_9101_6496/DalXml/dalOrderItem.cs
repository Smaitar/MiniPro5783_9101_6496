using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal;
internal class dalOrderItem : IOrderItem
{
    string path = XmlTools.dir + "ordersItems.xml";
    XElement ordersItemsRoot;

    public dalOrderItem()
    {
        LoadData();
    }

    private void LoadData()
    {
        try
        {
            if (File.Exists(path))
                ordersItemsRoot = XElement.Load(path);
            else
            {
                ordersItemsRoot = new XElement("ordersItems");
                ordersItemsRoot.Save(path);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("product File upload problem" + ex.Message);
        }
    }

    public int Add(OrderItem Or)
    {
        List<OrderItem> prodLst = XmlTools.LoadListFromXMLSerializer<OrderItem>(path);

        if (prodLst.Exists(x => x.ID == Or.ID))
            throw new NotExist("OrderItem");

        prodLst.Add(Or);

        XmlTools.SaveListToXMLSerializer(prodLst, path);

        return Or.ID;
    }

    public void Delete(int id)
    {
        List<OrderItem> prodLst = XmlTools.LoadListFromXMLSerializer<OrderItem>(path);
        int index = prodLst.FindIndex(x => x.ID== id);
        if (index == -1)
            throw new NotExist("OrderItem");

        prodLst.RemoveAt(index);

        XmlTools.SaveListToXMLSerializer(prodLst, path);
    }

    public OrderItem GetByCondition(Func<OrderItem?, bool>? cond)
    {
        
        throw new NotImplementedException();
    }

    public IEnumerable<OrderItem?> GetAll(Func<OrderItem?, bool>? cond = null)
    {
        List<DO.OrderItem?> prodList = XmlTools.LoadListFromXMLSerializer<DO.OrderItem?>(path);

        if (cond == null)
            return prodList.AsEnumerable().OrderByDescending(p => p?.ID);

        return prodList.Where(cond).OrderByDescending(p => p?.ID);
    }

    public OrderItem GetByID(int id)
    {
        List<Product> prodLst = XmlTools.LoadListFromXMLSerializer<Product>(path);

        if (prodLst.Exists(x => x.ID == id))
            throw new NotExist("OrderItem");

        return (from item in XmlTools.LoadListFromXMLSerializer<OrderItem>(path)
                where item.ID == id
                select item).FirstOrDefault();
    }

    public void Update(OrderItem Or)
    {
        var newList = XmlTools.LoadListFromXMLSerializer<OrderItem>(path);
        int index = newList.FindIndex(x => x.ID == Or.ID);
        if (index == -1)
            throw new NotExist("the OrderItem is't exsit\n");

        newList.Insert(index, Or);
        XmlTools.SaveListToXMLSerializer(newList, path);
    }
}
