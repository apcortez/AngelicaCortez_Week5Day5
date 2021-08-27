using System;

namespace Week5Day5
{
    class Program
    {
        //Un impegno ha:
        //- Titolo
        //- Descrizione
        //- Data di scadenza(posteriore alla data di inserimento)
        //- Importanza(Alta, Media, Bassa)
        //- Flag per sapere se è stato già portato a termine(Di default lo stato è NON fatto)
        //Il programma permette di:
        //- visualizzare tutti gli impegni
        //- modificare un impegno
        //- eliminare un impegno
        //- inserire un nuovo impegno
        //- visualizzare gli impegni per data maggiore o uguale alla data inserita dall'utente
        //- visualizzare gli impegni per il livello di importanza inserito dall'utente
        //- visualizzare gli impegni portati a termine
        //Opzionali:
        //- nella modifica di un impegno rendere lo stato di “portato a termine” non modificabile
        //- aggiungere una funzione che, scelto un impegno metta il flag portato a termine(NB.è possibile portare a
        //termine impegni non ancora portati a termine)
        //Note:
        //- rispettare la corretta struttura(Ogni classe e ogni metodo hanno uno e un solo scopo)
        //- creare un repository fittizio(quindi anche le interfacce)
        //- salvare i dati su Sql Server tramite ADO.Net
        static void Main(string[] args)
        {
            Menu.Start();
        }
    }
}
