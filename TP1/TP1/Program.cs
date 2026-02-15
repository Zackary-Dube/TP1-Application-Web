using System;
using System.Collections.Generic;
using System.Diagnostics;
using TP1.Billeterie;
using TP1.ChainOfResponsibility;
using TP1.Options;

namespace TP1;

public enum TypeBillet
{
    Combinaison,
    Sequence
}

class Program
{
    static void Main(string[] args)
    {

//      Programmation du dictionnaire

/*
Les configurations :
o Valeur max à considérer
o Le nombre de tirage à faire
o Le type de billets tirés
• Le tableau des numéros tirés
• Le(s) billet(s) de référence de(s) (l')utilisateur(s)
• Les montants gagnés
*/
        Loterie loterie = new Loterie();
        Dictionary<string, object> dictionaire = new Dictionary<string, object>();
        List<double> montantGagne = new List<double>();
        List<AbstractBillet> Listebillets = new List<AbstractBillet>();
        AbstractBillet billetsTire = new BilletSequence();

        dictionaire.Add("billetType", TypeBillet.Sequence);
        dictionaire.Add("nombreBilletVendu", 100);
        dictionaire.Add("nombreTirageAFaire", 10);
        dictionaire.Add("listeMontantGagne", montantGagne);
        dictionaire.Add("listeBillets", Listebillets);
        dictionaire.Add("billetsTire", billetsTire);
        dictionaire.Add("loterie", loterie);
        dictionaire.Add("message", "message");
        dictionaire.Add("ValeurMaximumSimpleNumero", 9);

        IHandler chainHandler = new AcheterBilletHandler();
        
        chainHandler.Next(new LancerTirageHandler())
                    .Next(new VoirGainsHandler());

        chainHandler.Handle(dictionaire);
        Listebillets = (List<AbstractBillet>) dictionaire["listeBillets"];
        billetsTire = (AbstractBillet) dictionaire["BilletsTire"];
        
        
        
        
        
        
        Console.WriteLine("---- Billet distribuer ----");
        foreach (AbstractBillet billet in Listebillets)
        {
            List<int> numeros = ((BilletSequence) billet).ListeNumero;
            Console.WriteLine(string.Join(",", numeros));
        }
        
        Console.WriteLine("---- Billet tire ----");
        List<int> numerosTire = ((BilletSequence) billetsTire).ListeNumero;
        Console.WriteLine(string.Join(",", numerosTire));

       








    }
}