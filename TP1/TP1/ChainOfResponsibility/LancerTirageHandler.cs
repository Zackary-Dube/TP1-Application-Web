using System;
using System.Collections.Generic;

namespace TP1.ChainOfResponsibility;

using TP1.Billeterie;
using TP1.Options;

public class LancerTirageHandler : AbstractHandler
{
    private Random random_mg;
    
    public int numero { get; set; }

    public LancerTirageHandler()
    {
        //random_mg = new Random();
    }

    public override void Handle(Dictionary<string, object> dictionnaire)
    {
        dictionnaire["message"] += "LancerTirage";

        base.Handle(dictionnaire);


    }
}