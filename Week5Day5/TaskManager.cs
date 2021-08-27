using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week5Day5.AdoRepository;
using Week5Day5.Entity;
using Week5Day5.ListRepository;

namespace Week5Day5
{
    class TaskManager
    {
        //static TaskListRepository taskRepository = new TaskListRepository();
          static TaskSqlRepository taskRepository = new TaskSqlRepository();

        internal static void ShowTasks()
        {
            List<TaskWork> tasks = taskRepository.Fetch();
            foreach (var task in tasks)
                Console.WriteLine(task.Print());
        }

        internal static void EditTask()
        {  
            //si presuppone che si possono modificare solo gli impegni che non sono ancora stati portati a termine
            List<TaskWork> tasks = taskRepository.GetUnfinishedTasks();
            int i = 1;
            Console.WriteLine("Seleziona l'impegno da modificare");
            foreach (var t in tasks)
            {
                Console.WriteLine($"{i} - {t.Print()}");
                i++;
            }
            Console.WriteLine();

            bool isInt;
            int taskScelto;
            do
            {
                Console.WriteLine("Quale impegno vuoi modificare?");

                isInt = int.TryParse(Console.ReadLine(), out taskScelto);

            } while (!isInt || taskScelto <= 0 || taskScelto > tasks.Count);

            Console.WriteLine("Hai scelto di modificare. Rispondi solo si/no.");

            TaskWork task = tasks.ElementAt(taskScelto - 1);
            if (task.Id == null)
            {
                taskRepository.Delete(task);
            }

            bool continuare = true;
            string risposta;
            do
            {
                Console.WriteLine("Vuoi modificare il titolo?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                task.Title = InsertTitle();
            }

            continuare = true;
            do
            {
                Console.WriteLine("Vuoi modificare la descrizione?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                task.Description = InsertDescription();
            }

            continuare = true;
            do
            {
                Console.WriteLine("Vuoi modificare la data di scadenza?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                task.ExpirationDate = InsertExpDate();
            }

            continuare = true;
            do
            {
                Console.WriteLine("Vuoi modificare la priorita?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                task.Priority = InsertPriority();
            }

            taskRepository.Update(task);
        }

        internal static void DeleteTask()
        {
            List<TaskWork> tasks = taskRepository.Fetch();

            int i = 1;
            Console.WriteLine("Seleziona l'impegno da eliminare: ");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{i} - {task.Print()}");
                i++;
            }

            bool isInt;
            int taskScelto;
            do
            {
                Console.WriteLine("Quale impegno vuoi eliminare?");

                isInt = int.TryParse(Console.ReadLine(), out taskScelto);

            } while (!isInt || taskScelto <= 0 || taskScelto > tasks.Count);

            taskRepository.Delete(tasks.ElementAt(taskScelto - 1));
        }

        internal static void InsertTask()
        {
            TaskWork task = new TaskWork();
            task.Title = InsertTitle();
            task.Description = InsertDescription();
            task.ExpirationDate = InsertExpDate();
            task.Priority = InsertPriority();
            task.Finished = false;
            taskRepository.Insert(task);
        }

        private static _Priority InsertPriority()
        {
            bool isInt = false;
            int priority = 0;
            do
            {
                Console.WriteLine("Inserisci la priorita: ");
                foreach (var priorita in Enum.GetValues(typeof(_Priority)))
                {
                    Console.WriteLine($"Premi {(int)priorita} per {(_Priority)priorita}");
                }

                isInt = int.TryParse(Console.ReadLine(), out priority);
            } while (!isInt || priority < 0 || priority > 2);
            return (_Priority)priority;
        }

        private static DateTime InsertExpDate()
        {
            DateTime dt = new DateTime();
            bool isDate;
            do
            {
                Console.WriteLine("Inserisci la data di scadenza: yyyy-mm-dd");

                isDate = DateTime.TryParse(Console.ReadLine(), out dt);

            } while (!isDate || dt < DateTime.Today);
            return dt;
        }

        private static string InsertDescription()
        {
            string description = String.Empty;
            do
            {
                Console.WriteLine("Inserisci descrizione: ");
                description = Console.ReadLine();

            } while (String.IsNullOrEmpty(description));
            return description;
        }

        private static string InsertTitle()
        {
            string title = String.Empty;
            do
            {
                Console.WriteLine("Inserisci titolo: ");
                title = Console.ReadLine();

            } while (String.IsNullOrEmpty(title));
            return title;
        }

        internal static void FilterByExpirationDate()
        {
            DateTime date = InsertExpDate();
            List<TaskWork> tasks = taskRepository.GetByDate(date);
            foreach (var task in tasks)
            { 
                Console.WriteLine(task.Print()); 
            }
        }

        internal static void FilterByPriority()
        {
            _Priority priority = InsertPriority();
            List<TaskWork> tasks = taskRepository.GetByPriority(priority);
            foreach (var task in tasks)
            {
                Console.WriteLine(task.Print());
            }
        }

        internal static void FilterByFinished()
        {
            List<TaskWork> tasks = taskRepository.GetByFinishedTasks();
            foreach (var task in tasks)
            {
                Console.WriteLine(task.Print());
            }
        }

        internal static void EditIntoFinishedTask()
        {
            List<TaskWork> tasks = taskRepository.GetUnfinishedTasks();
            Console.WriteLine("Scegli l'impegno portato a termine ");
            int i = 1;
            foreach (var t in tasks)
            {
                Console.WriteLine($"{i} - {t.Print()}");
                i++;
            }
            Console.WriteLine();

            bool isInt;
            int taskScelto;
            do
            {
                Console.WriteLine("Quale task hai completato?");

                isInt = int.TryParse(Console.ReadLine(), out taskScelto);

            } while (!isInt || taskScelto <= 0 || taskScelto > tasks.Count);

            TaskWork task = tasks.ElementAt(taskScelto - 1);
            task.Finished = true;
            taskRepository.Update(task);
        }
    }
}
