/* Zackary Dubé */
using TP1;
using TP1.Billeterie;
using TP1.ChainOfResponsibility;
using TP1.Options;

namespace TestTP1.ChainOfResponsibility;

/// <summary>
/// Classe de tests unitaires pour la classe LancerTirageHandler
/// </summary>
public class LancerTirageHandlerTest
{
    /// <summary>
    /// Instance du handler responsable du tirage d'un billet
    /// </summary>
    private LancerTirageHandler handler;
    
    /// <summary>
    /// Instance de Loterie
    /// </summary>
    private Loterie loterie;

    /// <summary>
    /// Initialise une nouvelle instance de LancerTirageHandler et Loterie
    /// </summary>
    [SetUp]
    public void Setup()
    {
        handler = new LancerTirageHandler();
        loterie = new Loterie();
    }

    /// <summary>
    /// Vérifie que le handler lance correctement le tirage
    /// lorsque le type de billet est Séquence
    /// Le billet doit etre creer et doit etre de type sequence
    /// </summary>
    [Test]
    public void Handle_TypeSequence_LanceTirageSequence()
    {
        Dictionary<string, object> dictionnaire = new Dictionary<string, object>
        {
            { "billetType", TypeBillet.Sequence },
            { "loterie", loterie }
        };
        handler.Handle(dictionnaire);
        Assert.That(loterie.BilletTire, Is.Not.Null);
        Assert.That(loterie.BilletTire, Is.InstanceOf<BilletSequence>());
    }
}