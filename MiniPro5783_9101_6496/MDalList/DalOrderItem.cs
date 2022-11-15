

using DO;
using System.Security.Cryptography;
using static Dal.DataSource;

namespace Dal;

public class DalOrderItem
{
    public int AddOrderItem(OrderItem ordItem)
    {
        //Add an object to the list
        if (DataSource.orderitemsList.Exists(i => i?.ID == ordItem.ID))
            throw new Exception("cannot create a OrderItem In OrderItemList, is already exists");
        //ordItem.OrderID = Config.OrderitemID;
        //ordItem.ProductID = Config.ProductID;    
        DataSource.orderitemsList.Add(ordItem);
        return ordItem.OrderID;
    }

    public int DeleteOrderitem(int IdDelete)
    {
        //delete a object acoording to its ID
        if (!DataSource.orderitemsList.Exists(i => i?.ID == IdDelete))
            throw new Exception("cannot delete a OrderItem In OrderItemList, is not exists");
        for (int i = 0; i < DataSource.orderitemsList.Count; i++)
        {
            if (DataSource.orderitemsList[i]?.ID == IdDelete)
            {
                DataSource.orderitemsList.Remove(DataSource.orderitemsList[i]);
                break;
            }
        }
        return 0;
    }

    public void UpdateOrder(OrderItem ordUpdate)
    {
        //update an object according to its ID
        if (!DataSource.orderitemsList.Exists(i => i?.ID == ordUpdate.ID))
            throw new Exception("cannot update a OrderItem In OrderList, is not exists");
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
    public List<OrderItem?> GetAll()
    {
        List<OrderItem?> list = new List<OrderItem?>();
        DataSource.orderitemsList.ForEach(i => list?.Add(i));
        return list;
    }
    public OrderItem? GetById(int idcheck)
    {
        OrderItem? p = DataSource.orderitemsList.Find(i => i?.ID == idcheck) ?? throw new Exception("not found");
        return p;
    }
}
