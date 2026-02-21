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
            for (int i = 0; i < ((int) dictionnaire["nombreBilletVendu"]); i++)
            {
                AbstractBillet billet = new BilletSequence();
                ((Loterie) dictionnaire["loterie"]).AjouterBilletListe(billet);
            }
        } else if ((TypeBillet) dictionnaire["typeBillet"] == TypeBillet.Combinaison)
        {
            
            
            
            
        }
        base.Handle(dictionnaire);
    }
}