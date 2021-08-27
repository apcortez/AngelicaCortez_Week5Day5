using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Day5.Entity;
using Week5Day5.Interface;

namespace Week5Day5.ListRepository
{
    class TaskListRepository : ITaskDbManager
    {
        static List<TaskWork> tasks = new List<TaskWork>
        {
            new TaskWork("Invio Email", "Inviare documenti personali per lavoro", new DateTime(2021, 09, 30), _Priority.Medium, false, 1),
            new TaskWork("Meeting Academy", "Allineamento settimanale", new DateTime(2021, 09, 3), _Priority.High, false, 2),
            new TaskWork("PC - Ado", "Pre-academy studio + prova", new DateTime(2021, 08, 27), _Priority.Low, true, 3)
        };
        public void Delete(TaskWork task)
        {
            tasks.Remove(task);
        }

        public List<TaskWork> Fetch()
        {
            return tasks;
        }

        public List<TaskWork> GetByDate(DateTime date)
        {
            return tasks.Where(t => t.ExpirationDate >= date).ToList();
        }

        public List<TaskWork> GetByFinishedTasks()
        {
            return tasks.Where(t => t.Finished == true).ToList();
        }

        public TaskWork GetById(int? id)
        {
            return tasks.Find(t => t.Id == id);
        }

        public List<TaskWork> GetByPriority(_Priority priority)
        {
            return tasks.Where(t => t.Priority == priority).ToList();
        }

        public List<TaskWork> GetUnfinishedTasks()
        {
            return tasks.Where(t => t.Finished == false).ToList();
        }

        public void Insert(TaskWork task)
        {
            tasks.Add(task);
        }

        public void Update(TaskWork task)
        {
            Delete(GetById(task.Id));
            Insert(task);
        }
    } 
}
