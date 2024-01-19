using Food_Delivery.Classes.TranslationClasses;
using Food_Delivery.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Delivery.Factories.Translation
{
    internal class TranslationFactory : ITranslationFactory
    {
            public Translator FindTranslator(string language, List<Translator> trans)
            {
                return trans.FirstOrDefault(t => t.Language == language);
            }
    }
}
