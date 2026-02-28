/* Zackary Dubé */
using TestTP1.ClassesTest;
using TP1.Billeterie;

namespace TestTP1.Billeterie;

/// <summary>
/// Classe de tests unitaires pour la classe AbstractBillet
/// </summary>
public class AbstractBilletTest
{
    /// <summary>
    /// Instance de BilletTestable utilisée dans chaque test
    /// </summary>
    private static BilletTestable billet;

    /// <summary>
    /// Initialise une nouvelle instance de BilletTestable
    /// </summary>
    [SetUp]
    public void Setup()
    {
        billet = new BilletTestable();
    }
    
    /// <summary>
    /// Vérifie que le constructeur assigne un identifiant unique à chaque billet créé
    /// (Dans deux billets différents, les identifiants ne doivent pas être identiques)
    /// </summary>
    [Test]
    public void Constructeur_AssigneId()
    {
        BilletTestable b1 = new();
        BilletTestable b2 = new();
        Assert.That(b1.Id, Is.Not.EqualTo(b2.Id));
    }

    /// <summary>
    /// Vérifie que la méthode CalculerNombreNumerosGagnants retourne 0 par défaut
    /// </summary>
    [Test]
    public void CalculerNombreNumerosGagnants_RetourneZeroParDefaut()
    {
        BilletTestable billetTire = new();
        billet.ListeNumero.AddRange(new[] { 1, 2, 3, 4, 5, 6 });
        billetTire.ListeNumero.AddRange(new[] { 1, 2, 3, 4, 5, 6 });
        Assert.That(billet.CalculerNombreNumerosGagnants(billetTire), Is.EqualTo(0));
    }
}