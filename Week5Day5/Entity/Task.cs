using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Week5Day5.Entity
{
    class TaskWork
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }

        public _Priority Priority { get; set; }
        public bool Finished { get; set; }

        public int? Id { get; set; }


        public TaskWork()
        {

        }

        public TaskWork(string Title, string Description, DateTime ExpirationDate, _Priority Priority, bool Finished, int? Id)
        {
            this.Title = Title;
            this.Description = Description;
            this.ExpirationDate = ExpirationDate;
            this.Priority = Priority;
            this.Finished = Finished;
            this.Id = Id;
        }

        public string Print()
        {
 

            return $"Titolo: {Title}, {Description} \nScadenza: {ExpirationDate.ToString("dd/MM/yyyy")} \nPriorità: {Priority} \nCompletato: {Finished}\n\n";
        }
    }

    enum _Priority
    {
        Low,
        Medium,
        High
    }
}
