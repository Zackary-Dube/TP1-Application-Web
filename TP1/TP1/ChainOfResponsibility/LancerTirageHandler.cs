/* Zackary Dubé */
using TP1.Billeterie;
using TP1.Options;

namespace TP1.ChainOfResponsibility;

/// <summary>
/// Handler responsable du lancement du tirage de la loterie
/// Il génère le billet gagnant et affiche les numéros tirés
/// Transmet ensuite l’exécution au prochain handler
/// </summary>
public class LancerTirageHandler : AbstractHandler
{
    /// <summary>
    /// Traite l’action de lancement du tirage selon le type de billet (combinaison | séquence)
    /// Affiche le billet gagnant et transmet l’exécution au prochain handler
    /// </summary>
    /// <param name="dictionnaire">Dictionnaire contenant les informations nécessaires au tirage</param>
    public override void Handle(Dictionary<string, object> dictionnaire)
    {
        if ((TypeBillet)dictionnaire["billetType"] == TypeBillet.Sequence)
        {
            Console.WriteLine("---- Billet gagnant ----");
            ((Loterie) dictionnaire["loterie"]).LancerTirageSequence();
            Console.WriteLine(string.Join(" ", (((Loterie) dictionnaire["loterie"]).BilletTire).ListeNumero));
        } else if ((TypeBillet) dictionnaire["billetType"] == TypeBillet.Combinaison)
        {
            Console.WriteLine("---- Billet gagnant ----");
            ((Loterie) dictionnaire["loterie"]).LancerTirageCombinaison();
            Console.WriteLine(string.Join(" ", (((Loterie) dictionnaire["loterie"]).BilletTire).ListeNumero));
        }
        base.Handle(dictionnaire);
    }
}