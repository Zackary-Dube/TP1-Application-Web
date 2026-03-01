using System;
using TP1.Options;
using TP1.Billeterie;

/* Ilias Neil */
namespace TP1.ChainOfResponsibility;

/// <summary>
/// Handler qui gere la création du billet de l'utilisateur
/// </summary>
public class CreationBilletReferenceHandler : AbstractHandler
{
    /// <summary>
    /// Créer un billet du bon type avec les numéros rentrés par l'utilisateur et l'ajoute a la loterie
    /// </summary>
    /// <param name="dictionnaire">Le dictionnaire contenant toute les infos nécéssaires</param>
    public override void Handle(Dictionary<string, object> dictionnaire)
    {
        Loterie loterie = (Loterie)dictionnaire["loterie"];
        TypeBillet type = (TypeBillet)dictionnaire["billetType"];
        List<int> numeros = (List<int>)dictionnaire["numerosUtilisateur"];

        AbstractBillet billetUtilisateur;

        if (type == TypeBillet.Combinaison)
        {
            billetUtilisateur = new BilletCombinaison(numeros);
            Console.WriteLine("Billet utilisateur créé : Combinaison");
        }
        else
        {
            billetUtilisateur = new BilletSequence(numeros);
            Console.WriteLine("Billet utilisateur créé : Sequence");
        }

        loterie.AjouterBilletListe(billetUtilisateur);

        dictionnaire["billetUtilisateur"] = billetUtilisateur;

        base.Handle(dictionnaire);
    }
}