using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_3
{
    class Erreur
    {
        private string phrase;
        public Erreur(string phrase)
        {
            this.phrase = phrase;
        }
        public string Phrase
        {
            get { return this.phrase; }
        }
        /// <summary>
        /// permet de signaler où et quel est le problème rencontré
        /// </summary>
        /// <returns></returns>la phrase d'erreur
        public string ErreurPG()
        {
            string phraseFinale = null;
            phraseFinale = "\n\t\t\t\t\t\t\t\t" + this.phrase + "\n\n\t\t\t\t\t\t\tVoulez vous retourner au menu ou quitter ?\n\t\t\t\t\t\t\t   1.Menu                    2.Quitter\n\t\t\t\t\t\t\t\t    Votre choix : ";
            return phraseFinale;
        }
    }
}
