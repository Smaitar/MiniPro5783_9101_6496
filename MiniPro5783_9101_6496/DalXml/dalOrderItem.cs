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
    string path = @"..\xml\orderItems.xml";
    string configPath = @"..\xml\config.xml";
    //string dir = @"..\bin\xml\";

    XElement ordersItemsRoot;

    public dalOrderItem()
    {
        LoadData();
    }

    private void LoadData()
    {
        if (!File.Exists(path))
            throw new Exception("order item File upload problem");
        else
        {
            ordersItemsRoot = XElement.Load(path);
        }
    }

    public int Add(OrderItem Or)
    {
        XElement configRoot = XElement.Load(configPath);
        var v = configRoot.Element("orderitemSeq");
        int nextSeqNum = Convert.ToInt32(configRoot.Element("orderitemSeq")!.Value);
        nextSeqNum++;
        Or.ID = nextSeqNum;
        //update config file
        configRoot.Element("orderitemSeq")!.SetValue(nextSeqNum);
        configRoot.Save(configPath);


        List<OrderItem> orderItemList = XmlTools.LoadListFromXMLSerializer<OrderItem>(path);

        if (orderItemList.Exists(x => x.ID == Or.ID))
            throw new NotExist("OrderItem");

        orderItemList.Add(Or);
        XmlTools.SaveListToXMLSerializer(orderItemList, path);
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

        return (from item in XmlTools.LoadListFromXMLSerializer<OrderItem>(path)
                where cond(item)
                select item).FirstOrDefault();
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
        List<OrderItem> prodLst = XmlTools.LoadListFromXMLSerializer<OrderItem>(path);

        if (prodLst.Exists(x => x.ID == id))
            throw new NotExist("OrderItem");

        return (from item in XmlTools.LoadListFromXMLSerializer<OrderItem>(path)
                where item.ID == id
                select item).FirstOrDefault();
    }

    public void Update(OrderItem Or)
    {
        //var newList = XmlTools.LoadListFromXMLSerializer<OrderItem>(path);
        //int index = newList.FindIndex(x => x.ID == Or.ID);
        //if (index == -1)
        //    throw new NotExist("the OrderItem is't exsit\n");

        //newList[index] = Or;
        //XmlTools.SaveListToXMLSerializer(newList, path);
        Delete(Or.ID);
        Add(Or);
    }
}
