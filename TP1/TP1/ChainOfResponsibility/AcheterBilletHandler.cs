using System;
using System.Collections.Generic;

namespace TP1.ChainOfResponsibility;

using TP1.Billeterie;
using TP1.Options;

public class AcheterBilletHandler : AbstractHandler
{
    public AcheterBilletHandler()
    {
    }
    
    public override void Handle(Dictionary<string, object> dictionnaire)
    {
        
        if ((TypeBillet) dictionnaire["billetType"] == TypeBillet.Sequence)
        {
            AbstractBillet abstractBillet = new AbstractBilletSequence(TrouveNumeroBilletAutomatique((int)dictionnaire["nombreNumero"]));
            List<AbstractBillet> listeBillet = new List<AbstractBillet>();
            
            listeBillet = (List<AbstractBillet>)dictionnaire["listeBillets"];
            listeBillet.Add(abstractBillet);
            dictionnaire["listeBillets"] =  listeBillet;
            
        } else if ((TypeBillet) dictionnaire["typeBillet"] == TypeBillet.Combinaison)
        {
            
            
            
            
        }
        base.Handle(dictionnaire);
    }

    public List<int> TrouveNumeroBilletAutomatique(int nombreNumero)
    {
        Random random = new Random();
        List<int> listeNumero = new List<int>();
        for (int i = 0; i < nombreNumero; i++)
        {
            listeNumero.Add(random.Next(9));
        }
        return listeNumero;
    }
}