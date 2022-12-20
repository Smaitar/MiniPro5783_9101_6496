

using DalApi;
using DO;
using System;

namespace Dal;


internal class DalProduct : IProduct
{

    public int Add(Product ord)
    {
        //Add an object to the list
        if (DataSource.ProductsList.Exists(i => i?.ID == ord.ID))
            throw new AlredyExist("cannot create a Products In ProductsList, is already exists");
        DataSource.ProductsList.Add(ord);
        return (ord.ID);
    }

    public void Delete(int IdDelete)
    {
        //delete a object acoording to its ID
        if (!DataSource.ProductsList.Exists(i => i?.ID == IdDelete))
            throw new AlredyExist("cannot create a Products In ProductsList, is already exists");
        for (int i = 0; i <= DataSource.ProductsList.Count; i++)
        {
            if (DataSource.ProductsList[i]?.ID == IdDelete)
            {
                DataSource.ProductsList.Remove(DataSource.ProductsList[i]);
                break;
            }
        }
        //return 0;
    }

    public void Update(Product ordUpdate)
    {
        //update an object according to its ID
        if (!DataSource.ProductsList.Exists(i => i?.ID == ordUpdate.ID))
            throw new NotExist("cannot update a Products In ProductsList, is not exists");
        for (int i = 0; i < DataSource.ProductsList.Count; i++)
        {
            if (DataSource.ProductsList[i]?.ID == ordUpdate.ID)
            { 
                DataSource.ProductsList.Remove(DataSource.ProductsList[i]);
                DataSource.ProductsList.Add(ordUpdate);
            }
        }
    }

    public IEnumerable<Product?> GetAll(Func<Product?,bool> func = null)//get all the object in the list
    {
        List<Product?> list = new List<Product?>();
        DataSource.ProductsList.ForEach(i => list.Add(i));
        return func is null ? list : list.Where(func);
    }

    public Product GetByID(int idcheck)//get an Id ant return its object
    {
        object p = DataSource.ProductsList.Find(i => i?.ID == idcheck)!;

        return p != null ? (Product)p : throw new NotExist("not found");
    }
}
