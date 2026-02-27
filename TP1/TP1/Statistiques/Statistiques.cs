namespace TP1.Statistiques;
using TP1.Billeterie;

/// <summary>
/// Permet de gerer la partie statistique du programme de loterie.
/// </summary>
public class Statistiques
{
    /// <summary>
    /// Liste des billets vendus.
    /// </summary>
    private readonly List<AbstractBillet> _billetsVendus;
    
    /// <summary>
    /// Représente le billet tiré par la loterie.
    /// </summary>
    private AbstractBillet _billetTire;

    public AbstractBillet BilletTire { get => _billetTire; set => _billetTire = value; }


    // Montants globaux
    public double MontantTotalDepense { get; private set; }
    public double MontantTotalGagne { get; private set; }

    // Somme des gains par nombre de numéros gagnants
    private readonly Dictionary<int, double> _montantParNombreGagnant = new();

    // Somme dépensée par type de billet
    private readonly Dictionary<string, double> _depenseParType = new();

    /// <summary>
    /// Initialise la liste de billets vendus ainsi que le billet tiré.
    /// </summary>
    /// <param name="billetsVendus">Représente la liste de billets vendus</param>
    /// <param name="billetTire">Représente le billet tiré par la loterie</param>
    public Statistiques(List<AbstractBillet> billetsVendus, AbstractBillet billetTire)
    {
        _billetsVendus = billetsVendus;
        _billetTire = billetTire;
    }

    /// <summary>
    /// Effectue tous les calculs des statistiques.
    /// </summary>
    public void CalculerStatistiques()
    {
        MontantTotalDepense = 0;
        MontantTotalGagne = 0;
        _montantParNombreGagnant.Clear();
        _depenseParType.Clear();
        
        foreach (AbstractBillet billet in _billetsVendus)
        {
            MontantTotalDepense += billet.PRIX_BILLETS;

            string typeBillet = billet.GetType().Name;

            if (!_depenseParType.ContainsKey(typeBillet))
                _depenseParType[typeBillet] = 0;

            _depenseParType[typeBillet] += billet.PRIX_BILLETS;
            
            int nbNumerosGagnants = billet.CalculerNombreNumerosGagnants(_billetTire);
            double gain = billet.CalculerGainSiGagnant(_billetTire);

            MontantTotalGagne += gain;
            
            if (gain > 0)
            {
                if (!_montantParNombreGagnant.ContainsKey(nbNumerosGagnants))
                    _montantParNombreGagnant[nbNumerosGagnants] = 0;

                _montantParNombreGagnant[nbNumerosGagnants] += gain;
            }
        }
    }

    /// <summary>
    /// Affiche les statistiques de notre loterie
    /// </summary>
    public void AfficherStatistiques()
    {
        Console.WriteLine("===== STATISTIQUES =====\n");

        Console.WriteLine($"Montant total dépensé : {MontantTotalDepense}$");
        Console.WriteLine($"Montant total gagné : {MontantTotalGagne}$");
        Console.WriteLine($"Profit de la loterie : {MontantTotalDepense - MontantTotalGagne}$");

        Console.WriteLine("\n--- Montant total par nombre de numéros gagnants ---");

        foreach (var kvp in _montantParNombreGagnant.OrderBy(k => k.Key))
        {
            Console.WriteLine($"{kvp.Key} numéros gagnants : {kvp.Value}$");
        }

        Console.WriteLine("\n--- Montant total dépensé par type de billet ---");

        foreach (var kvp in _depenseParType)
        {
            Console.WriteLine($"{kvp.Key} : {kvp.Value}$");
        }

        Console.WriteLine("\n=========================");
    }
}