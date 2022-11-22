using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
     public interface ICrud<T> where T :struct 
    {
        public int Add(T add);  
        public void Update(T update);   
        public int Delete(int delete);
        public IEnumerable<T> GetAll();
        public T GetByID(int id);
    }
}
