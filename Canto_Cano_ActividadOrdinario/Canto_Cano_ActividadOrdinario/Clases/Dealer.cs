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
    public class Dealer : IDealer, IJugador
    {
        Random rand = new Random();
        // variable = rand.Next(4, 21); (#minimo, #maximo, pero uno atras) /// Esto es para barajear el deck del dealer, o cualquier otro

        public List<ICarta> Deck;

        public void BarajearDeck()
        {
            throw new NotImplementedException();
        }

        public ICarta DevolverCarta(int indiceCarta)
        {
            throw new NotImplementedException();
        }

        public List<ICarta> DevolverTodasLasCartas()
        {
            throw new NotImplementedException();
        }

        public ICarta MostrarCarta(int indiceCarta)
        {
            throw new NotImplementedException();
        }

        public List<ICarta> MostrarCartas()
        {
            throw new NotImplementedException();
        }

        public void ObtenerCartas(List<ICarta> cartas)
        {
            throw new NotImplementedException();
        }

        public void RealizarJugada()
        {
            throw new NotImplementedException();
        }

        public void RecogerCartas(List<ICarta> cartas)
        {
            throw new NotImplementedException();
        }

        public List<ICarta> RepartirCartas(int numeroDeCartas)
        {
            throw new NotImplementedException();
        }

        public Dealer(List<ICarta> deck)
        {
            Deck = deck;
        }
    }
}
