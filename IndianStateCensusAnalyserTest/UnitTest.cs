using IndianStateCensusAnalyser.DTO;
using IndianStateCensusAnalyser.POCO;
using NUnit.Framework;
using System.Collections.Generic;

namespace IndianStateCensusAnalyserTest
{
    public class Tests
    {
        static readonly string indianStateCodeHeaders = "SrNo,StateName,TIN,StateCode";
        static readonly string wrongIndianStateCensusFilePath = @"C:\Users\dnyan\dnyana\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CsvFiles\IndiaData.csv";
        static readonly string indianStateCodeFilePath = @"C:\Users\dnyan\dnyana\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CsvFiles\IndiaStateCode.csv";
        static readonly string wrongIndianStateCodeFileType = @"C:\Users\dnyan\dnyana\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CsvFiles\IndiaStateCode.txt";
        static readonly string delimeterIndianStateCodeFilePath = @"C:\Users\dnyan\dnyana\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CsvFiles\DelimiterIndiaStateCode.csv";
        static readonly string wrongHeaderStateCodeFilePath = @"C:\Users\dnyan\dnyana\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CsvFiles\WrongIndiaStateCode.csv";


        IndianStateCensusAnalyser.POCO.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> StateRecords;


        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensusAnalyser.POCO.CensusAnalyser();
            StateRecords = new Dictionary<string, CensusDTO>();

        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            StateRecords = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, StateRecords.Count);
        }

        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenNotProper_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER, stateException.eType);
        }

        [Test]
        public void GivenIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}