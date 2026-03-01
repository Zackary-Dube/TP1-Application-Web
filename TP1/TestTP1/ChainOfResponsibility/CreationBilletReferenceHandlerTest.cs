using NUnit.Framework;
using System.Collections.Generic;
using TP1;
using TP1.Billeterie;
using TP1.ChainOfResponsibility;
using TP1.Options;

/* Ilias Neil */
namespace TestTP1.ChainOfResponsibility;

public class CreationBilletReferenceHandlerTest
{
        private CreationBilletReferenceHandler _handler;
        private Loterie _loterie;
        private Dictionary<string, object> _dictionnaire;

        [SetUp]
        public void Setup()
        {
            _handler = new CreationBilletReferenceHandler();
            _loterie = new Loterie();

            _dictionnaire = new Dictionary<string, object>
            {
                { "loterie", _loterie },
                { "numerosUtilisateur", new List<int> { 1, 2, 3, 4, 5, 6 } }
            };
        }

        [Test]
        public void Handle_CreeBilletCombinaison_QuandTypeCombinaison()
        {
            _dictionnaire["billetType"] = TypeBillet.Combinaison;
            
            _handler.Handle(_dictionnaire);
            
            Assert.That(_dictionnaire.ContainsKey("billetUtilisateur"));
            Assert.That(_dictionnaire["billetUtilisateur"], Is.TypeOf<BilletCombinaison>());

            var billet = (AbstractBillet)_dictionnaire["billetUtilisateur"];
            Assert.That(billet.ListeNumero, Is.EqualTo(new List<int> { 1,2,3,4,5,6 }));

            Assert.That(_loterie.ListeBillets.Count, Is.EqualTo(1));
        }

        [Test]
        public void Handle_CreeBilletSequence_QuandTypeSequence()
        {
            _dictionnaire["billetType"] = TypeBillet.Sequence;
            
            _handler.Handle(_dictionnaire);
            
            Assert.That(_dictionnaire.ContainsKey("billetUtilisateur"));
            Assert.That(_dictionnaire["billetUtilisateur"], Is.TypeOf<BilletSequence>());

            var billet = (AbstractBillet)_dictionnaire["billetUtilisateur"];
            Assert.That(billet.ListeNumero, Is.EqualTo(new List<int> { 1,2,3,4,5,6 }));

            Assert.That(_loterie.ListeBillets.Count, Is.EqualTo(1));
        }

        [Test]
        public void Handle_AjouteBilletALaLoterie()
        {
            _dictionnaire["billetType"] = TypeBillet.Combinaison;
            
            _handler.Handle(_dictionnaire);
            
            Assert.That(_loterie.ListeBillets.Count, Is.EqualTo(1));
        }
}