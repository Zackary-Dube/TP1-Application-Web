using System;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using TP1.Options;

namespace TP1.Billeterie;

public class Loterie
{
    private List<AbstractBillet> _listeBillets = new();
    
    public AbstractBillet BilletTire { get; set; }
    public double Gain { get; set; }
    public double Revenu {get; set;}
    
    public void AjouterBilletListe(AbstractBillet billet)
    {
        _listeBillets.Add(billet);
        Revenu += AbstractBillet.PRIX_BILLETS;
    } 
    
    public void LancerTirage()
    {
        AbstractBillet billetTire = new BilletSequence();
        BilletTire =  billetTire;
    }

    public void CalculeGain()
    {
        foreach (AbstractBillet billet in _listeBillets)
        {
            Gain += billet.CalculerGainSiGagnant(BilletTire);
        }
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    /// <summary>
    /// Mise en place de la variable du numero gagnant
    /// </summary>
    private int numeroGagnant = -1;
    
    /// <summary>
    /// Lancement du tirage et appliquer la valeur du numero gagnant a la variable numero gagnant
    /// </summary>
    /// <param name="numero">donne le numero gagnant</param>
    

 

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


    /// <summary>
    /// pour avoir le gain des billets
    /// </summary>
    /// <returns>le gain de tout les billets</returns>

}