using System;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using TP1.Options;

namespace TP1.Billeterie;

public class Loterie
{
    /// <summary>
    /// Liste de tout les billets
    /// </summary>
    private List<AbstractBillet> billets = new();
    
    /// <summary>
    /// Mise en place de la variable du numero gagnant
    /// </summary>
    private int numeroGagnant = -1;
    
    
    
    /// <summary>
    /// Lancement du tirage et appliquer la valeur du numero gagnant a la variable numero gagnant
    /// </summary>
    /// <param name="numero">donne le numero gagnant</param>
    public void LancerTirage(int numero)
    {
        numeroGagnant = numero;
        Console.WriteLine($"Numero gagnant : {numeroGagnant}");
    }

    public void AjouterBillet(AbstractBillet abstractBillet)
    {
        billets.Add(abstractBillet);
    }

    /// <summary>
    /// Dit si le billet est gagnant
    /// </summary>
    /// <param name="abstractBillet">un billet en parametre</param>
    /// <returns>un oui ou non si le numero est gagnant</returns>
    public bool EstGagnant(AbstractBillet abstractBillet)
    {
        return abstractBillet.Id == numeroGagnant;
    }

    /// <summary>
    /// pour avoir le nombre de billets vendus
    /// </summary>
    /// <returns>nombre de billets vendus en tout</returns>
    public int NombreBilletVendus()
    {
        return billets.Count;
    }

    /// <summary>
    /// pour avoir le gain des billets
    /// </summary>
    /// <returns>le gain de tout les billets</returns>
    public int GainTotaux()
    {
        return billets.Count * AbstractBillet.PRIX_BILLETS;
    }
}