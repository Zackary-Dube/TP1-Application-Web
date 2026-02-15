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
            List<AbstractBillet> listeBillet = (List<AbstractBillet>) dictionnaire["listeBillets"];
            for (int i = 0; i < (int)dictionnaire["nombreBilletVendu"]; i++)
            {
                listeBillet.Add(creationUnBilletSequence((int)dictionnaire["ValeurMaximumSimpleNumero"]));
            }
            dictionnaire["listeBillets"] = listeBillet;
        } else if ((TypeBillet) dictionnaire["typeBillet"] == TypeBillet.Combinaison)
        {
            
            
            
            
        }
        base.Handle(dictionnaire);
    }

    /// <summary>
    /// Creation d'un billet sequence et mise a jour de la liste de billet
    /// </summary>
    /// <param name="dictionnaire">passe le dictionnaire avec toutes les donnees</param>
    public AbstractBillet creationUnBilletSequence(int valeurMaximum)
    {
        BilletSequence billet = new BilletSequence();
        billet.TrouveNumeroBilletAutomatique(valeurMaximum);
        return billet;
    }
    public void creationBilletCombinaison()
    {
        
        
        
    }
    
}