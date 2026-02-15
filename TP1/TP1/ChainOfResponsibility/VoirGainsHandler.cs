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
            
            List<AbstractBillet> listeBillet = (List<AbstractBillet>) dictionnaire["listeBillets"];
            AbstractBillet billetTire = (AbstractBillet) dictionnaire["billetsTire"];
            foreach (AbstractBillet billet in listeBillet)
            {
                
            }
            
            
            
            
            
            
            
            int revenu = (int)dictionnaire["nombreBilletVendu"] * AbstractBillet.PRIX_BILLETS;
            
            
        } else if ((TypeBillet) dictionnaire["typeBillet"] == TypeBillet.Combinaison)
        {
            
            
            
            
        }
        base.Handle(dictionnaire);
    }


    
}