using System;
using TP1.Options;
using TP1.Statistiques;

/* Ilias Neil */
namespace TP1.ChainOfResponsibility;

/// <summary>
/// Handler qui gere le calcul et l'affichage des statistiques
/// </summary>
public class AfficherStatistiquesHandler : AbstractHandler
{
    /// <summary>
    /// Lance le calcul et l'affichage des statistiques
    /// </summary>
    /// <param name="dictionnaire"></param>
    public override void Handle(Dictionary<string, object> dictionnaire)
    {
        if (dictionnaire.ContainsKey("statistiques"))
        {
            TP1.Statistiques.Statistiques stats = (TP1.Statistiques.Statistiques)dictionnaire["statistiques"];

            stats.CalculerStatistiques();
            stats.AfficherStatistiques();
        }

        base.Handle(dictionnaire);
    }
}