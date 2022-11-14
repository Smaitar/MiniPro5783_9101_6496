

using DO;
using System.Security.Cryptography;
namespace Dal;

public class DalProduct
{

    public int AddOrder(Product ord)
    {
        if (DataSource.ProductsList.Exists(i => i.ID == ord.ID))
            throw new Exception("cannot create a Products In ProductsList, is already exists");
        DataSource.ProductsList.Add(ord);
        return (ord.ID);
    }

    public int DeleteOrder(int IdDelete)
    {
        if (!DataSource.ProductsList.Exists(i => i.ID == IdDelete))
            throw new Exception("cannot create a Products In ProductsList, is already exists");
        for (int i = 0; i < DataSource.ProductsList.Count; i++)
        {
            if (DataSource.OrdersList[i].ID == IdDelete)
            {
                DataSource.OrdersList.Remove(DataSource.OrdersList[i]);
                break;
            }
        }
        return 0;
    }

    public void UpdateOrder(Product ordUpdate)
    {
        if (!DataSource.ProductsList.Exists(i => i.ID == ordUpdate.ID))
            throw new Exception("cannot update a Products In ProductsList, is not exists");
        for (int i = 0; i < DataSource.ProductsList.Count; i++)
        {
            if (DataSource.ProductsList[i].ID == ordUpdate.ID)
            {
                DataSource.ProductsList.Remove(DataSource.ProductsList[i]);
                DataSource.ProductsList.Add(ordUpdate);
            }
        }
    }
    public List<Product> RequestAll()
    {
        return DataSource.ProductsList;
    }  
}
