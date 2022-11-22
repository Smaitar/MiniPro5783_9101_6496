﻿

using DO;
using System.Security.Cryptography;

using DalApi;
namespace Dal;


internal class DalProduct : IProduct
{

    public int Add(Product ord)
    {
        //Add an object to the list
        if (DataSource.ProductsList.Exists(i => i?.ID == ord.ID))
            throw new Exception("cannot create a Products In ProductsList, is already exists");
        DataSource.ProductsList.Add(ord);
        return (ord.ID);
    }

    public int Delete(int IdDelete)
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

    public void Update(Product ordUpdate)
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
    public IEnumerable<Product> GetAll()//get all the object in the list
    {
        List<Product?> list = new List<Product?>();   
        DataSource.ProductsList.ForEach(i=> list.Add(i));   
        return (IEnumerable<Product>)list;    
    }  
    public Product GetByID (int idcheck)//get an Id ant return its object
    {
        Product p = DataSource.ProductsList.Find(i => i?.ID == idcheck) ?? throw new Exception("not found");   
        return p;
    }
}
