

using DO;
using static Dal.DataSource;

namespace Dal;

internal class DalOrderItem
{
    int AddOrder(OrderItem ordItem)
    {
        ordItem.OrderID = Config.OrderitemID;
        DataSource.orderitemsList.Add(ordItem);
        return ordItem.OrderID;
    }

    int DeleteOrderitem(int IdDelete)
    {
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

    void UpdateOrder(OrderItem ordUpdate)
    {
        ordUpdate.OrderID = Config.OrderitemID;
        for (int i = 0; i < DataSource.orderitemsList.Count; i++)
        {
            if (DataSource.orderitemsList[i].ID == ordUpdate.ID)
            {
                DataSource.orderitemsList.Remove(DataSource.orderitemsList[i]);
                DataSource.orderitemsList.Add(ordUpdate);
            }
        }
    }
}
