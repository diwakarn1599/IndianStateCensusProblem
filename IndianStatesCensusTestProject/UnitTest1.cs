using Microsoft.VisualStudio.TestTools.UnitTesting;
using IndianStateCensusProblem.DataDAO;
using IndianStateCensusProblem.DTO;
using IndianStateCensusProblem;
using System.Collections.Generic;
namespace IndianStatesCensusTestProject
{
    [TestClass]
    public class UnitTest1
    {

        //AAA Methodlogy
        //Arrange
        //List of file paths
        string stateCensusFilePath = @"C:\Users\diwakar.n\source\repos\IndianStateCensusProblem\IndianStateCensusProblem\CsvFiles\CensusData.csv";
        string wrongExtensionFilePath = @"C:\Users\diwakar.n\source\repos\IndianStateCensusProblem\IndianStateCensusProblem\CSVAdapterFactory.cs";
        string wrongFilePath = @"C:\Users\diwakar.n\source\repos\IndianStateCensusProblem\IndianStateCensusProblem\CsvFiles\Census.csv";
        string wrongheadersFilePath = @"C:\Users\diwakar.n\source\repos\IndianStateCensusProblem\IndianStateCensusProblem\CsvFiles\WrongHeaders.csv";
        string wrongDelimitersFilePath = @"C:\Users\diwakar.n\source\repos\IndianStateCensusProblem\IndianStateCensusProblem\CsvFiles\WrongDelimiters.csv";
        //Object for csv adapter class
        CSVAdapterFactory csvAdapter = default;
        Dictionary<string, CensusDTO> allStateRecords;
        [TestInitialize]
        public void Setup()
        {
            allStateRecords = new Dictionary<string, CensusDTO>();
            csvAdapter = new CSVAdapterFactory();
        }
        /// <summary>
        /// Uc1 - Tc-1.1 - Test for number of records matches
        /// </summary>
        [TestMethod]
        public void TestNumberOfRecordMatches()
        {
            allStateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusFilePath, "State,Population,Area,Density");
            int expected = 6, actual = allStateRecords.Count;
            Assert.AreEqual(actual,expected);
        }
        /// <summary>
        ///  Uc1 - Tc-1.2 - Test for Wrong File Extension
        /// </summary>
        [TestMethod]
        public void TestForWrongFileExtension()
        {
            try
            {
                allStateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongExtensionFilePath, "State,Population,Area,Density");
                
                
            }
            catch(StateCensusAnalyserException ex)
            {
                string expected = "Invalid file extension";
            
                Assert.AreEqual(ex.Message, expected); 
            }
           
        }
        /// <summary>
        /// Uc1 - Tc-1.3 - Test for File not found exception
        /// </summary>
        [TestMethod]
        public void TestForFileNotFound()
        {
            try
            {
                allStateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongFilePath, "State,Population,Area,Density");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "File not found";

                Assert.AreEqual(ex.Message, expected);
            }

        }
        /// <summary>
        /// Uc1 - Tc-1.4 - Test for wrong headers exception
        /// </summary>
        [TestMethod]
        public void TestForWrongHeaders()
        {
            try
            {
                allStateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongheadersFilePath, "State,Population,Area,Density");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "Invalid file headers";

                Assert.AreEqual(ex.Message, expected);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestForWrongDelimiters()
        {
            try
            {
                allStateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimitersFilePath, "State,Population,Area,Density");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "Invalid Delimiter";

                Assert.AreEqual(ex.Message, expected);
            }

        }
    }
}
