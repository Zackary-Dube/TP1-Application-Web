using System;
using System.Collections.Generic;
using TP1.Billeterie;

namespace TP1;

/// <summary>
/// Représente un billet de type combinaison
/// </summary>
public class BilletCombinaison : AbstractBillet
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

    /// <summary>
    /// Genere 6 numéros aléatoire unique.
    /// </summary>
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

    /// <summary>
    /// Compare le billet du client et le billet du tirage.
    /// </summary>
    /// <param name="tirage">Billet du tirage</param>
    /// <param name="client">Billet du client</param>
    /// <returns>Le nombre de numéro gagnant</returns>
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

    /// <summary>
    /// Calcule les gains du client
    /// </summary>
    /// <param name="tirage">Billet du tirage</param>
    /// <param name="client">Billet du client</param>
    public void CalculerGain(BilletCombinaison tirage, BilletCombinaison client)
    {
        Gain = ComparerBillets(tirage, client) switch
        {
            3 => 5,
            4 => 20,
            5 => 100,
            6 => 1000,
            _ => 0
        };
    }

//  Important pour mes tests (Zackary)
    public override double CalculerGainSiGagnant(AbstractBillet billetTire)
    {
        return 0;
    }

}