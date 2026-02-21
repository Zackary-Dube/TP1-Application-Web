namespace TP1.Billeterie;

public abstract class AbstractBillet
{
    public const int PRIX_BILLETS = 2;
    public const int NOMBRE_NUMERO_BILLET = 6;
    public const int NOMBRE_NUMERO_MAX = 100;
    
    public List<int> ListeNumero { get; set; }
    
    private static int idUtilise;
    
    public int Id { get; set; }
    
    public double Gain { get; set; } // (A verifier si vraiment necessaire) (Deja utiliser dans la class loterie)
    
    public AbstractBillet()
    {
        Id = idUtilise++;
        ListeNumero = new List<int>();
    }

    public abstract double CalculerGainSiGagnant(AbstractBillet billetTire);





}