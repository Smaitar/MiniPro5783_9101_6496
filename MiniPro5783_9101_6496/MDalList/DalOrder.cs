
using DO;
namespace Dal;

public class DalOrder
{

    int AddOrder(Order ord)
    {
        DataSource.OrdersList.Add(ord);
        return(ord.ID); 
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

    void UpdateOrder(Order ordUpdate)
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

