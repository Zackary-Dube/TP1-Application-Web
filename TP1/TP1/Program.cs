using TP1.Billeterie;
using TP1.ChainOfResponsibility;
using TP1.Options;

namespace TP1;

class Program
{
    static void Main(string[] args)
    {
        ScenarioSequence();
        
    }
    
    /* Zackary Dubé */
    /// <summary>
    /// Représente un scénario complet avec un billet séquence et 10000 billets vendus
    /// </summary>
    static void ScenarioSequence()
    {
        Loterie loterie = new Loterie();
        Dictionary<string, object> dictionaire = new Dictionary<string, object>();
        dictionaire.Add("billetType", TypeBillet.Sequence);
        dictionaire.Add("loterie", loterie);
        dictionaire.Add("nombreBilletVendu", 10000);
        IHandler chainHandler = new AcheterBilletHandler();
        chainHandler.Next(new LancerTirageHandler())
            .Next(new VoirGainsHandler());
        chainHandler.Handle(dictionaire);
        Console.WriteLine("Revenu des vente de billets : " + ((Loterie) dictionaire["loterie"]).Revenu);
        Console.WriteLine("Gain donner pour les prix : " + ((Loterie) dictionaire["loterie"]).Gain);
        Console.WriteLine("Profit : " + ((((Loterie) dictionaire["loterie"]).Revenu) - (((Loterie) dictionaire["loterie"]).Gain)));
    }
    
    /// <summary>
    /// Représente un scénario complet qui simule une loterie avec 100 billets vendus
    /// </summary>
    static void ScenarioCombinaison()
    {
        Console.WriteLine("Scénario billet combinaison.");
        
        // Parametres intéractifs.
        String nbBilletVendu = "0";
        Console.Write("Entrez le nombre de billets vendus : ");
        nbBilletVendu = Console.ReadLine();
        
        Console.WriteLine("Entrez les numéros de votre billet de référence (6 numéros séparés par des espaces) : ");
        int[] numerosUtilisateur = null;
        while (numerosUtilisateur == null || numerosUtilisateur.Length != 6)
        {
            string line = Console.ReadLine();
            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 6)
            {
                Console.WriteLine("Erreur : vous devez entrer exactement 6 numéros.");
                continue;
            }

            numerosUtilisateur = new int[6];
            bool valide = true;
            for (int i = 0; i < 6; i++)
            {
                if (!int.TryParse(parts[i], out numerosUtilisateur[i]) || numerosUtilisateur[i] < 1)
                {
                    Console.WriteLine($"Erreur : '{parts[i]}' n'est pas un numéro valide (entier positif).");
                    valide = false;
                    break;
                }
            }
            if (!valide)
                numerosUtilisateur = null;
        }

        // Définition des parametres du scénarios.
        Loterie loterie = new Loterie();
        Dictionary<string, object> dictionaire = new Dictionary<string, object>();
        
        // Ajout de la loterie avec 100 billets vendus.
        dictionaire.Add("loterie", loterie);
        dictionaire.Add("nombreBilletVendu", nbBilletVendu);
        
        // Billet de référence.
        AbstractBillet billetUtilisateur = new BilletCombinaison();
        billetUtilisateur.ListeNumero = numerosUtilisateur.ToList();
        loterie.LancerTirageCombinaison();
        
        TP1.Statistiques.Statistiques stats = new TP1.Statistiques.Statistiques(new List<AbstractBillet> { billetUtilisateur }, loterie.BilletTire);
        dictionaire.Add("statistiques", stats);
        
        IHandler chainHandler = new AcheterBilletHandler();

        chainHandler.Next(new LancerTirageHandler())
            .Next(new AfficherStatistiquesHandler());

        chainHandler.Handle(dictionaire);
        
        Console.WriteLine($"Billet utilisateur : {string.Join(",", billetUtilisateur.ListeNumero)}");
        Console.WriteLine($"Gain utilisateur : {billetUtilisateur.CalculerGainSiGagnant(loterie.BilletTire)}$");
    }
}