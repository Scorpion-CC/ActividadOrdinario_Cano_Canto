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
            return Deck[indiceCarta];
        }

        public List<ICarta> DevolverTodasLasCartas()
        {
            return Deck;
        }

        public ICarta MostrarCarta(int indiceCarta)
        {
            return Deck[indiceCarta];
        }

        public List<ICarta> MostrarCartas()
        {
            return Deck;
        }

        public void ObtenerCartas(List<ICarta> cartas)
        {
            Deck.AddRange(cartas);
        }

        public void RealizarJugada()
        {
            throw new NotImplementedException();
        }

        public Jugador(List<ICarta> deck) 
        {
            Deck = deck;
        }
    }
}
