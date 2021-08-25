using IndianStateCensusAnalyser.DTO;
using IndianStateCensusAnalyser.POCO;
using NUnit.Framework;
using System.Collections.Generic;

namespace IndianStateCensusAnalyserTest
{
    public class Tests
    {
        static readonly string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static readonly string indianStateCensusFilePath = @"C:\Users\dnyan\dnyana\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CsvFiles\IndiaStateCensusData.csv";
        static readonly string wrongHeaderIndianCensusFilePath = @"C:\Users\dnyan\dnyana\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CsvFiles\WrongIndiaStateCensusData.csv";
        static readonly string delimeterIndianCensusFilePath = @"C:\Users\dnyan\dnyana\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CsvFiles\DelimiterIndiaStateCensusData.csv";
        static readonly string wrongIndianStateCensusFilePath = @"C:\Users\dnyan\dnyana\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CsvFiles\IndiaData.csv";
        static readonly string wrongIndianStateCensusFileType = @"C:\Users\dnyan\dnyana\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CsvFiles\IndiaStateCensusData.txt";
        

        IndianStateCensusAnalyser.POCO.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecords;


        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensusAnalyser.POCO.CensusAnalyser();
            totalRecords = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecords = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecords.Count);
        }

        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }

        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenNotProper_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER, censusException.eType);
        }

        [Test]
        public void GivenIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
    }
}