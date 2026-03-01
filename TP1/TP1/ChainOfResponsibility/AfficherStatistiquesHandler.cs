using System;
using TP1.Options;
using TP1.Statistiques;

/* Ilias Neil */
namespace TP1.ChainOfResponsibility;

public class AfficherStatistiquesHandler : AbstractHandler
{
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