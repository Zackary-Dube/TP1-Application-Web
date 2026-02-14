using System.Collections.Generic;
using TP1.Billeterie;

namespace TP1;

public class AbstractBilletSequence : AbstractBillet
{
    public List<int> ListeNumero { get; set; }
    public AbstractBilletSequence(List<int> listeNumero)
    {
        ListeNumero = listeNumero;
    }
}