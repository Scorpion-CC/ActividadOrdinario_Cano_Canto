using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canto_Cano_ActividadOrdinario.Enumeradores;
using Canto_Cano_ActividadOrdinario.Interfaces;
using Canto_Cano_ActividadOrdinario.Clases;
using System.Collections.Specialized;

namespace Canto_Cano_ActividadOrdinario.Clases
{
    public class DeckDeCartas : IDeckDeCartas
    {
        Random rand = new Random();
        // variable = rand.Next(4, 21); 
        public List<ICarta> Deck 
        {
            get;
            set;
        }

        public void BarajearDeck()
        {
            int numRandom1, numRandom2;              //variables para poder guardar la carta actual                                                
            ICarta cartaTemporal1, cartaTemporal2;   //y la anterior del deck sin que se pierdan.

            for (int i = 0; i < Deck.Count * 2; i++) 
            {
                numRandom1 = rand.Next(0, 52);
                numRandom2 = rand.Next(0,52);
                cartaTemporal1 = Deck[numRandom1];
                cartaTemporal2 = Deck[numRandom2];
                Deck[numRandom1] = cartaTemporal2;
                Deck[numRandom2] = cartaTemporal1;
            }
        }

        public void MeterCarta(ICarta carta)
        {
            Deck.Add(carta);
        }

        public void MeterCarta(List<ICarta> cartas)
        {
            Deck.AddRange(cartas);
        }

        public ICarta SacarCarta(int indiceCarta)
        {
            Console.WriteLine($"Ha sacado la carta" + Deck[indiceCarta].ToString());
            return Deck[indiceCarta];
        }

        public ICarta VerCarta(int indiceCarta)
        {
            return Deck[indiceCarta];
        }

        public DeckDeCartas(List<ICarta> deck) 
        { 
            Deck = deck;
        }
    }
}
