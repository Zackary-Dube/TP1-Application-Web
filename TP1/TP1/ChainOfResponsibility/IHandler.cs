using System;
using System.Collections.Generic;

namespace TP1.ChainOfResponsibility;

using TP1.Options;

/// <summary>
/// Interface qui represente un maillon dans une chaine
/// Chaque maillon peut traiter une action ou la passer au suivant
/// </summary>
public interface IHandler
{
    IHandler Next(IHandler next);
    void Handle(Dictionary<String, object> action);
}