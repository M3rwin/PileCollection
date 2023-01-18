using System;
using System.Collections;

namespace PileCollection
{
    class Program
    {

        struct Pile
        {
            public int maxElt; // nombre max d'éléments de la pile
            //public int sommet; // indice du sommet (dernier élément de la pile)
            public ArrayList tabElem; //tableau [0..maxElt] d'entiers
        }

        static void Main(string[] args)
        {
            TestEmpilerDepiler(5);

            Console.WriteLine("Programme terminé, appuyer sur une touche pour continuer.");
            Console.ReadKey();
            
        }

        /// <summary>
        /// Méthode permettant d'initialiser une instance de la classe pile.
        /// Cette méthode :
        ///     initialise la variable maxElt
        ///     instancie la collection de type ArrayList tabElem
        /// </summary>
        /// <param name="unePile">Pile que l'on cherche à initialiser</param>
        /// <param name="nbElemt">Nombre d'éléments max de la Pile</param>
        static void InitPile(ref Pile unePile, int nbElemt)
        {
            unePile.tabElem = new ArrayList();
            if (nbElemt > 0)
            {
                unePile.maxElt = nbElemt;
            }
            else if (nbElemt < 0)
            {
                unePile.maxElt = Math.Abs(nbElemt);
            }
            else
            {
                throw new Exception("La pile ne peut pas avoir un nombre maximum d'élément égale à zéro");
            }
            
        }

        /// <summary>
        /// Retourne un booléen indiquant si la pile est vide.
        /// Une pile est vide lorsqu'elle ne contient aucun élément.
        /// </summary>
        /// <param name="unePile">La pile dont on veut savoir si elle est vide</param>
        /// <returns></returns>
        static bool EstVide(Pile unePile)
        {
            return unePile.tabElem.Count==0;
        }

        /// <summary>
        /// Retourne un booléen indiquant si la pile est pleine.
        /// Une pile est pleine lorsqu'elle contient un nombre d'élément
        /// égale au nombre maximum d'éléments qu'elle peut contenir.
        /// </summary>
        /// <param name="unePile">La pile dont on veut savoir si elle est pleine</param>
        /// <returns></returns>
        static bool EstPleine(Pile unePile)
        { 
            return unePile.tabElem.Count == unePile.maxElt;
        }

        /// <summary>
        /// Ajoute un élément de n'importe quel type à la pile.
        /// </summary>
        /// <param name="unePile">Pile sur laquelle on souhaite empiler</param>
        /// <param name="obj">Objet que l'on souhate empiler</param>
        static void Empiler(ref Pile unePile, Object obj)
        {
        if (EstPleine(unePile))
        {
           throw new Exception($"Pile pleine, impossible d'empiler l'élément \"{obj}\"");
        }
        else
        {
            unePile.tabElem.Add(obj);
        }
                
        }


        /// <summary>
        /// Renvoie la valeur située au sommet de la pile.
        /// Si la pile est vide, la méthode déclenche une Execption
        /// </summary>
        /// <param name="unePile">Pile sur laquelle on souhaite dépiler</param>
        /// <returns>Valeur dépilée</returns>
        static object Depiler(ref Pile unePile)
        {
            if (!EstVide(unePile))
            {
                object elem = unePile.tabElem[unePile.tabElem.Count-1];
                unePile.tabElem.RemoveAt(unePile.tabElem.Count-1);
                return elem;
            }
            else
            {
                throw new Exception("Impossible de dépiler, la pile est déjà vide");
            }
        }
           


        static void TestPileVidePilePleine(int nbElements)
        {
            Pile unePile = new Pile();
            InitPile(ref unePile, nbElements);
            if (EstVide(unePile))
            {
                Console.WriteLine("La pile est vide");
            }
            else
            {
                Console.WriteLine("La pile n'est pas vide");
            }
            if (EstPleine(unePile))
            {
                Console.WriteLine("La pile est pleine");
            }
            else
            {
                Console.WriteLine("La pile n'est pas pleine");
            }
        }


        static void TestEmpiler(int nbElem)
        {
            Pile unePile = new Pile();
            InitPile(ref unePile, nbElem);
            Empiler(ref unePile, 2);
            Empiler(ref unePile, 14);
            Empiler(ref unePile, 6);
        }


        static void TestEmpilerDepiler(int nbElem)
        {
            try
            {
                Pile unePile = new Pile();
                InitPile(ref unePile, nbElem);
                Empiler(ref unePile, 5);
                Empiler(ref unePile, 2);
                Empiler(ref unePile, 22);
                int valeurDepilee = (int)Depiler(ref unePile);
                Console.WriteLine("Valeur dépilée : {0}", valeurDepilee);
                Empiler(ref unePile, 17);
                valeurDepilee = (int)Depiler(ref unePile);
                valeurDepilee = (int)Depiler(ref unePile);
                valeurDepilee = (int)Depiler(ref unePile);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
