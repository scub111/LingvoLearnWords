using System;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace LingvoLearnWords
{
    #region CardStatus
    public enum CardStatus
    {
        Learn,
        Learned
    }
    #endregion

    #region DictionaryViewModel
    public class DictionaryViewModel : ViewModelBase
    {
        public DictionaryViewModel(XMLDictionary xmlDictionary)
        {
            XMLDictionary = xmlDictionary;
            if (XMLDictionary.Dictionary != null && XMLDictionary.Dictionary.Cards != null)
                _Cards = new ObservableCollection<CardViewModel>(XMLDictionary.Dictionary.Cards.Select(i => new CardViewModel(i)));
        }

        private XMLDictionary XMLDictionary;

        private ObservableCollection<CardViewModel> _Cards;
        public ObservableCollection<CardViewModel> Cards
        {
            get
            {
                return _Cards ?? Load();
            } 
        }

        /// <summary>
        /// Событие на загрузку данных.
        /// </summary>
        public event EventHandler Loaded = delegate { };

        #region Commands
        [Command]
        public ObservableCollection<CardViewModel> Load()
        {
            XMLDictionary.LoadFromXML();
            _Cards = new ObservableCollection<CardViewModel>(XMLDictionary.Dictionary.Cards.Select(i => new CardViewModel(i)));
            Loaded(this, EventArgs.Empty);
            return _Cards;
        }

        [Command]
        public void Save()
        {
            XMLDictionary.SaveToXML();
        }
        #endregion
    }
    #endregion
    
    #region StatisticsViewModel
    public class StatisticsViewModel : ViewModelBase
    {
        public StatisticsViewModel(CardMeaningViewModel cardMeaningOwner, Statistics statistics)
        {
            CardMeaningOwner = cardMeaningOwner;
            Statistics = statistics;
        }

        public CardMeaningViewModel CardMeaningOwner;

        private Statistics Statistics;

        public string Status
        {
            get { return Statistics.Status; }
            set { Statistics.Status = value; RaisePropertiesChanged("Status"); }
        }

        public string Answered
        {
            get { return Statistics.Answered; }
            set { Statistics.Answered = value; RaisePropertiesChanged("Answered"); }
        }

        public string Shown
        {
            get { return Statistics.Shown; }
            set { Statistics.Shown = value; RaisePropertiesChanged("Shown"); }
        }
    }
    #endregion

    #region CardViewModel
    public class CardViewModel : ViewModelBase
    {
        public CardViewModel(Card card)
        {
            Card = card;
            Meanings = new ObservableCollection<CardMeaningViewModel>(Card.Meanings.Select(i => new CardMeaningViewModel(this, i)));
            if (Meanings.Count > 0)
            {
                FirstTranslations = Meanings[0].Translations;
                FirstExamples = Meanings[0].Examples;
                FirstSounds = Meanings[0].Sounds;
            }
        }

        private Card Card;

        public string Word
        {
            get { return Card.Word; }
            set { Card.Word = value; RaisePropertiesChanged("Word"); }
        }

        public string Transcription
        {
            get
            {
                if (Meanings.Count > 0)
                    return Meanings[0].Transcription;
                else
                    return "[null]";
            }
            set
            {
                if (Meanings.Count > 0)
                    Meanings[0].Transcription = value;
                RaisePropertiesChanged("Transcription");
            }
        }

        public ObservableCollection<CardMeaningViewModel> Meanings { get; private set; }

        public ObservableCollection<CardMeaningTranslationViewModel> FirstTranslations { get; private set; }

        public ObservableCollection<CardMeaningExampleViewModel> FirstExamples { get; private set; }

        public ObservableCollection<CardMeaningSoundViewModel> FirstSounds { get; private set; }

        public string TranslationContent
        {
            get
            {
                if (Meanings.Count > 0 && Meanings[0].Translations.Count > 0)
                {
                    StringBuilder result = new StringBuilder();

                    for (int i = 0; i < Meanings[0].Translations.Count; i++)
                    {
                        result.Append(Meanings[0].Translations[i].Word);
                        if (i != Meanings[0].Translations.Count - 1)
                            result.Append(@" // ");
                    }

                    return result.ToString();
                }
                else
                    return "[null]";
            }
        }

        public StatisticsViewModel FirstStatistic
        {
            get
            {
                if (Meanings.Count > 0 && Meanings[0].Statistics.Count > 0)
                    return Meanings[0].Statistics[0];
                else
                    return null;
            }
        }

        public int Percent
        {
            get
            {
                int result = 0;
                if (FirstStatistic != null)
                {
                    int answered;
                    bool parsed = int.TryParse(FirstStatistic.Answered, out answered);
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
                CardStatus result = CardStatus.Learn;
                if (FirstStatistic != null)
                {
                    switch (FirstStatistic.Status)
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
            set
            {
                if (FirstStatistic != null)
                {
                    switch (value)
                    {
                        case CardStatus.Learn:
                            FirstStatistic.Status = "3";
                            break;

                        case CardStatus.Learned:
                            FirstStatistic.Status = "4";
                            break;
                    }
                }
                RaisePropertiesChanged("Status");
            }
        }

        public void RaisePropertiesChanged(string propertyName)
        {
            base.RaisePropertiesChanged(propertyName);
        }
    }
    #endregion

    #region CardMeaningViewModel
    public class CardMeaningViewModel : ViewModelBase
    {
        public CardMeaningViewModel(CardViewModel cardOwner, CardMeaning meaning)
        {
            CardOwner = cardOwner;
            Meaning = meaning;
            Statistics = new ObservableCollection<StatisticsViewModel>(Meaning.Statistics.Select(i => new StatisticsViewModel(this, i)));
            Translations = new ObservableCollection<CardMeaningTranslationViewModel>(Meaning.Translations.Select(i => new CardMeaningTranslationViewModel(this, i)));
            Examples = new ObservableCollection<CardMeaningExampleViewModel>(Meaning.Example.Select(i => new CardMeaningExampleViewModel(this, i)));
            Sounds = new ObservableCollection<CardMeaningSoundViewModel>(Meaning.Sound.Select(i => new CardMeaningSoundViewModel(this, i)));
        }

        public CardViewModel CardOwner;

        private CardMeaning Meaning;

        public string Transcription
        {
            get { return Meaning.Transcription; }
            set { Meaning.Transcription = value; RaisePropertiesChanged("Transcription"); }
        }

        public string Soundfile
        {
            get { return Meaning.Soundfile; }
            set { Meaning.Soundfile = value; RaisePropertiesChanged("Soundfile"); }
        }

        public ObservableCollection<StatisticsViewModel> Statistics { get; set; }

        public ObservableCollection<CardMeaningTranslationViewModel> Translations { get; set; }

        public ObservableCollection<CardMeaningExampleViewModel> Examples { get; set; }

        public ObservableCollection<CardMeaningSoundViewModel> Sounds { get; set; }
    }
    #endregion

    #region CardMeaningTranslationViewModel
    public class CardMeaningTranslationViewModel : ViewModelBase
    {
        public CardMeaningTranslationViewModel(CardMeaningViewModel cardMeaningOwner, CardMeaningTranslation translation)
        {
            CardMeaningOwner = cardMeaningOwner;
            Translation = translation;
        }

        public CardMeaningViewModel CardMeaningOwner;

        private CardMeaningTranslation Translation;

        public string Word
        {
            get { return Translation.Word; }
            set
            {
                Translation.Word = value;
                RaisePropertiesChanged("Word");
                CardMeaningOwner.CardOwner.RaisePropertiesChanged("TranslationContent");
            }
        }
    }
    #endregion

    #region CardMeaningExampleViewModel
    public class CardMeaningExampleViewModel : ViewModelBase
    {
        public CardMeaningExampleViewModel(CardMeaningViewModel cardMeaningOwner, CardMeaningExample cardMeaningExample)
        {
            CardMeaningOwner = cardMeaningOwner;
            CardMeaningExample = cardMeaningExample;
        }

        public CardMeaningViewModel CardMeaningOwner;

        private CardMeaningExample CardMeaningExample;

        public string Example
        {
            get { return CardMeaningExample.Example; }
            set { CardMeaningExample.Example = value; RaisePropertiesChanged("Example"); }
        }
    }
    #endregion

    #region CardMeaningSoundViewModel
    public class CardMeaningSoundViewModel : ViewModelBase
    {
        public CardMeaningSoundViewModel(CardMeaningViewModel cardMeaningOwner, CardMeaningSound cardMeaningSound)
        {
            CardMeaningOwner = cardMeaningOwner;
            CardMeaningSound = cardMeaningSound;
        }

        public CardMeaningViewModel CardMeaningOwner;

        private CardMeaningSound CardMeaningSound;

        public string Name
        {
            get { return CardMeaningSound.Name; }
            set { CardMeaningSound.Name = value; RaisePropertiesChanged("Name"); }
        }
    }
    #endregion
}

