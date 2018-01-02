using System;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace LingvoLearnWords
{
    public enum CardStatus
    {
        NaN,
        Learn,
        Learned
    }

    public class DictionaryViewModel : ViewModelBase
    {
        public DictionaryViewModel(XmlDictionary xmlDictionary)
        {
            _xmlDictionary = xmlDictionary;
            if (_xmlDictionary.Dictionary?.Cards != null)
                _cards = new ObservableCollection<CardViewModel>(_xmlDictionary.Dictionary.Cards.Select(i => new CardViewModel(i)));
        }

        private readonly XmlDictionary _xmlDictionary;

        private ObservableCollection<CardViewModel> _cards;
        public ObservableCollection<CardViewModel> Cards => _cards ?? Load();

        /// <summary>
        /// Событие на загрузку данных.
        /// </summary>
        public event EventHandler Loaded = delegate { };

        #region Commands
        [Command]
        public ObservableCollection<CardViewModel> Load()
        {
            _xmlDictionary.LoadFromXml();
            _cards = new ObservableCollection<CardViewModel>(_xmlDictionary.Dictionary.Cards.Select(i => new CardViewModel(i)));
            Loaded(this, EventArgs.Empty);
            return _cards;
        }

        [Command]
        public void Save()
        {
            _xmlDictionary.SaveToXml();
        }
        #endregion
    }

    public class CardViewModel : ViewModelBase
    {
        public CardViewModel(Card card)
        {
            _card = card;
            Meanings = new ObservableCollection<CardMeaningViewModel>(_card.Meanings.Select(i => new CardMeaningViewModel(this, i)));
            if (Meanings.Count > 0)
            {
                FirstTranslations = Meanings[0].Translations;
                FirstSounds = Meanings[0].Sounds;
            }
        }

        private readonly Card _card;

        public string Word
        {
            get => _card.Word;
            set { _card.Word = value; RaisePropertiesChanged("Word"); }
        }

        public ObservableCollection<CardMeaningViewModel> Meanings { get; }

        public ObservableCollection<CardMeaningTranslationViewModel> FirstTranslations { get; }

        public ObservableCollection<CardMeaningSoundViewModel> FirstSounds { get; }

        public string TranslationContent
        {
            get
            {
                if (Meanings != null && (Meanings.Count > 0 && Meanings[0].Translations.Count > 0))
                {
                    var result = new StringBuilder();

                    for (var i = 0; i < Meanings[0].Translations.Count; i++)
                    {
                        result.Append(Meanings[0].Translations[i].Word);
                        if (i != Meanings[0].Translations.Count - 1)
                            result.Append(" // ");
                    }

                    return result.ToString();
                }
                return "[null]";
            }
        }

        public int Percent
        {
            get
            {
                var result = 0;
                if (Meanings.Count > 0 && Meanings[0].Statistics.Count > 0)
                {
                    var parsed = int.TryParse(Meanings[0].Statistics[0].Answered, out var answered);
                    if (parsed)
                        result = answered * 10;

                    if (result > 100)
                        result = 100;
                }
                return result;
            }
        }

        public CardStatus Status
        {
            get
            {
                var result = CardStatus.NaN;
                if (Meanings.Count > 0 && Meanings[0].Statistics.Count > 0)
                {
                    switch (Meanings[0].Statistics[0].Status)
                    {
                        case "2":
                        case "3":
                            result = CardStatus.Learn;
                            break;

                        case "4":
                            result = CardStatus.Learned;
                            break;
                    }
                }
                return result;
            }
        }

        public void RaisePropertiesChanged(string propertyName)
        {
            base.RaisePropertiesChanged(propertyName);
        }
    }

    public class CardMeaningViewModel : ViewModelBase
    {
        public CardMeaningViewModel(CardViewModel cardOwner, CardMeaning meaning)
        {
            CardOwner = cardOwner;
            _meaning = meaning;
            Statistics = new ObservableCollection<StatisticsViewModel>(_meaning.Statistics.Select(i => new StatisticsViewModel(this, i)));
            Translations = new ObservableCollection<CardMeaningTranslationViewModel>(_meaning.Translations.Select(i => new CardMeaningTranslationViewModel(this, i)));
            Sounds = new ObservableCollection<CardMeaningSoundViewModel>(_meaning.Sound.Select(i => new CardMeaningSoundViewModel(this, i)));
        }

        public CardViewModel CardOwner;

        private readonly CardMeaning _meaning;

        public ObservableCollection<StatisticsViewModel> Statistics { get; set; }

        public ObservableCollection<CardMeaningTranslationViewModel> Translations { get; set; }

        public ObservableCollection<CardMeaningSoundViewModel> Sounds { get; set; }

        public string Soundfile
        {
            get => _meaning.Soundfile;
            set { _meaning.Soundfile = value; RaisePropertiesChanged("Soundfile"); }
        }
    }

    public class CardMeaningTranslationViewModel : ViewModelBase
    {
        public CardMeaningTranslationViewModel(CardMeaningViewModel cardMeaningOwner, CardMeaningTranslation translation)
        {
            CardMeaningOwner = cardMeaningOwner;
            _translation = translation;
        }

        public CardMeaningViewModel CardMeaningOwner;

        private readonly CardMeaningTranslation _translation;

        public string Word
        {
            get => _translation.Word;
            set
            {
                _translation.Word = value;
                RaisePropertiesChanged("Word");
                CardMeaningOwner.CardOwner.RaisePropertiesChanged("TranslationContent");
            }
        }
    }

    public class StatisticsViewModel : ViewModelBase
    {
        public StatisticsViewModel(CardMeaningViewModel cardMeaningOwner, Statistics statistics)
        {
            CardMeaningOwner = cardMeaningOwner;
            _statistics = statistics;
        }

        public CardMeaningViewModel CardMeaningOwner;

        private readonly Statistics _statistics;

        public string Status
        {
            get => _statistics.Status;
            set { _statistics.Status = value; RaisePropertiesChanged("Status"); }
        }

        public string Answered
        {
            get => _statistics.Answered;
            set { _statistics.Answered = value; RaisePropertiesChanged("Answered"); }
        }

        public string Shown
        {
            get => _statistics.Shown;
            set { _statistics.Shown = value; RaisePropertiesChanged("Shown"); }
        }
    }

    public class CardMeaningSoundViewModel : ViewModelBase
    {
        public CardMeaningSoundViewModel(CardMeaningViewModel cardMeaningOwner, CardMeaningSound cardMeaningSound)
        {
            CardMeaningOwner = cardMeaningOwner;
            _cardMeaningSound = cardMeaningSound;
        }

        public CardMeaningViewModel CardMeaningOwner;

        private readonly CardMeaningSound _cardMeaningSound;

        public string Name
        {
            get => _cardMeaningSound.Name;
            set { _cardMeaningSound.Name = value; RaisePropertiesChanged("Name"); }
        }
    }
}

