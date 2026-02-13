namespace TP1;

public class BilletCombinaison
{
    private List<int> _numeros = new List<int>();
    
    private static Random random = new Random();
    private static int numeroMax = 50;
    
    public List<int> Numeros { get => _numeros; set => _numeros = value; }

    public BilletCombinaison()
    {
        
    }

    public BilletCombinaison(List<int> numeros)
    {
        Numeros = numeros;
    }

    public void GenererNumeros()
    {
        while (Numeros.Count < 6)
        {
            int numero = random.Next(1, numeroMax);
            if (!Numeros.Contains(numero))
            {
                Numeros.Add(numero);
            }
        }
    }

    public int ComparerBillets(BilletCombinaison tirage, BilletCombinaison client)
    {
        int compteur = 0;
        foreach (int numero in client.Numeros)
        {
            if (tirage.Numeros.Contains(numero))
            {
                compteur++;
            }
        }
        return compteur;
    }
}