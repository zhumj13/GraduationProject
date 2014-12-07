using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data;
using System.IO;
namespace BIMChecker
{
    class XMLSerialize
    {
        ExcelDeserialize excelDeserialize = new ExcelDeserialize();
        private void SerializeDataSet(DataTable t,string filename)
        {
            XmlSerializer ser = new XmlSerializer(typeof(DataSet));

            // Creates a DataSet; adds a table, column, and ten rows.
            DataSet ds = new DataSet("myDataSet");
            ds.Tables.Add(t);
            DataRow r;
            for (int i = 0; i < 10; i++)
            {
                r = t.NewRow();
                r[0] = "Thing " + i;
                t.Rows.Add(r);
            }
            TextWriter writer = new StreamWriter(filename);
            ser.Serialize(writer, ds);
            writer.Close();
        }
        static void Main(string[] args)
        {
            //Program program = new Program();
            //program.Process();
            //XMLSerialize xmlserialize = new XMLSerialize();
            //string excelPath = @"D:\TestData\ifcClassification\Space140903.xls";
            //string sheetName = @"Sheet2$";
            //DataTable dt = null;
            //xmlserialize.excelDeserialize.readExcel(excelPath, sheetName, ref dt);
            //string path = @"D:\TestData\ifcClassification\test.xml";
            //xmlserialize.SerializeDataSet(dt, path);
            string filename = @"D:\TestData\ifcClassification\test.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Rules));
            TextWriter writer = new StreamWriter(filename);
            FifthLevel fifthLevel51 = new FifthLevel();
            fifthLevel51.number = "511n";
            fifthLevel51.title = "512n";
            FifthLevel fifthLevel52 = new FifthLevel();
            fifthLevel52.number = "521n";
            fifthLevel52.title = "522n";

            FourthLevel fourthLevel41 = new FourthLevel();
            FifthLevel[] fifthLevel4 = { fifthLevel51, fifthLevel52 };
            fourthLevel41.fifthLevel = fifthLevel4;
            fourthLevel41.number = "41n";
            fourthLevel41.title = "41t";
            FourthLevel fourthLevel42 = new FourthLevel();
            fourthLevel42.fifthLevel = fifthLevel4;
            fourthLevel42.number = "42n";
            fourthLevel42.title = "42t";

            ThirdLevel thirdLevel31 = new ThirdLevel();
            FourthLevel[] fourLevel3 = { fourthLevel41, fourthLevel42 };
            thirdLevel31.fourthLevel = fourLevel3;
            thirdLevel31.number = "31n";
            thirdLevel31.title = "31t";
            ThirdLevel thirdLevel32 = new ThirdLevel();
            thirdLevel32.fourthLevel = fourLevel3;
            thirdLevel32.number = "32n";
            thirdLevel32.title = "32t";

            SecondLevel secondLevel21 = new SecondLevel();
            ThirdLevel[] thirdLevel2 = { thirdLevel31, thirdLevel32 };
            secondLevel21.thirdLevel = thirdLevel2;
            secondLevel21.number = "21n";
            secondLevel21.title = "21t";
            SecondLevel secondLevel22 = new SecondLevel();
            secondLevel22.thirdLevel = thirdLevel2;
            secondLevel22.number = "22n";
            secondLevel22.title = "22t";

            FirstLevel firstLevel11 = new FirstLevel();
            SecondLevel[] secondLevel1 = { secondLevel21, secondLevel22 };
            firstLevel11.secondLevel = secondLevel1;
            firstLevel11.number = "11n";
            firstLevel11.title = "11t";
            FirstLevel firstLevel12 = new FirstLevel();
            firstLevel12.secondLevel = secondLevel1;
            firstLevel12.number = "12n";
            firstLevel12.title = "12t";
            ClassificationNumber classificationNumber1 = new ClassificationNumber();
            FirstLevel[] firstLevel = { firstLevel11, firstLevel12 };
            classificationNumber1.firstLevel = firstLevel;
            classificationNumber1.number = "classificationNumber1number";
            classificationNumber1.title = "classificationNumber1title";
            ClassificationNumber classificationNumber2 = new ClassificationNumber();
            classificationNumber2.firstLevel = firstLevel;
            classificationNumber2.number = "classificationNumber2number";
            classificationNumber2.title = "classificationNumber2title";

            Classification classification1 = new Classification();
            ClassificationNumber[] classificationNumber = { classificationNumber1, classificationNumber2 };
            classification1.classificationNumber = classificationNumber;

            Descriptor description1 = new Descriptor();
            description1.Variable = "number";
            description1.Title = "OmniClass Number";
            Descriptor description2 = new Descriptor();
            description2.Variable = "number";
            description2.Title = "OmniClass Number";

            Data data = new Data();
            Descriptor[] descriptions={description1,description2};
            data.Descriptors = descriptions;
            data.classification = classification1;

            ApplicatonTo applicationTo = new ApplicatonTo();
            string[] className={"IfcBuilding","IfcSite","IfcBuildingStorey"};
            applicationTo.className = className;

            Rule rule = new Rule();
            rule.name = "Table 11 - Construction Entities by Function";
            rule.description = @"Assigns a functional classification to IFC Building, IFC Site and ArchiCAD Stories based on this OmniClass (edition 2012) specification.

For example: use this rule to comply with
- 'Concept Design BIM 2010' MVD (GSA), which requires such classification for IfcBuilding and IfcBuildingStorey entities.
- 'FM Handover' MVD (COBie), which requires such classification for IfcBuilding entity.

'Apply' creates a Classification Reference for selected IFC entity, using OmniClass-required attributes derived from the item that you choose in the following list.";
            rule.applicationTo = applicationTo;
            rule.data = data;

            Rules rules = new Rules();
            rules.name = "OmniClass";
            rules.rule = rule;

            serializer.Serialize(writer, rules);
            writer.Close();

        }
    }
}
