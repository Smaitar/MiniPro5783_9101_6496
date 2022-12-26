﻿

using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Dal;

internal class dalOrder : IOrder
{
    string path = @"..\orders.xml";
    string configPath = @"..\config.xml";


    XElement ordersRoot;

    public dalOrder()
    {
        LoadData();
    }

    private void LoadData()
    {
        try
        {
            if (File.Exists(path))
                ordersRoot = XElement.Load(path);
            else
            {
                ordersRoot = new XElement("orders");
                ordersRoot.Save(path);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("order File upload problem" + ex.Message);
        }
    }

    public int Add(Order Or)
    {
        //Read config file
        XElement configRoot = XElement.Load(configPath);
        var v = configRoot.Element("orderSeq");
        int nextSeqNum = Convert.ToInt32(configRoot.Element("orderSeq")!.Value);
        nextSeqNum++;
        Or.ID = nextSeqNum;
        //update config file
        configRoot.Element("orderSeq")!.SetValue(nextSeqNum);
        configRoot.Save(configPath);

        XElement Id = new XElement("Id", Or.ID);
        XElement CustomerName = new XElement("CustomerName", Or.CustomerName);
        XElement CustomerEmail = new XElement("CustomerEmail", Or.CustomerEmail);
        XElement CustomerAdress = new XElement("CustomerAdress", Or.CustomerAdress);
        XElement OrderDate = new XElement("OrderDate", Or.OrderDate);
        XElement ShipDate = new XElement("ShipDate", Or.ShipDate);
        XElement DeliveryDate = new XElement("DeliveryDate", Or.DeliveryDate);


        ordersRoot.Add(new XElement("Order", Id, CustomerName, CustomerEmail, CustomerAdress, OrderDate, ShipDate, DeliveryDate));
        ordersRoot.Save(path);

        return Or.ID;

    }

    public void Delete(int id)
    {
        List<Order> ordeLst = XmlTools.LoadListFromXMLSerializer<Order>(path);
        int index = ordeLst.FindIndex(x => x.ID == id);
        if (index == -1)
            throw new NotExist("Order");

        ordeLst.RemoveAt(index);

        XmlTools.SaveListToXMLSerializer(ordeLst, path);
    }

    public Order GetByCondition(Func<Order?, bool>? cond)
    {
        return (from item in XmlTools.LoadListFromXMLSerializer<Order>(path)
                where cond(item)
                select item).FirstOrDefault();
    }

    public IEnumerable<Order?> GetAll(Func<Order?, bool>? cond = null)
    {
        List<DO.Order?> orderList = XmlTools.LoadListFromXMLSerializer<DO.Order?>(path);

        if (cond == null)
            return orderList.AsEnumerable().OrderByDescending(p => p?.ID);

        return orderList.Where(cond).OrderByDescending(p => p?.ID);
    }

    public Order GetByID(int id)
    {
        List<Order> prodLst = XmlTools.LoadListFromXMLSerializer<Order>(path);

        if (prodLst.Exists(x => x.ID == id))
            throw new NotExist("OrderItem");

        return (from item in XmlTools.LoadListFromXMLSerializer<Order>(path)
                where item.ID == id
                select item).FirstOrDefault();
    }

    public void Update(Order Or)
    {
        var newList = XmlTools.LoadListFromXMLSerializer<Order>(path);
        int index = newList.FindIndex(x => x.ID == Or.ID);
        if (index == -1)
            throw new NotExist("the OrderItem is't exsit\n");

        newList[index] = Or;
        XmlTools.SaveListToXMLSerializer(newList, path);
    }
}

