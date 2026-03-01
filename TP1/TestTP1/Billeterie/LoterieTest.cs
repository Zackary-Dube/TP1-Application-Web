/* Zackary Dubé */
using TestTP1.ClassesTest;
using TP1;
using TP1.Billeterie;

namespace TestTP1.Billeterie;

/// <summary>
/// Classe de tests unitaires pour la classe Loterie
/// </summary>
public class LoterieTest
{
    /// <summary>
    /// Constante qui exprime le montant pour un billet (10$)
    /// </summary>
    private const int PRIX_AJOUTER_UN_BILLET = 10;
    
    /// <summary>
    /// Constante qui exprime le montant pour deux billet (20$)
    /// </summary>
    private const int PRIX_AJOUTER_DEUX_BILLETS = 20;
    
    /// <summary>
    /// Instance de Loterie utilisée dans chaque test
    /// </summary>
    private Loterie loterie;

    /// <summary>
    /// Initialise une nouvelle instance de Loterie
    /// </summary>
    [SetUp]
    public void Setup()
    {
        loterie = new Loterie();
    }

    /// <summary>
    /// Vérifie que l’ajout d’un billet augmente correctement le revenu
    /// Coût d’un billet : 10$ -- donc revenu = 10$
    /// </summary>
    [Test]
    public void AjouterUnBillet_AugmenteRevenu()
    {
        loterie.AjouterBilletListe(new BilletTestable());
        Assert.That(loterie.Revenu, Is.EqualTo(PRIX_AJOUTER_UN_BILLET));
    }

    /// <summary>
    /// Vérifie que l’ajout de deux billets additionne correctement le revenu
    /// 2 billets de 10$ chacun -- donc revenu = 20$
    /// </summary>
    [Test]
    public void AjouterDeuxBillets_RevenuAdditionne()
    {
        loterie.AjouterBilletListe(new BilletTestable());
        loterie.AjouterBilletListe(new BilletTestable());
        Assert.That(loterie.Revenu, Is.EqualTo(PRIX_AJOUTER_DEUX_BILLETS));
    }

    /// <summary>
    /// Vérifie le tirage de billet séquence
    /// (Crée un billet et vérifie que ce billet est bien de type séquence)
    /// </summary>
    [Test]
    public void LancerTirage_CreeBilletSequence()
    {
        loterie.LancerTirageSequence();
        Assert.That(loterie.BilletTire, Is.Not.Null);
        Assert.That(loterie.BilletTire, Is.InstanceOf<BilletSequence>());
    }

    /// <summary>
    /// Vérifie le tirage de billet combinaison
    /// Crée un billet et vérifie que ce billet est bien de type combinaison)
    /// </summary>
    [Test]
    public void LancerTirageCombinaison_CreeBilletCombinaison()
    {
        var billet = new BilletCombinaison();
        loterie.AjouterBilletListe(billet);
        loterie.LancerTirageCombinaison();
        Assert.That(loterie.BilletTire, Is.Not.Null);
        Assert.That(loterie.BilletTire, Is.InstanceOf<BilletCombinaison>());
    }

    /// <summary>
    /// Vérifie que le calcul des gains se fait correctement
    /// Les billets testables retournent toujours 0 comme gain -- donc gain = 0
    /// </summary>
    [Test]
    public void CalculeGain_SommeCorrectementLesGains()
    {
        loterie.AjouterBilletListe(new BilletTestable());
        loterie.AjouterBilletListe(new BilletTestable());
        loterie.LancerTirageSequence();
        loterie.CalculeGain();
        Assert.That(loterie.Gain, Is.EqualTo(0));
    }

    /// <summary>
    /// Vérifie que le gain n’est pas additionné plusieurs fois
    /// quand celle-ci est appelée plusieurs fois
    /// </summary>
    [Test]
    public void CalculeGain_DeuxAppels_NeDoublePasGain()
    {
        loterie.AjouterBilletListe(new BilletTestable());
        loterie.LancerTirageSequence(); // OBLIGATOIRE
        loterie.CalculeGain();
        double premierGain = loterie.Gain;
        loterie.CalculeGain();
        Assert.That(loterie.Gain, Is.EqualTo(premierGain));
    }

    /// <summary>
    /// Vérifie que la méthode CalculeGain lance une exception
    /// quand aucun tirage n’a été effectué au préalable
    /// </summary>
    [Test]
    public void CalculeGain_SansTirage_LanceException()
    {
        loterie.AjouterBilletListe(new BilletTestable());
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => loterie.CalculeGain());
        Assert.That(exception!.Message, Is.EqualTo("Le tirage n'a pas été lancé."));
    }
}