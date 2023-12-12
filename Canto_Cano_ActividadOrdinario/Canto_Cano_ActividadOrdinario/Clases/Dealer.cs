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
        public void BarajearDeck()
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
    }
}
