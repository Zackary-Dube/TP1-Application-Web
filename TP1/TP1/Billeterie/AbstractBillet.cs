/* Zackary Dubé */
namespace TP1.Billeterie;

/// <summary>
/// Represente un billet de loterie abstrait.
/// Classe de base pour tous les type de billets (sequence et combinaison).
/// </summary>
public abstract class AbstractBillet
{
    /// <summary>
    /// Prix du billet
    /// </summary>
    public abstract int PRIX_BILLETS { get; }
    
    /// <summary>
    /// Nombre de numéros qu’un billet doit contenir
    /// </summary>
    public const int NOMBRE_NUMERO_BILLET = 6;
    
    /// <summary>
    /// Valeur maximale possible pour un numéro de billet
    /// </summary>
    public const int NOMBRE_NUMERO_MAX = 100;
    
    /// <summary>
    /// Liste des numéros associés au billet
    /// </summary>
    public List<int> ListeNumero { get; set; }
    
    /// <summary>
    /// Compteur utilisé pour générer des billets uniques
    /// </summary>
    private static int idUtilise;
    
    /// <summary>
    /// Identifiant unique du billet
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// **** (À vérifier si vraiment nécessaire) (Déjà utilisé dans la classe loterie) ****
    /// </summary>
    public double Gain { get; set; } // 
    
    /// <summary>
    /// Initialise un nouveau billet en attribuant un identifiant unique et initialise la liste de numéros
    /// </summary>
    public AbstractBillet()
    {
        Id = idUtilise++;
        ListeNumero = new List<int>();
    }

    /// <summary>
    /// Calcule le gain du billet si celui-ci est gagnant en fonction du billet tiré
    /// </summary>
    /// <param name="billetTire">Billet tiré lors du tirage de la loterie</param>
    /// <returns>Montant du gain obtenu par le billet (retourne 0 si le billet n’est pas gagnant)</returns>
    public abstract double CalculerGainSiGagnant(AbstractBillet billetTire);
    
    public virtual int CalculerNombreNumerosGagnants(AbstractBillet billetTire)
    {
        return 0;
    }
}