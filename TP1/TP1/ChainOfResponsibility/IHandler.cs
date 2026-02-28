/* Zackary Dubé */
namespace TP1.ChainOfResponsibility;

/// <summary>
/// Interface qui représente un maillon dans une chaîne
/// Chaque maillon peut traiter une action ou la passer au suivant
/// </summary>
public interface IHandler
{
    /// <summary>
    /// Définit le prochain handler dans la chaîne
    /// </summary>
    /// <param name="next">Le handler suivant</param>
    /// <returns>Le handler passé en paramètre afin de permettre le chaînage</returns>
    IHandler Next(IHandler next);
    
    /// <summary>
    /// Traite une action ou la transmet au prochain handler
    /// </summary>
    /// <param name="action">Dictionnaire contenant les données nécessaires au traitement</param>
    void Handle(Dictionary<String, object> action);
}