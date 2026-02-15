using System.Collections.Generic;
using TP1.Billeterie;

namespace TP1;

public class BilletSequence : AbstractBillet
{
    public List<int> ListeNumero { get; set; }
    public BilletSequence()
    {
        ListeNumero = new List<int>();
    }
    
    /// <summary>
    /// Genere un numero du ticket automatiquement
    /// </summary>
    /// <param name="valeurMaximumSimpleNumero">valeur maximum qu'un numero du numero peut avoir</param>
    /// <returns>liste de numero du billet</returns>
    public void TrouveNumeroBilletAutomatique(int valeurMaximumSimpleNumero)
    {
        Random random = new Random();
        for (int i = 0; i < NOMBRE_NUMERO_BILLET; i++)
        {
            ListeNumero.Add(random.Next(valeurMaximumSimpleNumero));
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
*/
    
    
    void verifierSiGagnant(BilletSequence billetTire)
    {
        List<string> listeCombinaisonGagnants = new List<string>();
        List<int> listeNumeroBilletTire = billetTire.ListeNumero;

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
                Console.WriteLine(t);
                listeCombinaisonGagnants.Add(t);
            }
        }
        string listeNumeroBillet = string.Join("", ListeNumero);
        foreach (string s in listeCombinaisonGagnants)
        {
            
            if (listeNumeroBillet.Contains(s))
            {
                Console.WriteLine(s);
            }
        }
        
        
    }
    
    
}