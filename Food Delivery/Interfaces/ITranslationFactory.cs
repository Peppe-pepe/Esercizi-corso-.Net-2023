using Food_Delivery.Classes.TranslationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Delivery.Interfaces
{
    internal interface ITranslationFactory
    {
        public Translator FindTranslator(string language, List<Translator> trans);
    }
}
