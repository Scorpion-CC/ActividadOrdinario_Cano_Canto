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
        public List<ICarta> Cartas
        {
            get;
            set;
        }

        public void BarajearDeck()
        {
            int numRandom1, numRandom2;              //variables para poder guardar la carta actual                                                
            ICarta cartaTemporal1, cartaTemporal2;   //y la anterior del deck sin que se pierdan.

            for (int i = 0; i < Cartas.Count * 2; i++) 
            {
                numRandom1 = rand.Next(0, Cartas.Count);
                numRandom2 = rand.Next(0, Cartas.Count);
                cartaTemporal1 = Cartas[numRandom1];
                cartaTemporal2 = Cartas[numRandom2];
                Cartas[numRandom1] = cartaTemporal2;
                Cartas[numRandom2] = cartaTemporal1;
            }
        }

        public void MeterCarta(ICarta carta)
        {
            Cartas.Add(carta);
        }

        public void MeterCarta(List<ICarta> cartas)
        {
            Cartas.AddRange(cartas);
        }

        public ICarta SacarCarta(int indiceCarta)
        {
            Console.WriteLine($"Ha sacado la carta" + Cartas[indiceCarta].ToString());
            return Cartas[indiceCarta];
        }

        public ICarta VerCarta(int indiceCarta)
        {
            return Cartas[indiceCarta];
        }

        public DeckDeCartas(List<ICarta> deck) 
        { 
            Cartas = deck;
        }
    }
}
