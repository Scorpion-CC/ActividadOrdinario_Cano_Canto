﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canto_Cano_ActividadOrdinario.Interfaces
{
    public interface IDealer
    {
        List<ICarta> RepartirCartas(int numeroDeCartas);
        void RecogerCartas(List<ICarta> cartas);
        void BarajearDeck();
    }
}
