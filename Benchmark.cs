using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using BenchmarkDotNet.Attributes;

namespace testStupidXmlParsing
{
    [ClrJob(baseline: true), CoreJob]
    [MinColumn, MaxColumn]
    [MemoryDiagnoser]
    [RPlotExporter]
    public class Benchmark
    {
        private string _rawData = null;
        private XElement _documentParsed = null;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _rawData = File.ReadAllText("./data.xml", Encoding.UTF8);
            _documentParsed = XElement.Parse(_rawData);
            Console.WriteLine($"readed file length: {_rawData.Length}");
        }

        [Benchmark]
        public void TestRootParsing()
        {
            var document = XElement.Parse(_rawData);
        }

        [Benchmark]
        public void TestDataParsingManual()
        {
            XElement main = _documentParsed.XPathSelectElement("main");
            XElement[] elements = main.XPathSelectElements("datas/data").ToArray();

            List<DataDto> results = new List<DataDto>();

            if (elements.Length > 0)
            {
                List<DataDto> parsed = ParseData(elements);

                results.AddRange(parsed);
            }
        }

        private List<DataDto> ParseData(XElement[] elements)
        {
            List<DataDto> results = new List<DataDto>();

            foreach (XElement element in elements)
            {
                var data = new DataDto
                {
                    Number = int.Parse(element.Attribute("number").Value),
                    String = element.Attribute("string").Value,
                };

                results.Add(data);
            }

            return results;
        }

        private class DataDto
        {
            public int Number { get; set; }

            public string String { get; set; }

            public override string ToString()
            {
                return $"{Number} : {String}";
            }
        }
    }
}
