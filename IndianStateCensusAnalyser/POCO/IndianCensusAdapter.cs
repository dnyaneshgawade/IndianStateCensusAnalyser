using IndianStateCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndianStateCensusAnalyser.POCO
{
    public class IndianCensusAdapter:CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilepath,string dataHeader)
        {
            dataMap = new Dictionary<string, CensusDTO>();
            censusData = GetSensusData(csvFilepath, dataHeader);
            foreach(string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains Wrong Delimeter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER);
                }
                string[] column = data.Split(",");
                if (csvFilepath.Contains("IndiaStateCode.csv"))
                    dataMap.Add(column[1], new CensusDTO(new StateCodeDAO(column[0], column[1], column[2], column[3])));
            }
            return dataMap.ToDictionary(p=> p.Key, p=>p.Value);
        }
    }
}
