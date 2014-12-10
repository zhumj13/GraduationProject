using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace BIMChecker
{
    public class Rules
    {
        [XmlAttribute(AttributeName = "name")]
        public string name;
        [XmlElement(ElementName = "Rule")]
        public Rule rule;
    }
    public class Rule
    {
        [XmlElement(ElementName = "Name")]
        public string name;
        [XmlElement(ElementName = "Description")]
        public string description;
        [XmlElement(ElementName = "ApplicatonTo")]
        public ApplicatonTo applicationTo;
        [XmlElement(ElementName = "Data")]
        public Data data;
    }
    public class ApplicatonTo
    {
        [XmlElement(ElementName = "ClassName")]
        public string[] className;
    }
    public class Data
    {
        [XmlArray("Descriptors")]
        public Descriptor[] Descriptors;
        [XmlElement(ElementName = "DataEntries")]
        public Classification classification;
    }
    public class Descriptor
    {
        [XmlAttribute(AttributeName = "Variable")]
        public string Variable;
        [XmlAttribute(AttributeName = "Title")]
        public string Title;
    }
    [XmlRoot("DataEntries")]
    public class Classification
    {
        //[XmlElement(ElementName = "DataEntry")]
        //public ClassificationNumber[] classificationNumber;
        [XmlElement(ElementName = "DataEntry")]
        public FirstLevel[] firstLevel;
        [XmlAttribute(AttributeName = "number")]
        public string number;
        [XmlAttribute(AttributeName = "title")]
        public string title;
    }
    public class ClassificationNumber
    {
        [XmlElement(ElementName = "DataEntry")]
        public FirstLevel[] firstLevel;
        [XmlAttribute(AttributeName = "number")]
        public string number;
        [XmlAttribute(AttributeName = "title")]
        public string title;
    }
    public class FirstLevel
    {
        [XmlElement(ElementName = "DataEntry")]
        public SecondLevel[] secondLevel;

        [XmlAttribute(AttributeName = "number")]
        public string number;
        [XmlAttribute(AttributeName = "title")]
        public string title;
    }

    public class SecondLevel
    {
        [XmlElement(ElementName = "DataEntry")]
        public ThirdLevel[] thirdLevel;

        [XmlAttribute(AttributeName = "number")]
        public string number;
        [XmlAttribute(AttributeName = "title")]
        public string title;
    }
    public class ThirdLevel
    {
        [XmlElement(ElementName = "DataEntry")]
        public FourthLevel[] fourthLevel;

        [XmlAttribute(AttributeName = "number")]
        public string number;
        [XmlAttribute(AttributeName = "title")]
        public string title;
    }
    public class FourthLevel
    {
        [XmlElement(ElementName = "DataEntry")]
        public FifthLevel[] fifthLevel;

        [XmlAttribute(AttributeName = "number")]
        public string number;
        [XmlAttribute(AttributeName = "title")]
        public string title;
    }
    public class FifthLevel
    {
        [XmlAttribute(AttributeName = "number")]
        public string number;
        [XmlAttribute(AttributeName = "title")]
        public string title;
    }
}
