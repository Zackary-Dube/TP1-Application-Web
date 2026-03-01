using TP1;
using NUnit.Framework;

/* Ilias Neil */
namespace TestTP1;

/// <summary>
/// Classe de tests pour les méthodes de BilletCombinaison.
/// </summary>
public class BilletCombinaisonTest
{

    [Test]
    public void GenererNumerosDoitGenerer6NumerosUniqueEntre1Et50()
    {
        var billetCombinaison = new BilletCombinaison();
        
        billetCombinaison.GenererNumeros();

        foreach (int numero in billetCombinaison.Numeros)
        {
            Assert.That(billetCombinaison.Numeros, Is.Unique);
            Assert.That(numero, Is.LessThan(50));
        }
    }

    [Test]
    public void ComparerBilletsDoitRetournerNombreDeNumerosGagnant()
    {
        var BilletClient = new BilletCombinaison(new List<int>{1, 7, 9, 22, 15, 41});
        var BilletTirage = new BilletCombinaison(new List<int>{4, 35, 9, 33, 15, 44});
        
        int resultat = BilletClient.ComparerBillets(BilletTirage, BilletClient);
        
        Assert.That(resultat, Is.EqualTo(2));
    }
}