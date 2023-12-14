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
    public class Jugador : IJugador
    {
        public List<ICarta> Deck 
        {
            get;
            set;
        }

        public ICarta DevolverCarta(int indiceCarta)
        {
            ICarta cartaTemp; //variable temporal tipo ICarta para guardar y eliminar del Deck la carta que se va a devolver.
            cartaTemp = Deck[indiceCarta];
            Deck.RemoveAt(indiceCarta);
            return cartaTemp;
        }

        public List<ICarta> DevolverTodasLasCartas()
        {
            List<ICarta> deckTemp = new List<ICarta>(); //Lista temporal tipo ICarta para poder guardar las cartas que se van a devolver, y así poder eliminarlas antes de que eso pase.
            deckTemp.AddRange(Deck);
            Deck.Clear();
            return deckTemp;
        }

        public ICarta MostrarCarta(int indiceCarta)
        {
            Console.WriteLine($"{Deck[indiceCarta-1].Valor} de {Deck[indiceCarta-1].Figura}");
            return Deck[indiceCarta-1];
        }

        public List<ICarta> MostrarCartas() 
        {
            for(int i = 0; i < Deck.Count; i++)
            {
                Console.WriteLine($"{Deck[i].Valor} de {Deck[i].Figura}");
            }
            return Deck;
        }

        public void ObtenerCartas(List<ICarta> cartas)
        {
            Deck.AddRange(cartas);
        }

        public void RealizarJugada()
        {
            throw new NotImplementedException(); //CC: No sé para qué es esta función :(
        }

        public Jugador(List<ICarta> deck) 
        {
            Deck = deck;
        }
    }
}
