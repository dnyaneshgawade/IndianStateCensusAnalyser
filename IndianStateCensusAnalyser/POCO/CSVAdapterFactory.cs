using IndianStateCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.POCO
{
    public class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeader)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeader);
                
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
