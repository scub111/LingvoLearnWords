using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LingvoLearnWords
{
    [Serializable()]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "dictionary", IsNullable = false)]
    public class Dictionary
    {
        [XmlAttribute("formatVersion")]
        public string FormatVersion { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("sourceLanguageId")]
        public string SourceLanguageId { get; set; }

        [XmlAttribute("destinationLanguageId")]
        public string DestinationLanguageId { get; set; }

        [XmlAttribute("nextWordId")]
        public string NextWordId { get; set; }

        [XmlAttribute("targetNamespace")]
        public string TargetNamespace { get; set; }

        [XmlAttribute("soundfile")]
        public string Soundfile { get; set; }

        [XmlElement("statistics")]
        public Collection<Statistics> Statistics { get; set; }

        [XmlElement("card")]
        public Collection<Card> Cards { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "statistics", IsNullable = false)]
    public partial class Statistics
    {
        [XmlAttribute("readyMeaningsQuantity")]
        public string ReadyMeaningsQuantity { get; set; }

        [XmlAttribute("activeMeaningsQuantity")]
        public string ActiveMeaningsQuantity { get; set; }

        [XmlAttribute("learnedMeaningsQuantity")]
        public string LearnedMeaningsQuantity { get; set; }


        [XmlAttribute("status")]
        public string Status { get; set; }

        [XmlAttribute("answered")]
        public string Answered { get; set; }

        [XmlAttribute("shown")]
        public string Shown { get; set; }
    }


    [Serializable()]
    [XmlType(AnonymousType = true)]
    public class Card
    {
        [XmlElement("word")]
        public string Word { get; set; }

        [XmlArray("meanings")]
        [XmlArrayItem("meaning")]
        public Collection<CardMeaning> Meanings { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true)]
    public class CardMeaning
    {
        [XmlAttribute("transcription")]
        public string Transcription { get; set; }

        [XmlAttribute("soundfile")]
        public string Soundfile { get; set; }

        [XmlAttribute("partOfSpeech")]
        public string PartOfSpeech { get; set; }

        [XmlAttribute("meaningId")]
        public string MeaningId { get; set; }

        [XmlElement("statistics")]
        public Collection<Statistics> Statistics { get; set; }

        [XmlArray("translations")]
        [XmlArrayItem("word")]
        public Collection<CardMeaningTranslation> Translations { get; set; }

        [XmlArray("examples")]
        [XmlArrayItem("example")]
        public Collection<CardMeaningExample> Example { get; set; }

        [XmlElement("sound")]
        public Collection<CardMeaningSound> Sound { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true)]
    public class CardMeaningTranslation
    {
        [XmlText()]
        public string Word { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true)]
    public class CardMeaningExample
    {
        [XmlText()]
        public string Example { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true)]
    public class CardMeaningSound
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
