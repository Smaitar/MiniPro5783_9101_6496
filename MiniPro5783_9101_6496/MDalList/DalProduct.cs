

using DO;
namespace Dal;

internal class DalProduct
{

    int AddOrder(Product ord)
    {
        DataSource.ProductsList.
        DataSource.ProductsList.Add(ord);
        return (ord.ID);
    }

    int DeleteOrder(int IdDelete)
    {
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

    void UpdateOrder(Product ordUpdate)
    {
        for (int i = 0; i < DataSource.OrdersList.Count; i++)
        {
            if (DataSource.OrdersList[i].ID == ordUpdate.ID)
            {
                DataSource.OrdersList.Remove(DataSource.OrdersList[i]);
                DataSource.OrdersList.Add(ordUpdate);
            }
        }
    }
}
