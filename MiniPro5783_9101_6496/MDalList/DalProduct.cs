﻿

using DalApi;
using DO;
namespace Dal;


internal class DalProduct : IProduct
{

    public int Add(Product ord)
    {
        //Add an object to the list
        if (DataSource.ProductsList.Exists(i => i.ID == ord.ID))
            throw new AlredyExist("cannot create a Products In ProductsList, is already exists");
        DataSource.ProductsList.Add(ord);
        return (ord.ID);
    }

    public int Delete(int IdDelete)
    {
        //delete a object acoording to its ID
        if (!DataSource.ProductsList.Exists(i => i.ID == IdDelete))
            throw new AlredyExist("cannot create a Products In ProductsList, is already exists");
        for (int i = 0; i <= DataSource.ProductsList.Count; i++)
        {
            if (DataSource.ProductsList[i].ID == IdDelete)
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
        if (!DataSource.ProductsList.Exists(i => i.ID == ordUpdate.ID))
            throw new NotExist("cannot update a Products In ProductsList, is not exists");
        for (int i = 0; i < DataSource.ProductsList.Count; i++)
        {
            if (DataSource.ProductsList[i].ID == ordUpdate.ID)
            {
                DataSource.ProductsList.Remove(DataSource.ProductsList[i]);
                DataSource.ProductsList.Add(ordUpdate);
            }
        }
    }
    public IEnumerable<Product> GetAll()//get all the object in the list
    {
        return from Product product in DataSource.ProductsList
               select new Product()
               {
                   ID = product.ID,
                   Name = product.Name,
                   Category = product.Category,
                   Price = product.Price,
                   InStock = product.InStock
               };
    }
    public Product GetByID(int idcheck)//get an Id ant return its object
    {
        object p = DataSource.ProductsList.Find(i => i.ID == idcheck);

        return p != null ? (Product)p : throw new NotExist("not found");
    }
}
