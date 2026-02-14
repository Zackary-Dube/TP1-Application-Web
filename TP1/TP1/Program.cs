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
        List<int> numeroTire = new List<int>();
        List<double> montantGagne = new List<double>();
        List<AbstractBillet> billets = new List<AbstractBillet>();

        dictionaire.Add("billetType", TypeBillet.Sequence);
        dictionaire.Add("nombreTirageAFaire", 100);
        dictionaire.Add("tableauDesNumeroTires", numeroTire);
        dictionaire.Add("listeMontantGagne", montantGagne);
        dictionaire.Add("listeBillets", billets);
        dictionaire.Add("loterie", loterie);
        dictionaire.Add("nombreNumero", 6);
        dictionaire.Add("message", "message");

        IHandler chainHandler = new AcheterBilletHandler();
        
        chainHandler.Next(new LancerTirageHandler())
                    .Next(new VoirGainsHandler());

        chainHandler.Handle(dictionaire);
        billets = (List<AbstractBillet>) dictionaire["listeBillets"];

        Console.WriteLine(billets);

        foreach (AbstractBillet billet in billets)
        {
            List<int> numeros = ((AbstractBilletSequence) billet).ListeNumero;
            
            Console.WriteLine(string.Join(",", numeros));
        }
        
        
        









    }
}