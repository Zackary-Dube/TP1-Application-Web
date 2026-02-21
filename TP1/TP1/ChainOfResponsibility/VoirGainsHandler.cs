using System;
using System.Collections.Generic;
using TP1.Billeterie;

namespace TP1.ChainOfResponsibility;

public class VoirGainsHandler : AbstractHandler
{
    public VoirGainsHandler()
    {
        
    }
    
    public override void Handle(Dictionary<string, object> dictionnaire)
    {
        if ((TypeBillet) dictionnaire["billetType"] == TypeBillet.Sequence)
        {
            
            ((Loterie) dictionnaire["loterie"]).CalculeGain();
            
         
            
            
            
            
            
            
            int revenu = (int)dictionnaire["nombreBilletVendu"] * AbstractBillet.PRIX_BILLETS;
            
            
        } else if ((TypeBillet) dictionnaire["typeBillet"] == TypeBillet.Combinaison)
        {
            
            
            
            
        }
        base.Handle(dictionnaire);
    }


    
}