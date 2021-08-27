using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Day5.Entity;

namespace Week5Day5.Interface
{
    interface ITaskDbManager : IDbManager
    {
        public List<TaskWork> GetByDate(DateTime date);
        public List<TaskWork> GetByPriority(_Priority priority);
        public List<TaskWork> GetByFinishedTasks();

        public List<TaskWork> GetUnfinishedTasks();

    }
}
