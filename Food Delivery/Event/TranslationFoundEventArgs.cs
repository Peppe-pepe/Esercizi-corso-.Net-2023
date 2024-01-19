using Food_Delivery.Classes.TranslationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Delivery.Event
{
    internal class TranslationFoundEventArgs : EventArgs
    {
        public Translator Translator { get; }

        public TranslationFoundEventArgs(Translator translator)
        {
            Translator = translator;
        }
    }
}
