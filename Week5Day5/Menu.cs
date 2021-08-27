using System;

namespace Week5Day5
{
    internal class Menu
    {
        internal static void Start()
        {

            bool continuare = true;
            Console.WriteLine("################# BENVENUTO! ################");
            do
            {
                    Console.WriteLine();
                    Console.WriteLine("#############################################");
                    Console.WriteLine("Selezionare un operazione da eseguire:");
                    Console.WriteLine("1 - Visualizzare tutti gli impegni ");
                    Console.WriteLine("2 - Modificare un impegno");
                    Console.WriteLine("3 - Eliminare un impegno");
                    Console.WriteLine("4 - Inserire un nuovo impegno");
                    Console.WriteLine("5 - Visualizzare gli impegni per data");
                    Console.WriteLine("6 - Visualizzare gli impegni per priorita");
                    Console.WriteLine("7 - Visualizzare gli impegni portati a termine");
                    Console.WriteLine("8 - Cambiare lo stato di un impegno in completato");
                    Console.WriteLine("0 - Per uscire");
                    Console.WriteLine("#############################################");

                    Console.WriteLine();
                    Console.WriteLine("Quale operazione vuoi scegliere?");
                    string scelta = Console.ReadLine();

                    switch (scelta)
                    {
                        case "1":
                            TaskManager.ShowTasks();
                            break;
                        case "2":
                            TaskManager.EditTask();
                            break;
                        case "3":
                            TaskManager.DeleteTask();
                            break;
                        case "4":
                            TaskManager.InsertTask();
                            break;
                        case "5":
                            TaskManager.FilterByExpirationDate();
                            break;
                        case "6":
                            TaskManager.FilterByPriority();
                            break;
                        case "7":
                            TaskManager.FilterByFinished();
                            break;
                        case "8":
                            TaskManager.EditIntoFinishedTask();
                            break;
                    case "0":
                            Console.WriteLine("Arrivederci. A presto!");
                            continuare = false;
                            break;
                        default:
                            Console.WriteLine("Scelta sbagliata riprova");
                            break;
                    }
                } while (continuare) ;
            }
    }
    }