using BlApi;
using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace BlImplementation
{
    internal class BLOrder:IBOOrder
    {
        IDal dal = new DalList();
        public IEnumerable<BO.OrderForList> GetOrderForListsManager()
        {
            IEnumerable<DO.Order> DOProduct = (List<DO.Order>)dal.GetAll() ;
            //orderForList=(DO.OrderForList)DOProduct;
            return orderForList
        }
        public IEnumerable<BO.OrderTracking> orderTrackings()
        {

        }
        public Order OrderDetails(int ID)
        {

        }
        public Order GetOrder()
        {

        }
        public void Updatae(int OrderID)
        {

        }
    }
}
