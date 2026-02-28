/* Zackary Dubé */
using System;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using TP1.Options;

namespace TP1.Billeterie;

/// <summary>
/// Permet de gérer les billets achetés, d’effectuer un tirage, de calculer les gains et le revenu total
/// </summary>
public class Loterie
{
    /// <summary>
    /// Liste des billets achetés pour la loterie
    /// </summary>
    private List<AbstractBillet> _listeBillets = new();
    
    /// <summary>
    /// Billet tiré lors du tirage de la loterie
    /// </summary>
    public AbstractBillet BilletTire { get; set; }
    
    /// <summary>
    /// Gain total obtenu par l’ensemble des billets
    /// </summary>
    public double Gain { get; set; }
    
    /// <summary>
    /// Revenu total généré par la vente des billets
    /// </summary>
    public double Revenu {get; set;}
    
    /// <summary>
    /// Ajoute un billet à la liste des billets achetés et actualise le revenu de la loterie
    /// </summary>
    /// <param name="billet">Le billet à ajouter à la loterie</param>
    public void AjouterBilletListe(AbstractBillet billet)
    {
        _listeBillets.Add(billet);
        Revenu += billet.PRIX_BILLETS;
    } 
    
    /// <summary>
    /// Lance le tirage de la loterie en générant un billet tiré
    /// </summary>
    public void LancerTirageSequence()
    {
        AbstractBillet billetTire = new BilletSequence();
        BilletTire = billetTire;
    }
    
    /// <summary>
    /// Lance le tirage de la loterie en générant un billet tiré
    /// </summary>
    public void LancerTirageCombinaison()
    {
        AbstractBillet billetTire = new BilletCombinaison();
        BilletTire = billetTire;
    }

    /// <summary>
    /// Calcule le gain total de la loterie en évaluant chaque billet par rapport au billet tiré
    /// </summary>
    public void CalculeGain()
    {
        if (BilletTire == null)
            throw new InvalidOperationException("Le tirage n'a pas été lancé.");
        Gain = 0;
        foreach (AbstractBillet billet in _listeBillets)
        {
            Gain += billet.CalculerGainSiGagnant(BilletTire);
        }
    }
}