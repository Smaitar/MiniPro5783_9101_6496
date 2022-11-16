

using DO;
using System.Security.Cryptography;
namespace Dal;

public class DalProduct
{

    public int AddProduct(Product ord)
    {
        //Add an object to the list
        if (DataSource.ProductsList.Exists(i => i?.ID == ord.ID))
            throw new Exception("cannot create a Products In ProductsList, is already exists");
        DataSource.ProductsList.Add(ord);
        return (ord.ID);
    }

    public int DeleteOrder(int IdDelete)
    {
        //delete a object acoording to its ID
        if (!DataSource.ProductsList.Exists(i => i?.ID == IdDelete))
            throw new Exception("cannot create a Products In ProductsList, is already exists");
        for (int i = 0; i <= DataSource.ProductsList.Count; i++)
        {
            if (DataSource.ProductsList[i]?.ID == IdDelete)
            {
                DataSource.ProductsList.Remove(DataSource.ProductsList[i]);
                break;
            }
        }
        return 0;
    }

    public void UpdateOrder(Product ordUpdate)
    {
        //update an object according to its ID
        if (!DataSource.ProductsList.Exists(i => i?.ID == ordUpdate.ID))
            throw new Exception("cannot update a Products In ProductsList, is not exists");
        for (int i = 0; i < DataSource.ProductsList.Count; i++)
        {
            if (DataSource.ProductsList[i]?.ID == ordUpdate.ID)
            {
                DataSource.ProductsList.Remove(DataSource.ProductsList[i]);
                DataSource.ProductsList.Add(ordUpdate);
            }
        }
    }
    public List<Product?> GetAll()//get all the object in the list
    {
        List<Product?> list = new List<Product?>();   
        DataSource.ProductsList.ForEach(i=> list.Add(i));   
        return list;    
    }  
    public Product? GetById(int idcheck)//get an Id ant return its object
    {
        Product? p = DataSource.ProductsList.Find(i => i?.ID == idcheck) ?? throw new Exception("not found");   
        return p;
    }
}
