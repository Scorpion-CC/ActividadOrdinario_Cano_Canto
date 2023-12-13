using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canto_Cano_ActividadOrdinario.Enumeradores;
using Canto_Cano_ActividadOrdinario.Interfaces;
using Canto_Cano_ActividadOrdinario.Clases;

namespace Canto_Cano_ActividadOrdinario.Clases
{
    public class Dealer : IDealer   
                                           

    {
        Random rand = new Random();
        // Esto es para barajear el deck del dealer, o cualquier otro

        public DeckDeCartas MainDeck;

        public void BarajearDeck()
        {
            MainDeck.BarajearDeck();
        }

        public void RecogerCartas(List<ICarta> cartas)
        {
            MainDeck.Cartas.AddRange(cartas);
        }

        public List<ICarta> RepartirCartas(int numeroDeCartas)
        {
            List<ICarta> deckTemporal = new List<ICarta>();
            for (int i = 0; i < numeroDeCartas; i++) 
            {
                deckTemporal.Add(MainDeck.SacarCarta(0));
            }
            return deckTemporal;
        }

        public Dealer(DeckDeCartas deck)
        {
            MainDeck = deck;
        }
    }
}
