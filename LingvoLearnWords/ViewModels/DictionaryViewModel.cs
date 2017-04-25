using System;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DevExpress.Mvvm;

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
        public DictionaryViewModel(XMLDictionary xmlDictionary)
        {
            XMLDictionary = xmlDictionary;
            if (XMLDictionary.Dictionary != null && XMLDictionary.Dictionary.Cards != null)
                Cards = new ObservableCollection<CardViewModel>(XMLDictionary.Dictionary.Cards.Select(i => new CardViewModel(i)));
            else
                LoadCommand.Execute(null);
        }

        private XMLDictionary XMLDictionary;

        public ObservableCollection<CardViewModel> Cards { get; private set; }

        /// <summary>
        /// Событие на загрузку данных.
        /// </summary>
        public event EventHandler Loaded = delegate { };

        #region Commands
        #region Load
        private DelegateCommand loadCommand;

        public ICommand LoadCommand
        {
            get
            {
                if (loadCommand == null)
                    loadCommand = new DelegateCommand(() =>
                    {
                        XMLDictionary.LoadFromXML();
                        Cards = new ObservableCollection<CardViewModel>(XMLDictionary.Dictionary.Cards.Select(i => new CardViewModel(i)));
                        Loaded(this, EventArgs.Empty);
                    });
                return loadCommand;
            }
        }
        #endregion
        #region Save
        private DelegateCommand saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new DelegateCommand(() =>
                    {
                        XMLDictionary.SaveToXML();
                    });
                return saveCommand;
            }
        }
        #endregion

        #endregion
    }

    public class CardViewModel : ViewModelBase
    {
        public CardViewModel(Card card)
        {
            Card = card;
            Meanings = new ObservableCollection<CardMeaningViewModel>(Card.Meanings.Select(i => new CardMeaningViewModel(this, i)));
            if (Meanings.Count > 0)
            {
                FirstTranslations = Meanings[0].Translations;
                FirstSounds = Meanings[0].Sounds;
            }
        }

        private Card Card;

        public string Word
        {
            get { return Card.Word; }
            set { Card.Word = value; RaisePropertiesChanged("Word"); }
        }

        public ObservableCollection<CardMeaningViewModel> Meanings { get; private set; }

        public ObservableCollection<CardMeaningTranslationViewModel> FirstTranslations { get; private set; }

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

        public int Percent
        {
            get
            {
                int result = 0;
                if (Meanings.Count > 0 && Meanings[0].Statistics.Count > 0)
                {
                    int answered;
                    bool parsed = int.TryParse(Meanings[0].Statistics[0].Answered, out answered);
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
                CardStatus result = CardStatus.NaN;
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
            Meaning = meaning;
            Statistics = new ObservableCollection<StatisticsViewModel>(Meaning.Statistics.Select(i => new StatisticsViewModel(this, i)));
            Translations = new ObservableCollection<CardMeaningTranslationViewModel>(Meaning.Translations.Select(i => new CardMeaningTranslationViewModel(this, i)));
            Sounds = new ObservableCollection<CardMeaningSoundViewModel>(Meaning.Sound.Select(i => new CardMeaningSoundViewModel(this, i)));
        }

        public CardViewModel CardOwner;

        private CardMeaning Meaning;

        public ObservableCollection<StatisticsViewModel> Statistics { get; set; }

        public ObservableCollection<CardMeaningTranslationViewModel> Translations { get; set; }

        public ObservableCollection<CardMeaningSoundViewModel> Sounds { get; set; }

        public string Soundfile
        {
            get { return Meaning.Soundfile; }
            set { Meaning.Soundfile = value; RaisePropertiesChanged("Soundfile"); }
        }
    }

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
}

