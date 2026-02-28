using TestTP1.ClassesTest;
using TP1.Billeterie;

namespace TestTP1.Billeterie;

public class AbstractBilletTest
{
    private static BilletTestable billet;

    [SetUp]
    public void Setup()
    {
        billet = new BilletTestable();
    }
    [Test]
    public void Constructeur_AssigneId()
    {
        BilletTestable b1 = new();
        BilletTestable b2 = new();
        Assert.That(b1.Id, Is.Not.EqualTo(b2.Id));
    }

    [Test]
    public void CalculerNombreNumerosGagnants_RetourneZero_ParDefaut()
    {
        BilletTestable billetTire = new();

        billet.ListeNumero.AddRange(new[] { 1, 2, 3, 4, 5, 6 });
        billetTire.ListeNumero.AddRange(new[] { 1, 2, 3, 4, 5, 6 });

        Assert.That(billet.CalculerNombreNumerosGagnants(billetTire), Is.EqualTo(0));
    }
}