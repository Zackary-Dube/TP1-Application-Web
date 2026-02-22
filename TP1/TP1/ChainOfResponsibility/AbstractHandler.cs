using System;
using System.Collections.Generic;
using TP1.Options;

namespace TP1.ChainOfResponsibility;

/// <summary>
/// Sert de base pour appliquer les règles de IHandler
/// </summary>
public abstract class AbstractHandler : IHandler
{
    /// <summary>
    /// Garde en mémoire le prochain élément dans une chaîne
    /// </summary>
    protected IHandler? nextHandler;

    /// <summary>
    /// Définit quel est le prochain handler
    /// </summary>
    /// <param name="next">Le handler suivant à exécuter</param>
    /// <returns>Le handler passé en paramètre afin de permettre le chaînage</returns>
    public IHandler Next(IHandler next)
    {
        nextHandler = next;
        return next;
    }

    /// <summary>
    /// Ne fait rien par défaut et passe l’exécution au prochain handler s’il existe
    /// </summary>
    /// <param name="action">Dictionnaire contenant les données nécessaires au traitement</param>
    public virtual void Handle(Dictionary<string, object> dictionnaire)
    {
        if (nextHandler != null)
        {
            nextHandler.Handle(dictionnaire);
        }
    }
}