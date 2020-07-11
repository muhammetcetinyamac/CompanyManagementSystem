using CMS.BLL.Abstract;
using CMS.DAL.Abstract;
using CMS.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BLL.Concrete
{
    public class TasksService : ITasksService
    {
        ITasksDAL _tasksDAL;
        public TasksService(ITasksDAL tasksDAL)
        {
            _tasksDAL = tasksDAL;
        }
        public void Delete(Tasks entity)
        {
            _tasksDAL.Remove(entity);

        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public Tasks Get(int entityID)
        {
            return _tasksDAL.Get(a => a.Id == entityID);
        }

        public ICollection<Tasks> GetAll()
        {
            return _tasksDAL.GetAll();
        }

        public void Insert(Tasks entity)
        {
            _tasksDAL.Add(entity);
        }

        public void Update(Tasks entity)
        {
            _tasksDAL.Update(entity);
        }
    }
}
