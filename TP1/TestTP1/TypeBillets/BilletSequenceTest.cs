using TP1;

namespace TestTP1.TypeBillets;

[TestFixture]
[TestOf(typeof(BilletSequence))]
public class BilletSequenceTest
{
    private const int PRIX_SEQUENCE_TROIS = 300;
    private const int PRIX_SEQUENCE_QUATRE = 1000;
    private const int PRIX_SEQUENCE_CINQ = 20000;
    private const int PRIX_SEQUENCE_SIX = 1000000;
    private BilletSequence billet;
    private BilletSequence billetTire;
    
    [SetUp]
    public void Setup()
    {
        billet = new BilletSequence(new List<int> { 1, 2, 3, 4, 5, 6 });
        billetTire = new BilletSequence(new List<int> { 1, 2, 3, 4, 5, 6 });
    }

    // -----------------------------
    // PRIX
    // -----------------------------
/*
    [Test]
    public void PrixBilletSequence_Est2()
    {
        Assert.That(billet.PRIX_BILLETS, Is.EqualTo(2));
    }
*/
    // -----------------------------
    // Cas NON gagnant
    // -----------------------------

    [Test]
    public void CalculerGain_AucuneSequence_Commune_Retourne0()
    {
        billet.ListeNumero = new List<int> { 1, 2, 3, 4, 5, 6 };
        billetTire.ListeNumero = new List<int> { 10, 20, 30, 40, 50, 60 };

        Assert.That(
            billet.CalculerGainSiGagnant(billetTire),
            Is.EqualTo(0)
        );
    }

    // -----------------------------
    // Cas gagnants (TestCaseSource)
    // -----------------------------

    [TestCaseSource(nameof(TestCasesGain))]
    public double TestCalculerGain(
        List<int> numsBillet,
        List<int> numsTire)
    {
        billet.ListeNumero = numsBillet;
        billetTire.ListeNumero = numsTire;

        return billet.CalculerGainSiGagnant(billetTire);
    }

    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(0).Returns(1);
            yield return new TestCaseData(1).Returns(4);
            yield return new TestCaseData(2).Returns(3);
            yield return new TestCaseData(3).Returns(7);
            yield return new TestCaseData(4).Returns(4);
            yield return new TestCaseData(5).Returns(8);
            yield return new TestCaseData(6).Returns(66);
            yield return new TestCaseData(7).Returns(23);
            yield return new TestCaseData(8).Returns(56);
            yield return new TestCaseData(9).Returns(13);
        }
    }
    
    public static IEnumerable<TestCaseData> TestCasesGain
    {
        get
        {
            // 3 consécutifs → 300$
            yield return new TestCaseData(new List<int> { 1, 2, 3, 4, 5, 6 }, new List<int> { 1, 2, 3, 9, 10, 11 }).Returns(PRIX_SEQUENCE_TROIS);

            // 4 consécutifs → 1000$
            yield return new TestCaseData(new List<int> { 5, 6, 7, 8, 9, 10 }, new List<int> { 6, 7, 8, 9, 20, 30 }).Returns(PRIX_SEQUENCE_QUATRE);

            // 5 consécutifs → 20000$
            yield return new TestCaseData(new List<int> { 1, 2, 3, 4, 5, 6 }, new List<int> { 2, 3, 4, 5, 6, 99 }).Returns(PRIX_SEQUENCE_CINQ);

            // 6 consécutifs → 1000000$
            yield return new TestCaseData(new List<int> { 1, 2, 3, 4, 5, 6 }, new List<int> { 1, 2, 3, 4, 5, 6 }).Returns(PRIX_SEQUENCE_SIX);

            // seulement 2 consécutifs → 0$
            yield return new TestCaseData(new List<int> { 1, 2, 3, 4, 5, 6 }, new List<int> { 5, 6, 99, 100, 101, 102 }).Returns(0);
        }
    }
    
    [Test]
    public void Constructeur_ListeNull_LanceArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new BilletSequence(null));
    }
    
    [Test]
    public void Constructeur_MauvaisNombreNumeros_LanceArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new BilletSequence(new List<int> { 1, 2, 3 }));
    }
    
    [Test]
    public void Constructeur_NumeroTropGrand_LanceArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new BilletSequence(new List<int> { 1, 2, 3, 4, 5, 101 }));
    }
    [Test]
    public void Constructeur_NumeroPlusPetitQueUn_LanceArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new BilletSequence(new List<int> { 1, 2, 3, 4, 5, -1 }));
    }
    
}