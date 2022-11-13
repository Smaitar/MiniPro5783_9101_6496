
using DO;
using System.Security.Cryptography;
using static Dal.DataSource;

namespace Dal;

public class DalOrder
{

    int AddOrder(Order ord)
    {
        if (DataSource.OrdersList.Exists(i => i.ID == ord.ID))
            throw new Exception("cannot create a Order In OrderList, is already exists");
        ord.ID = Config.OrderID;
        DataSource.OrdersList.Add(ord);
        return(ord.ID); 
    }

    int DeleteOrder(int IdDelete)
    {
        if (!DataSource.OrdersList.Exists(i => i.ID == IdDelete))
            throw new Exception("cannot delete a Order In OrderList, is not exists");
        for (int i = 0; i < DataSource.OrdersList.Count; i++)
        {
            if (DataSource.OrdersList[i].ID == IdDelete)
            {
                DataSource.OrdersList.Remove(DataSource.OrdersList[i]);
                break;
            }
        }
        return 0;
    }

    void UpdateOrder(Order ordUpdate)
    {
        if (!DataSource.OrdersList.Exists(i => i.ID == ordUpdate.ID))
            throw new Exception("cannot update a Order In OrderList, is not exists");
        //ordUpdate.ID = Config.OrderID;
        for (int i = 0; i < DataSource.OrdersList.Count; i++)
        {
            if (DataSource.OrdersList[i].ID == ordUpdate.ID)
            {
                DataSource.OrdersList.Remove(DataSource.OrdersList[i]);
                DataSource.OrdersList.Add(ordUpdate);
            }
        }
    }
    public List<Order> RequestAll()
    {
        return DataSource.OrdersList;
    }
}

