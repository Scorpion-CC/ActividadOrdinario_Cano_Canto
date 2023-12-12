using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canto_Cano_ActividadOrdinario.Interfaces;

namespace Canto_Cano_ActividadOrdinario.Interfaces
{
    public interface IDeckDeCartas
    {
        void BarajearDeck();
        ICarta VerCarta(int indiceCarta);
        ICarta SacarCarta(int indiceCarta);
        void MeterCarta(ICarta carta);
        void MeterCarta(List<ICarta> cartas);
    }
}
