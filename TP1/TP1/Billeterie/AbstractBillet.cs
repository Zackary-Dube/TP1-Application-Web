namespace TP1.Billeterie;

public abstract class AbstractBillet
{
    private static int idUtilise;
    public const int NOMBRE_NUMERO_BILLET = 6;
    /// <summary>
    /// Billet de lotterie avec un numero
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Prix du billet (2$)
    /// </summary>
    public const int PRIX_BILLETS = 2;
    
    public int Gain { get; set; }

    public AbstractBillet()
    {
        Id = idUtilise++;
    }
    
    
    
    
    
    
}