
using DO;
using System.Security.Cryptography;
using static Dal.DataSource;

namespace Dal;

public class DalOrder
{
    //Add an object to the list
    public int AddOrder(Order ord)
    {
        if (DataSource.OrdersList.Exists(i => i?.ID == ord.ID))//if it exist in the list
            throw new Exception("cannot create a Order In OrderList, is already exists");
        //ord.ID = Config.OrderID;
        DataSource.OrdersList.Add(ord);
        return(ord.ID); 
    }

    public int DeleteOrder(int IdDelete)
    {
        //delete a object acoording to its ID
        if (!DataSource.OrdersList.Exists(i => i?.ID == IdDelete))
            throw new Exception("cannot delete a Order In OrderList, is not exists");
        for (int i = 0; i < DataSource.OrdersList.Count; i++)
        {
            if (DataSource.OrdersList[i]?.ID == IdDelete)
            {
                DataSource.OrdersList.Remove(DataSource.OrdersList[i]);
                break;
            }
        }
        return 0;
    }

    public void UpdateOrder(Order ordUpdate)
    {
        //update an object according to its ID
        if (!DataSource.OrdersList.Exists(i => i?.ID == ordUpdate.ID))
            throw new Exception("cannot update a Order In OrderList, is not exists");
        //ordUpdate.ID = Config.OrderID;
        for (int i = 0; i < DataSource.OrdersList.Count; i++)
        {
            if (DataSource.OrdersList[i]?.ID== ordUpdate.ID)
            {
                DataSource.OrdersList.Remove(DataSource.OrdersList[i]);
                DataSource.OrdersList.Add(ordUpdate);
                break;
            }
        }
    }
    public List<Order?> GetAll()//get all the object in the list
    {
        List<Order?> list = new List<Order?>();
        DataSource.OrdersList.ForEach(i => list?.Add(i));
        return list;
    }
    public Order? GetById(int idcheck)//get an Id ant return its object
    {
        //search an object with a specific ID
        Order? p = DataSource.OrdersList.Find(i => i?.ID == idcheck) ?? throw new Exception("not found");
        return p;
    }
}

