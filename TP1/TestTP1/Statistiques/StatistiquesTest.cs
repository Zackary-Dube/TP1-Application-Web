using TP1;
using TP1.Billeterie;
using TP1.Statistiques;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestTP1.Statistiques;

/// <summary>
/// Classe de tests pour les méthodes de Statistiques.
/// </summary>
public class StatistiquesTest
{

    /// <summary>
    /// Créer un billet de type combinaison pour effectuer les tests
    /// </summary>
    /// <param name="numeros">Liste de numéros</param>
    /// <returns>Un billet combinaison</returns>
    private BilletCombinaison CreerBillet(params int[] numeros)
        {
            return new BilletCombinaison(new List<int>(numeros));
        }

    /// <summary>
    /// Vérifie que le total est 0 quand il n'y a aucun billet
    /// </summary>
        [Test]
        public void CalculerStatistiques_AucunBillet_TotauxDoiventEtreZero()
        {
            var billets = new List<AbstractBillet>();
            var tirage = CreerBillet(1,2,3,4,5,6);

            var stats = new TP1.Statistiques.Statistiques(billets, tirage);
            stats.CalculerStatistiques();
            
            Assert.That(stats.MontantTotalDepense, Is.EqualTo(0));
            Assert.That(stats.MontantTotalGagne, Is.EqualTo(0));
        }

    /// <summary>
    /// Vérifie les statistiques d'un billet perdant
    /// </summary>
        [Test]
        public void CalculerStatistiques_UnBilletPerdant()
        {
            var tirage = CreerBillet(1,2,3,4,5,6);

            var billets = new List<AbstractBillet>
            {
                CreerBillet(10,11,12,13,14,15)
            };

            var stats = new TP1.Statistiques.Statistiques(billets, tirage);
            stats.CalculerStatistiques();
            
            Assert.That(stats.MontantTotalDepense, Is.EqualTo(5));
            Assert.That(stats.MontantTotalGagne, Is.EqualTo(0));
        }

    /// <summary>
    /// Vérifie les statistiques d'un billet gagnant à 6 chiffres
    /// </summary>
        [Test]
        public void CalculerStatistiques_UnBillet6Numeros_GainCorrect()
        {
            var tirage = CreerBillet(1,2,3,4,5,6);

            var billets = new List<AbstractBillet>
            {
                CreerBillet(1,2,3,4,5,6)
            };

            var stats = new TP1.Statistiques.Statistiques(billets, tirage);
            stats.CalculerStatistiques();
            
            Assert.That(stats.MontantTotalDepense, Is.EqualTo(5));
            Assert.That(stats.MontantTotalGagne, Is.EqualTo(1000));
        }

    /// <summary>
    /// Vérifie les gains d'un billet en fonction du nombre de numéros gagnant
    /// </summary>
        [Test]
        public void CalculerStatistiques_MelangeBillets_GainsCumulesCorrectement()
        {
            var tirage = CreerBillet(1,2,3,4,5,6);

            var billets = new List<AbstractBillet>
            {
                CreerBillet(1,2,3,4,5,6),     // 6 numéros → 1000
                CreerBillet(1,2,3,4,5,20),    // 5 numéros → 100
                CreerBillet(1,2,3,4,20,21),   // 4 numéros → 20
                CreerBillet(1,2,3,20,21,22),  // 3 numéros → 5
                CreerBillet(10,11,12,13,14,15) // perdant
            };

            var stats = new TP1.Statistiques.Statistiques(billets, tirage);
            stats.CalculerStatistiques();
            
            Assert.That(stats.MontantTotalDepense, Is.EqualTo(25));
            Assert.That(stats.MontantTotalGagne, Is.EqualTo(1125));
        }

    /// <summary>
    /// Vérifie le calcul du profit
    /// </summary>
        [Test]
        public void CalculerStatistiques_ProfitCorrect()
        {
            var tirage = CreerBillet(1,2,3,4,5,6);

            var billets = new List<AbstractBillet>
            {
                CreerBillet(1,2,3,4,5,6)
            };

            var stats = new TP1.Statistiques.Statistiques(billets, tirage);
            stats.CalculerStatistiques();

            double profit = stats.MontantTotalDepense - stats.MontantTotalGagne;
            
            Assert.That(profit, Is.EqualTo(5 - 1000));
        }
}