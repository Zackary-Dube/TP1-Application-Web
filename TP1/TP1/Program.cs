using System;
using System.Collections.Generic;
using System.Diagnostics;
using TP1.Billeterie;
using TP1.ChainOfResponsibility;
using TP1.Options;

namespace TP1;

class Program
{
    static void Main(string[] args)
    {
        
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
        
        dictionaire.Add("billetType", TypeBillet.Sequence);
        dictionaire.Add("BilletType", TypeBillet.Combinaison);
        dictionaire.Add("loterie", loterie);
        dictionaire.Add("nombreBilletVendu", 10000000);
        

        IHandler chainHandler = new AcheterBilletHandler();
        
        chainHandler.Next(new LancerTirageHandler())
                    .Next(new VoirGainsHandler());

        chainHandler.Handle(dictionaire);
        Console.WriteLine("Revenu des vente de billets : " + ((Loterie) dictionaire["loterie"]).Revenu);
        Console.WriteLine("Gain donner pour les prix : " + ((Loterie) dictionaire["loterie"]).Gain);
        Console.WriteLine("Profit : " + ((((Loterie) dictionaire["loterie"]).Revenu) - (((Loterie) dictionaire["loterie"]).Gain)));
        
        
        
        
        
        
        
        
        
        /*
        
        dictionaire.Add("nombreTirageAFaire", 10);
        dictionaire.Add("listeMontantGagne", montantGagne);
        dictionaire.Add("ValeurMaximumSimpleNumero", 9);

        IHandler chainHandler = new AcheterBilletHandler();
        
        chainHandler.Next(new LancerTirageHandler())
                    .Next(new VoirGainsHandler());

        chainHandler.Handle(dictionaire);
        
//      Creation des objets AbstractBillet, instancier par BilletSequence pour : listeBillets et billetTire
        listebillets = (List<AbstractBillet>) dictionaire["listeBillets"];
        billetTire = (AbstractBillet) dictionaire["BilletsTire"];
        
//      Montrer dans la console des billets vendus
        Console.WriteLine("---- Billet distribuer ----");
        foreach (AbstractBillet billet in listebillets)
        {
            List<int> numeros = ((BilletSequence) billet).ListeNumero;
            Console.WriteLine(string.Join(",", numeros));
        }
        
//      Montrer dans la console le billet tire
        Console.WriteLine("---- Billet tire ----");
        List<int> numerosTire = ((BilletSequence) billetTire).ListeNumero;
        Console.WriteLine(string.Join(",", numerosTire));

       */








    }
}