using Food_Delivery.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Delivery.Classes.TranslationClasses
{
    internal class Translator : ITranslation
    {
        public string Name { get; set; }
        public string Language { get; set; }
    }
}
