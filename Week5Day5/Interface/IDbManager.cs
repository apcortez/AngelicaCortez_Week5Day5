using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week5Day5.Entity;

namespace Week5Day5.Interface
{
    interface IDbManager
    {
        public List<TaskWork> Fetch();
        public TaskWork GetById(int? id);
        public void Insert(TaskWork task);
        public void Delete(TaskWork task);
        public void Update(TaskWork task);
    }
}
