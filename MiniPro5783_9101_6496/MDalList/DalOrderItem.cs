

using DO;
using System.Security.Cryptography;
using static Dal.DataSource;

namespace Dal;

public class DalOrderItem
{
    public int AddOrderItem(OrderItem ordItem)
    {
        if (DataSource.orderitemsList.Exists(i => i.ID == ordItem.ID))
            throw new Exception("cannot create a OrderItem In OrderItemList, is already exists");
        ordItem.OrderID = Config.OrderitemID;
        ordItem.ProductID = Config.ProductID;    
        DataSource.orderitemsList.Add(ordItem);
        return ordItem.OrderID;
    }

    public int DeleteOrderitem(int IdDelete)
    {
        if (!DataSource.orderitemsList.Exists(i => i.ID == IdDelete))
            throw new Exception("cannot delete a OrderItem In OrderItemList, is not exists");
        for (int i = 0; i < DataSource.orderitemsList.Count; i++)
        {
            if (DataSource.orderitemsList[i].ID == IdDelete)
            {
                DataSource.orderitemsList.Remove(DataSource.orderitemsList[i]);
                break;
            }
        }
        return 0;
    }

    public void UpdateOrder(OrderItem ordUpdate)
    {
        if (!DataSource.orderitemsList.Exists(i => i.ID == ordUpdate.ID))
            throw new Exception("cannot update a OrderItem In OrderList, is not exists");
        //ordUpdate.OrderID = Config.OrderitemID;
        //ordUpdate.ProductID = Config.ProductID;
        for (int i = 0; i < DataSource.orderitemsList.Count; i++)
        {
            if (DataSource.orderitemsList[i].ID == ordUpdate.ID)
            {
                DataSource.orderitemsList.Remove(DataSource.orderitemsList[i]);
                DataSource.orderitemsList.Add(ordUpdate);
            }
        }
    }
    public List<OrderItem> GetAll()
    {
        return DataSource.orderitemsList;
    }
}
