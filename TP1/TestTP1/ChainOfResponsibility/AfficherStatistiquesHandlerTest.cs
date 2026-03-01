using TP1.ChainOfResponsibility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using TP1.Statistiques;
using TP1;
using TP1.Billeterie;

namespace TestTP1.ChainOfResponsibility;

/// <summary>
/// Classe de test pour la classe AfficherStatistiquesHandler
/// </summary>
public class AfficherStatistiquesHandlerTest
{

    /// <summary>
    /// Vérifie que le Handler affiche bien les statistiques en console.
    /// </summary>
    [Test]
    public void Handle_AfficheStatistiques()
    {
        // Créer un billet tirage et une liste de billets client
        var tirage = new BilletCombinaison(new List<int> { 1, 2, 3, 4, 5, 6 });
        var billets = new List<AbstractBillet>
        {
            new BilletCombinaison(new List<int> { 1, 2, 3, 7, 8, 9 })
        };

        // Créer les stats et le handler qui permet de les afficher.
        var stats = new TP1.Statistiques.Statistiques(billets, tirage);
        var handler = new AfficherStatistiquesHandler();

        var dictionnaire = new Dictionary<string, object>
        {
            { "statistiques", stats }
        };

        // Vérifie ce qu'il y a dans la console.
        var sw = new StringWriter();
        Console.SetOut(sw);
        
        handler.Handle(dictionnaire);
        
        // Vérifie que la console contient les statistiques.
        string output = sw.ToString();
        Assert.That(output, Does.Contain("STATISTIQUES"));
    }
}