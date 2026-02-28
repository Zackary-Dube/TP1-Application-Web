/* Zackary Dubé */
using TP1;
using TP1.Billeterie;
using TP1.ChainOfResponsibility;
using TP1.Options;

namespace TestTP1.ChainOfResponsibility;

/// <summary>
/// Classe de tests unitaires pour la classe VoirGainsHandler
/// </summary>
public class VoirGainsHandlerTest
{
    /// <summary>
    /// Instance du handler responsable de calculer les gains
    /// </summary>
    private VoirGainsHandler handler;
    
    /// <summary>
    /// Instance de Loterie
    /// </summary>
    private Loterie loterie;
    
    /// <summary>
    /// Initialise une nouvelle instance de VoirGainsHandler et Loterie
    /// </summary>
    [SetUp]
    public void Setup()
    {
        handler = new VoirGainsHandler();
        loterie = new Loterie();
    }

    /// <summary>
    /// Vérifie que le handler enclenche le calcul des gains
    /// quand le type de billet est Séquence.
    /// </summary>
    [Test]
    public void Handle_TypeSequence_CalculeGain()
    {
        loterie.AjouterBilletListe(new BilletSequence());
        loterie.LancerTirageSequence();
        Dictionary<string, object> dictionnaire = new Dictionary<string, object>
        {
            { "billetType", TypeBillet.Sequence },
            { "loterie", loterie }
        };
        handler.Handle(dictionnaire);
        Assert.That(loterie.Gain, Is.GreaterThanOrEqualTo(0));
    }
}