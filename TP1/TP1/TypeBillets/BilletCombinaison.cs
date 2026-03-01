using System;
using System.Collections.Generic;
using TP1.Billeterie;

namespace TP1;

/// <summary>
/// Représente un billet de type combinaison
/// Ce billet est gagnant si un ou plusieurs chiffres correspondent au billet tiré
/// </summary>
public class BilletCombinaison : AbstractBillet
{
    /// <summary>
    /// Liste des numéros du billet
    /// </summary>
    private List<int> _numeros = new List<int>();
    
    /// <summary>
    /// Prix du billet
    /// </summary>
    public override int PRIX_BILLETS => 5;
    
    /// <summary>
    /// Variable aléatoire pour générer les numéros du billet
    /// </summary>
    private static Random random = new Random();
    
    public List<int> Numeros { get => _numeros; set => _numeros = value; }

    /// <summary>
    /// Initialise un nouveau billet combinaison avec des numéros aléatoires.
    /// </summary>
    public BilletCombinaison()
    {
        ListeNumero = new List<int>();
        GenererNumeros();
    }

    /// <summary>
    /// Initialise un nouveau billet combinaison avec des numéros prédéfinis.
    /// </summary>
    /// <param name="numeros">Représente la liste de numéros du billet</param>
    public BilletCombinaison(List<int> numeros)
    {
        ListeNumero = numeros;
    }

    /// <summary>
    /// Genere 6 numéros aléatoire unique.
    /// </summary>
    public void GenererNumeros()
    {
        while (ListeNumero.Count < 6)
        {
            int numero = random.Next(1, NOMBRE_NUMERO_MAX);
            if (!ListeNumero.Contains(numero))
            {
                ListeNumero.Add(numero);
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
        foreach (int numero in client.ListeNumero)
        {
            if (tirage.ListeNumero.Contains(numero))
            {
                compteur++;
            }
        }
        return compteur;
    }
    
    /// <summary>
    /// Calcule le nombre de numéros gagnants par billet.
    /// </summary>
    /// <param name="billetTire"></param>
    /// <returns>Retourne le nombre de numéros gagnants</returns>
    public override int CalculerNombreNumerosGagnants(AbstractBillet billetTire)
    {
        if (billetTire is not BilletCombinaison)
            return 0;

        int compteur = 0;

        foreach (int numero in ListeNumero)
        {
            if (billetTire.ListeNumero.Contains(numero))
                compteur++;
        }

        return compteur;
    }
    
    /// <summary>
    /// Compare le billet du client avec le billet tiré par la loterie et détermine le montant gagné.
    /// </summary>
    /// <param name="billetTire">Correspond au billet tiré</param>
    /// <returns>Retourne le gain du billet en $</returns>
    public override double CalculerGainSiGagnant(AbstractBillet billetTire)
    {
        if (billetTire is not BilletCombinaison)
            return 0;

        int nb = CalculerNombreNumerosGagnants(billetTire);

        return nb switch
        {
            3 => 5,
            4 => 20,
            5 => 100,
            6 => 1000,
            _ => 0
        };
    }

}