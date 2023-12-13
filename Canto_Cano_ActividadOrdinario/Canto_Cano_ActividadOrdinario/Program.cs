using Canto_Cano_ActividadOrdinario.Enumeradores;
using Canto_Cano_ActividadOrdinario.Interfaces;
using Canto_Cano_ActividadOrdinario.Clases;

namespace Canto_Cano_ActividadOrdinario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DeckDeCartas mainDeck = new DeckDeCartas(new List<ICarta>());

            CrearMainDeck(mainDeck.Deck);
        }

        static void CrearMainDeck(List<ICarta> mainDeck) 
        {
            ICarta carta;
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 13; j++)

                {
                    mainDeck.Add(carta = new Cartas(j, i));
                }
            }

        }
    }
}
