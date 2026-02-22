using TP1.Billeterie;
using TP1.Options;

namespace TP1.ChainOfResponsibility;

/// <summary>
/// Handler responsable du calcul des gains selon le type de billet (combinaison | séquence)
/// Transmet l’exécution au prochain handler
/// </summary>
public class VoirGainsHandler : AbstractHandler
{
    
    
/// <summary>
/// Calcule les gains de la loterie en fonction du billet tiré (combinaison | séquence)
/// Transmet l’exécution au prochain handler
/// </summary>
/// <param name="dictionnaire">Dictionnaire contenant les informations nécessaires</param>
    public override void Handle(Dictionary<string, object> dictionnaire)
    {
        if ((TypeBillet) dictionnaire["billetType"] == TypeBillet.Sequence)
        {
            ((Loterie) dictionnaire["loterie"]).CalculeGain();
        } else if ((TypeBillet) dictionnaire["typeBillet"] == TypeBillet.Combinaison)
        {
            
            
            
        }
        base.Handle(dictionnaire);
    }
}