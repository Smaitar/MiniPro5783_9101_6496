

using DalApi;
using DO;
using System;

namespace Dal;


internal class DalOrderItem : IOrderItem
{
    public int Add(OrderItem ordItem)
    {
        //Add an object to the list
        ordItem.ID = DataSource.Config.OrderitemID;
        //ordItem.OrderID = Config.OrderitemID;
        //ordItem.ProductID = Config.ProductID;    
        DataSource.orderitemsList.Add(ordItem);
        return ordItem.OrderID;
    }

    public void Delete(int IdDelete)
    {
        //delete a object acoording to its ID
        if (!DataSource.orderitemsList.Exists(i => i?.ID == IdDelete))
            throw new NotExist("cannot delete a OrderItem In OrderItemList, is not exists");
        for (int i = 0; i < DataSource.orderitemsList.Count; i++)
        {
            if (DataSource.orderitemsList[i]?.ID == IdDelete)
            {
                DataSource.orderitemsList.Remove(DataSource.orderitemsList[i]);
                break;
            }
        }
        //return 0;
    }

    public void Update(OrderItem ordUpdate)
    {
        //update an object according to its ID
        if (!DataSource.orderitemsList.Exists(i => i?.ID == ordUpdate.ID))
            throw new NotExist("cannot update a OrderItem In OrderList, is not exists");
        //ordUpdate.OrderID = Config.OrderitemID;
        //ordUpdate.ProductID = Config.ProductID;
        for (int i = 0; i < DataSource.orderitemsList.Count; i++)
        {
            if (DataSource.orderitemsList[i]?.ID == ordUpdate.ID)
            {
                DataSource.orderitemsList.Remove(DataSource.orderitemsList[i]);
                DataSource.orderitemsList.Add(ordUpdate);
            }
        }
    }

    public IEnumerable<OrderItem?> GetAll(Func <OrderItem?,bool> func = null)//get all the object in the list
    {
        List<OrderItem?> list = new List<OrderItem?>();
        DataSource.orderitemsList.ForEach(i => list.Add(i));
        return func is null ? list : list.Where(func);
    }

    public OrderItem GetByID(int idcheck)//get an Id ant return its object
    {
        OrderItem? p = DataSource.orderitemsList.Find(i => i?.ID == idcheck);
        if (p == null)
        {
            throw new NotExist("not found");
        }
        return (OrderItem)p;
    }
}
