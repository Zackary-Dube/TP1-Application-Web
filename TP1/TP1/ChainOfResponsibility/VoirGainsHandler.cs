using System;
using System.Collections.Generic;

namespace TP1.ChainOfResponsibility;

using TP1.Options;
using TP1.Billeterie;

public class VoirGainsHandler : AbstractHandler
{
    public VoirGainsHandler()
    {
        
    }
    
    public override void Handle(Dictionary<string, object> dictionnaire)
    {
        dictionnaire["message"] += "VoirGain";

        base.Handle(dictionnaire);

    }
}