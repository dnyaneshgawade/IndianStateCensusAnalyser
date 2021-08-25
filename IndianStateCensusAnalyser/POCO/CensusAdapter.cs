using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianStateCensusAnalyser.POCO
{
    public class CensusAdapter
    {
        protected string[] GetSensusData(string csvFilepath,string dataHeaders)
        {
            string[] censusData;
            if (!File.Exists(csvFilepath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilepath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }

            censusData = File.ReadAllLines(csvFilepath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException("Incorrect Header in data", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            return censusData;
        }
    }
}
