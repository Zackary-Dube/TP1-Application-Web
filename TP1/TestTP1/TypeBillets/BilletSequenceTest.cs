/* Zackary Dubé */
using TP1;

namespace TestTP1.TypeBillets;

/// <summary>
/// Classe de tests unitaires pour la classe BilletSequence
/// </summary>
public class BilletSequenceTest
{
    /// <summary>
    /// Gain associé à une séquence de trois numéros consécutifs
    /// </summary>
    private const int PRIX_SEQUENCE_TROIS = 300;
    
    /// <summary>
    /// Gain associé à une séquence de quatre numéros consécutifs
    /// </summary>
    private const int PRIX_SEQUENCE_QUATRE = 1000;
    
    /// <summary>
    /// Gain associé à une séquence de cinq numéros consécutifs
    /// </summary>
    private const int PRIX_SEQUENCE_CINQ = 20000;
    
    /// <summary>
    /// Gain associé à une séquence de six numéros consécutifs
    /// </summary>
    private const int PRIX_SEQUENCE_SIX = 1000000;
    
    /// <summary>
    /// BilletSequence à tester
    /// </summary>
    private BilletSequence billet;
    
    /// <summary>
    /// BilletSequence qui sert de référence pour le calcul des gains
    /// </summary>
    private BilletSequence billetTire;
    
    /// <summary>
    /// Initialise deux nouvelles instances de BilletSequence
    /// </summary>
    [SetUp]
    public void Setup()
    {
        billet = new BilletSequence(new List<int> { 1, 2, 3, 4, 5, 6 });
        billetTire = new BilletSequence(new List<int> { 1, 2, 3, 4, 5, 6 });
    }
    
    /// <summary>
    /// Vérifie que le calcul du gain retourne 0
    /// Lorsque le billet et le billet tiré n’ont aucune séquence de numéros consécutifs en commun
    /// </summary>
    [Test]
    public void CalculerGain_AucuneSequenceCommune_RetourneZero()
    {
        billet.ListeNumero = new List<int> { 1, 2, 3, 4, 5, 6 };
        billetTire.ListeNumero = new List<int> { 10, 20, 30, 40, 50, 60 };
        Assert.That(billet.CalculerGainSiGagnant(billetTire), Is.EqualTo(0));
    }
    
    /// <summary>
    /// Test paramétré qui vérifie le calcul du gain pour différentes combinaisons de numéros
    /// Les cas de test sont fournis par TestCasesGain
    /// </summary>
    [TestCaseSource(nameof(TestCasesGain))]
    public double TestCalculerGain(List<int> numsBillet, List<int> numsTire)
    {
        billet.ListeNumero = numsBillet;
        billetTire.ListeNumero = numsTire;
        return billet.CalculerGainSiGagnant(billetTire);
    }

    /// <summary>
    /// Source de cas de test
    /// </summary>
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
    
    /// <summary>
    /// Source de cas de test pour le calcul des gains
    /// selon le nombre de numéros consécutifs gagnants
    /// </summary>
    public static IEnumerable<TestCaseData> TestCasesGain
    {
        get
        {
            // 3 consécutifs : 300$
            yield return new TestCaseData(new List<int> { 1, 2, 3, 4, 5, 6 }, new List<int> { 1, 2, 3, 9, 10, 11 }).Returns(PRIX_SEQUENCE_TROIS);
            // 4 consécutifs : 1000$
            yield return new TestCaseData(new List<int> { 5, 6, 7, 8, 9, 10 }, new List<int> { 6, 7, 8, 9, 20, 30 }).Returns(PRIX_SEQUENCE_QUATRE);
            // 5 consécutifs : 20000$
            yield return new TestCaseData(new List<int> { 1, 2, 3, 4, 5, 6 }, new List<int> { 2, 3, 4, 5, 6, 99 }).Returns(PRIX_SEQUENCE_CINQ);
            // 6 consécutifs : 1000000$
            yield return new TestCaseData(new List<int> { 1, 2, 3, 4, 5, 6 }, new List<int> { 1, 2, 3, 4, 5, 6 }).Returns(PRIX_SEQUENCE_SIX);
            // seulement 2 consécutifs → 0$
            yield return new TestCaseData(new List<int> { 1, 2, 3, 4, 5, 6 }, new List<int> { 5, 6, 99, 100, 101, 102 }).Returns(0);
        }
    }
    
    /// <summary>
    /// Vérifie que le constructeur lance une ArgumentNullException
    /// lorsque la liste de numéros fournie est nulle
    /// </summary>
    [Test]
    public void Constructeur_ListeNull_LanceArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new BilletSequence(null));
    }
    
    /// <summary>
    /// Vérifie que le constructeur lance une ArgumentException
    /// lorsque le nombre de numéros est invalide
    /// </summary>
    [Test]
    public void Constructeur_MauvaisNombreNumeros_LanceArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new BilletSequence(new List<int> { 1, 2, 3 }));
    }
    
    /// <summary>
    /// Vérifie que le constructeur lance une ArgumentOutOfRangeException
    /// lorsqu’un numéro est supérieur à la valeur maximale autorisée
    /// </summary>
    [Test]
    public void Constructeur_NumeroTropGrand_LanceArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new BilletSequence(new List<int> { 1, 2, 3, 4, 5, 101 }));
    }
    
    /// <summary>
    /// Vérifie que le constructeur lance une ArgumentOutOfRangeException
    /// lorsqu’un numéro est inférieur à 1
    /// </summary>
    [Test]
    public void Constructeur_NumeroPlusPetitQueUn_LanceArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new BilletSequence(new List<int> { 1, 2, 3, 4, 5, -1 }));
    }
}