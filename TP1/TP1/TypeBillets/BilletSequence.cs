using System.Collections.Generic;
using TP1.Billeterie;

namespace TP1;

public class BilletSequence : AbstractBillet
{
    public int[] TABLEAU_PRIX = {0, 0, 0, 30, 40, 50, 60};
    public BilletSequence()
    {
        TrouveNumeroBilletAutomatique();
    }
    
    public BilletSequence(List<int> listeNumero)
    {
        ListeNumero = listeNumero;
    }
    
    public void TrouveNumeroBilletAutomatique()
    {
        Random random = new Random();
        for (int i = 0; i < NOMBRE_NUMERO_BILLET; i++)
        {
            ListeNumero.Add(random.Next(NOMBRE_NUMERO_MAX));
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
    
    
}