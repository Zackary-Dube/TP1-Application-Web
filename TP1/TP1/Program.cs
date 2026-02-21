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
        List<double> montantGagne = new List<double>();
        
        
        
        
        
        
//      Creation des objets necessaire pour notre loterie
/*
        Loterie loterie = new Loterie();
        for (int i = 0; i < 100; i++)
        {
            AbstractBillet billet = new BilletSequence();
            loterie.AjouterBilletListe(billet);
        }
        
        loterie.LancerTirage();

        loterie.CalculeGain();
        Console.WriteLine(loterie.Gain);
        
   



        Loterie loterie = new Loterie();
        List<int> listeNumero = new List<int>() {1,2,31,4,15,6};
        List<int> listeNumeroGagnant = new List<int>() {11,2,31,4,15,1};
        AbstractBillet billet = new BilletSequence(listeNumero);
        loterie.AjouterBilletListe(billet);
        AbstractBillet billetGagnant = new BilletSequence(listeNumeroGagnant);
        
//      1 = 10 | 2 = 20 | 3 = 30 | 4 = 40 | 5 = 50 | 6 = 60

        double montant = billet.CalculerGainSiGagnant(billetGagnant);
        
        
   */      
        
        
        
        
        Loterie loterie = new Loterie();
        Dictionary<string, object> dictionaire = new Dictionary<string, object>();
        
        dictionaire.Add("billetType", TypeBillet.Sequence);
        dictionaire.Add("loterie", loterie);
        dictionaire.Add("nombreBilletVendu", 10000000);
        

        IHandler chainHandler = new AcheterBilletHandler();
        
        chainHandler.Next(new LancerTirageHandler())
                    .Next(new VoirGainsHandler());

        chainHandler.Handle(dictionaire);
        Console.WriteLine("Revenu : " + ((Loterie) dictionaire["loterie"]).Revenu);
        Console.WriteLine("Gain : " + ((Loterie) dictionaire["loterie"]).Gain);

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