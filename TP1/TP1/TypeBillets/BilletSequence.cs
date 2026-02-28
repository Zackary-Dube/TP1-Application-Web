/* Zackary Dubé */
using TP1.Billeterie;

namespace TP1;

/// <summary>
/// Représente un billet de type séquence
/// Ce type de billet est gagnant lorsqu’une ou plusieurs séquences consécutives (au moins 3) correspondent au billet tiré
/// </summary>
public class BilletSequence : AbstractBillet
{
    public override int PRIX_BILLETS => 10;
    
    /// <summary>
    /// Tableau des prix associés au nombre de numéros gagnants consécutifs
    /// L’index représente le nombre de numéros gagnants et donc le prix associé
    /// (0) -> 0$; (1) -> 0$; (2) -> 0$; (3) -> 300$; (4) -> 1000$; (5) -> 20000$; (6) -> 1000000$;
    /// </summary>
    public int[] TABLEAU_PRIX = {0, 0, 0, 300, 1000, 20000, 1000000};

    /// <summary>
    /// Initialise un nouveau billet de type séquence
    /// Génère automatiquement ses numéros
    /// </summary>
    public BilletSequence()
    {
        TrouveNumeroBilletAutomatique();
    }
    
    /// <summary>
    /// Initialise un nouveau billet de type séquence avec une liste de numéros prédéfinie
    /// </summary>
    /// <param name="listeNumero">Liste des numéros du billet</param>
    public BilletSequence(List<int> listeNumero)
    {
        if (listeNumero == null)
            throw new ArgumentNullException(nameof(listeNumero));
        
        if (listeNumero.Count != NOMBRE_NUMERO_BILLET)
            throw new ArgumentException($"Le billet doit contenir exactement {NOMBRE_NUMERO_BILLET} numéros.", nameof(listeNumero));
        
        for (int i = 0; i < listeNumero.Count; i++)
            if (listeNumero[i] > NOMBRE_NUMERO_MAX || listeNumero[i] < 1)
                throw new ArgumentOutOfRangeException(nameof(listeNumero), $"Le numéro à l’index {i} ({listeNumero[i]}) doit être entre 1 et {NOMBRE_NUMERO_MAX}.");            
        
        ListeNumero = listeNumero;
    }
    
    /// <summary>
    /// Génère automatiquement les numéros du billet de manière aléatoire
    /// </summary>
    public void TrouveNumeroBilletAutomatique()
    {
        Random random = new Random();
        for (int i = 0; i < NOMBRE_NUMERO_BILLET; i++)
        {
            ListeNumero.Add(random.Next(NOMBRE_NUMERO_MAX));
        }
    }
    
    /// <summary>
    /// Calcule le gain du billet s’il est gagnant en comparant ses séquences avec le billet tiré
    /// </summary>
    /// <param name="billetTire">Billet tiré lors du tirage de la loterie</param>
    /// <returns>Montant du gain obtenu par le billet (retourne 0 si le billet n’est pas gagnant)</returns>
    public override double CalculerGainSiGagnant(AbstractBillet billetTire)
    {
        List<string> combinaisons = GenererCombinaisons(billetTire.ListeNumero);
        return CalculerGainMax(CombinaisonBillet(), combinaisons);
        
    }

    /// <summary>
    /// Génère toutes les combinaisons possibles de séquences à partir de la liste de numéros fournie
    /// </summary>
    /// <param name="numeros">Liste des numéros du billet tiré</param>
    /// <returns>Liste des combinaisons de séquences sous forme de chaînes</returns>
    private List<string> GenererCombinaisons(List<int> numeros)
    {
        List<string> resultats = new List<string>();
        for (int i = 0; i < numeros.Count; i++)
        {
            resultats.AddRange(GenererSequenceDepuis(numeros, i));
        }
        return resultats;
    }

    /// <summary>
    /// Génère les séquences possibles à partir d’une position donnée
    /// </summary>
    /// <param name="numeros">Liste des numéros du billet tiré</param>
    /// <param name="start">Position de départ de la séquence</param>
    /// <returns>Liste des séquences générées</returns>
    private List<string> GenererSequenceDepuis(List<int> numeros, int start)
    {
        List<string> resultats = new List<string>();
        for (int len = numeros.Count - start; len >= 3; len--)
        {
            resultats.Add(string.Join(" ", numeros.Skip(start).Take(len)));
        }
        return resultats;
    }

    /// <summary>
    /// Calcule le gain maximal obtenu parmi toutes les combinaisons gagnantes
    /// </summary>
    /// <param name="billet">Chaîne de caractères du billet courant</param>
    /// <param name="combinaisons">Liste des combinaisons gagnantes possibles</param>
    /// <returns>Gain maximal obtenu</returns>
    private double CalculerGainMax(string billet, List<string> combinaisons)
    {
        double gain = 0;
        foreach (string c in combinaisons)
        {
            gain = Math.Max(gain, GainPourCombinaison(billet, c));
        }

        return gain;
    }

    /// <summary>
    /// Détermine le gain associé à une combinaison spécifiqu
    /// </summary>
    /// <param name="billet">Chaîne de caractères du billet courant</param>
    /// <param name="combinaison">Combinaison de numéros à vérifier</param>
    /// <returns>Montant du gain pour la combinaison (retourne 0 si la combinaison n’est pas gagnante)</returns>
    private double GainPourCombinaison(string billet, string combinaison)
    {
        if (!billet.Contains(combinaison)) return 0;
        return TABLEAU_PRIX[combinaison.Split(' ').Length];
    }

    /// <summary>
    /// Retourne la combinaison complète du billet courant sous forme de chaîne de caractères
    /// </summary>
    /// <returns>Chaîne représentant les numéros du billet</returns>
    private string CombinaisonBillet()
    {
        return string.Join(" ", ListeNumero);
    }
    
    
}

/*
 --- Liste des combinaisons gagnante possible ---
   1 2 3 4 5 6
   1 2 3 4 5
   1 2 3 4
   1 2 3
     2 3 4 5 6
     2 3 4 5
     2 3 4
       3 4 5 6
       3 4 5
         4 5 6

    public override double CalculerGainSiGagnant(AbstractBillet billetTire)
    {
        List<string> listeCombinaisonGagnants = new List<string>();
        string combinaisonBillet;
        List<int> listeNumeroBilletTire = billetTire.ListeNumero;
        double gain = 0;
        int n = listeNumeroBilletTire.Count;

//      Commencement position depart
        for (int start = 0; start < n; start++)
        {
//          Longueur de la sequence (6,5,4,3)
            for (int len = n - start; len >= 3; len--)
            {
//              Construire a partir de numero[start.. start+len-1]
                List<int> seq = new List<int>();
                for (int k = 0; k < len; k++)
                {
                    seq.Add(listeNumeroBilletTire[start + k]);
                }
                string t = string.Join(" ", seq);
                listeCombinaisonGagnants.Add(t);
            }
        }
        combinaisonBillet = string.Join(" ", ListeNumero);
        foreach (string l in listeCombinaisonGagnants)
        {
            if (combinaisonBillet.Contains(l))
            {
                int nombreNumeroGagnant = 0;
                foreach (char var in l)
                {
                    if (var == ' ')
                    {
                        nombreNumeroGagnant++;
                    }
                }
                if (gain < TABLEAU_PRIX[nombreNumeroGagnant + 1])
                {
                    gain = TABLEAU_PRIX[nombreNumeroGagnant + 1];
                }
            }
        }
        return gain;
    }

    */