using System;
using System.Collections.Generic;
using TP1.Options;

namespace TP1.ChainOfResponsibility;

/// <summary>
/// Sert de base pour appliquer les regles de IHandler
/// </summary>
public abstract class AbstractHandler : IHandler
{
    /// <summary>
    /// Garde en memoire le prochain dans une chaine
    /// </summary>
    protected IHandler? nextHandler;

    /// <summary>
    /// Definis qui est le prochain handler
    /// </summary>
    /// <param name="next"></param>
    /// <returns></returns>
    public IHandler Next(IHandler next)
    {
        nextHandler = next;
        return next;
    }

    /// <summary>
    /// Ne fait rien par defaut avec l'action
    /// </summary>
    /// <param name="action"></param>
    public virtual void Handle(Dictionary<string, object> dictionnaire)
    {
        if (nextHandler != null)
        {
            nextHandler.Handle(dictionnaire);
        }
    }
}