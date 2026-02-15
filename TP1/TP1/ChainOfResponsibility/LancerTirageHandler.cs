using System;
using System.Collections.Generic;
using TP1.Billeterie;

namespace TP1.ChainOfResponsibility;

public class LancerTirageHandler : AbstractHandler
{
    public LancerTirageHandler()
    {
        
    }

    public override void Handle(Dictionary<string, object> dictionnaire)
    {
        if ((TypeBillet)dictionnaire["billetType"] == TypeBillet.Sequence)
        {
            dictionnaire["BilletsTire"] = creationUnBilletSequence((int)dictionnaire["ValeurMaximumSimpleNumero"]);
        } else if ((TypeBillet) dictionnaire["typeBillet"] == TypeBillet.Combinaison)
        {
            
            
            
            
        }
        
        
        dictionnaire["message"] += "LancerTirage";

        base.Handle(dictionnaire);
    }
    
    public AbstractBillet creationUnBilletSequence(int valeurMaximum)
    {
        BilletSequence billet = new BilletSequence();
        billet.TrouveNumeroBilletAutomatique(valeurMaximum);
        return billet;
    }
    
}