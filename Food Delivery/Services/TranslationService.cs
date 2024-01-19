using Food_Delivery.Classes.TranslationClasses;
using Food_Delivery.Event;
using Food_Delivery.Factories.Translation;
using Food_Delivery.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Delivery.Services
{
    internal class TranslationService
    {
        private readonly TranslationFactory _translatorFactory;
        private readonly List<Translator> _translators;

        public TranslationService(TranslationFactory translatorFactory, List<Translator> translators)
        {
            _translatorFactory = translatorFactory ?? throw new ArgumentNullException(nameof(translatorFactory));
            _translators = translators ?? throw new ArgumentNullException(nameof(translators));
        }

        public async Task<Translator> FindTransaltor(string language)
        {
            try
            {
                var translator = _translators.FirstOrDefault(t => t.Language == language);
                if (translator != null)
                {
                    await Task.Delay(100);
                    OnTranslatorFound(translator);
                    return translator;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public event EventHandler<TranslationFoundEventArgs> TranslatorFound;

        protected virtual void OnTranslatorFound(Translator translator)
        {
            TranslatorFound.Invoke(this, new TranslationFoundEventArgs(translator));
        }
    }
}
