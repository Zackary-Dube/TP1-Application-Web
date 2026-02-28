/* Zackary Dubé */
using TP1;
using TP1.Billeterie;
using TP1.ChainOfResponsibility;
using TP1.Options;

namespace TestTP1.ChainOfResponsibility;

/// <summary>
/// Classe de tests unitaires pour la classe AcheterBilletHandler
/// </summary>
public class AcheterBilletHandlerTest
{
    /// <summary>
    /// Nombre de billets vendus utilisé pour les tests (3)
    /// </summary>
    private const int TROIS_BILLETS_VENDUS = 3;
    
    /// <summary>
    /// Nombre de billets vendus utilisé pour les tests (2)
    /// </summary>
    private const int DEUX_BILLETS_VENDUS = 2;
    
    /// <summary>
    /// Instance du handler responsable de l'achat d'un billet
    /// </summary>
    private AcheterBilletHandler handler;
    
    /// <summary>
    /// Instance de Loterie
    /// </summary>
    private Loterie loterie;

    /// <summary>
    /// Initialise une nouvelle instance de AcheterBilletHandler et Loterie
    /// </summary>
    [SetUp]
    public void Setup()
    {
        handler = new AcheterBilletHandler();
        loterie = new Loterie();
    }

    /// <summary>
    /// Vérifie que le handler ajoute le bon nombre de billets lorsque celui-ci est de type séquence
    /// Le revenu de la loterie doit correspondre au nombre de billets multiplié par le prix d’un billet
    /// </summary>
    [Test]
    public void Handle_TypeSequence_AjouteBonNombreDeBillets()
    {
        Dictionary<string, object> dictionnaire = new Dictionary<string, object>
        {
            { "billetType", TypeBillet.Sequence },
            { "nombreBilletVendu", TROIS_BILLETS_VENDUS },
            { "loterie", loterie }
        };
        handler.Handle(dictionnaire);
        Assert.That(loterie.Revenu, Is.EqualTo(TROIS_BILLETS_VENDUS * new BilletSequence().PRIX_BILLETS));
    }

    /// <summary>
    /// Vérifie que le handler ajoute le bon nombre de billets lorsque celui-ci est de type combinaison
    /// Le revenu de la loterie doit correspondre au nombre de billets multiplié par le prix d’un billet
    /// </summary>
    [Test]
    public void Handle_TypeCombinaison_AjouteBonNombreDeBillets()
    {
        Dictionary<string, object> dictionnaire = new Dictionary<string, object>
        {
            { "billetType", TypeBillet.Combinaison },
            { "nombreBilletVendu", DEUX_BILLETS_VENDUS },
            { "loterie", loterie }
        };
        handler.Handle(dictionnaire);
        Assert.That(loterie.Revenu, Is.EqualTo(DEUX_BILLETS_VENDUS * new BilletCombinaison().PRIX_BILLETS));
    }

    /// <summary>
    /// Vérifie la limite lorsque aucun billet n’est acheté
    /// (Le revenu de la loterie doit donc être égal à zéro)
    /// </summary>
    [Test]
    public void Handle_NombreZero_AjouteAucunBillet()
    {
        Dictionary<string, object> dictionnaire = new Dictionary<string, object>
        {
            { "billetType", TypeBillet.Sequence },
            { "nombreBilletVendu", 0 },
            { "loterie", loterie }
        };
        handler.Handle(dictionnaire);
        Assert.That(loterie.Revenu, Is.EqualTo(0));
    }
}