using IndianStateCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndianStateCensusAnalyser.POCO
{
    public class CensusAnalyser
    {
        public enum Country
        {
            INDIA
        }
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(CensusAnalyser.Country country,string csvFilePath,string dataHeader)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeader);
            return dataMap;
        }
        
    }
}
