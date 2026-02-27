using System;
using System.Collections.Generic;
using TP1.Billeterie;
using TP1.Options;

namespace TP1.ChainOfResponsibility;

/// <summary>
/// Handler responsable de l’achat des billets
/// Crée les billets selon le type sélectionné
/// Les ajoute à la loterie et affiche les numéros générés
/// </summary>
public class AcheterBilletHandler : AbstractHandler
{
    /// <summary>
    /// Traite l’action d’achat d’un billet
    /// Selon le type de billet (combinaison ou séquence), il crée le nombre de billets demandés, les ajoute à la loterie
    /// Transmet ensuite l’exécution au prochain handler
    /// </summary>
    /// <param name="dictionnaire">Dictionnaire contenant les informations necessaire a l'achat des billets</param>
    public override void Handle(Dictionary<string, object> dictionnaire)
    {
        if ((TypeBillet) dictionnaire["billetType"] == TypeBillet.Sequence)
        {
            Console.WriteLine("---- Liste des billets achetés ----");
            for (int i = 0; i < ((int) dictionnaire["nombreBilletVendu"]); i++)
                CreationBilletSequence((Loterie)dictionnaire["loterie"]);
        } else if ((TypeBillet) dictionnaire["billetType"] == TypeBillet.Combinaison)
        {
            Console.WriteLine("---- Liste des billets achetés ----");
            for (int i = 0; i < ((int) dictionnaire["nombreBilletVendu"]); i++)
                CreationBilletCombinaison((Loterie)dictionnaire["loterie"]);
        }
        base.Handle(dictionnaire);
        
        /*int nombre = (int)dictionnaire["nombreBilletVendu"];
        Loterie loterie = (Loterie)dictionnaire["loterie"];

        Console.WriteLine("---- Liste des billets achetés ----");

        for (int i = 0; i < nombre; i++)
        {
            CreationBilletSequence(loterie);
            CreationBilletCombinaison(loterie);
        }

        base.Handle(dictionnaire);*/
    }

    /// <summary>
    /// Crée un billet de type séquence, l’ajoute à la loterie et affiche les numéros du billet créé
    /// </summary>
    /// <param name="loterie">Instance de la loterie à laquelle le billet doit être ajouté</param>
    public void CreationBilletSequence(Loterie loterie)
    {
        AbstractBillet billet = new BilletSequence();
        loterie.AjouterBilletListe(billet);
        Console.WriteLine(string.Join(" ", billet.ListeNumero));
    }
    
    /// <summary>
    /// Crée un billet de type combinaison, l’ajoute à la loterie et affiche les numéros du billet créé
    /// </summary>
    /// <param name="loterie">Instance de la loterie à laquelle le billet doit être ajouté</param>
    public void CreationBilletCombinaison(Loterie loterie)
    {
        AbstractBillet billet = new BilletCombinaison();
        loterie.AjouterBilletListe(billet);
        Console.WriteLine(string.Join(" ", billet.ListeNumero));
    }
}