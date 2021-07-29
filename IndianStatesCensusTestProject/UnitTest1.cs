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
        //List of file paths for census data
        string stateCensusFilePath = @"C:\Users\diwakar.n\source\repos\IndianStateCensusProblem\IndianStateCensusProblem\CsvFiles\CensusData.csv";
        string wrongExtensionFilePath = @"C:\Users\diwakar.n\source\repos\IndianStateCensusProblem\IndianStateCensusProblem\CSVAdapterFactory.cs";
        string wrongFilePath = @"C:\Users\diwakar.n\source\repos\IndianStateCensusProblem\IndianStateCensusProblem\CsvFiles\Census.csv";
        string wrongheadersFilePath = @"C:\Users\diwakar.n\source\repos\IndianStateCensusProblem\IndianStateCensusProblem\CsvFiles\WrongHeaders.csv";
        string wrongDelimitersFilePath = @"C:\Users\diwakar.n\source\repos\IndianStateCensusProblem\IndianStateCensusProblem\CsvFiles\WrongDelimiters.csv";
        //List of file paths for state codes
        string stateCodesFilePath = @"C:\Users\diwakar.n\source\repos\IndianStateCensusProblem\IndianStateCensusProblem\CsvFiles\StateCodes.csv";
        string stateCodeswrongExtensionFilePath = @"C:\Users\diwakar.n\source\repos\IndianStateCensusProblem\IndianStateCensusProblem\CSVAdapterFactory.cs";
        string stateCodeswrongFilePath = @"C:\Users\diwakar.n\source\repos\IndianStateCensusProblem\IndianStateCensusProblem\CsvFiles\Census.csv";
        string stateCodesWrongHeadersFilePath = @"C:\Users\diwakar.n\source\repos\IndianStateCensusProblem\IndianStateCensusProblem\CsvFiles\StateCodeWrongHeaders.csv";
        string stateCodesWrongDelimitersFilePath = @"C:\Users\diwakar.n\source\repos\IndianStateCensusProblem\IndianStateCensusProblem\CsvFiles\StateCodesWrongDelimiters.csv";
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
        /// Uc1 - Tc-1.5 - Test for wrong demlimiters
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
        //-----------------------------------------UC2-------------------------------------------------------------------
        /// <summary>
        /// Uc2 - Tc-2.1 - Test for number of records matches
        /// </summary>
        [TestMethod]
        public void TestNumberOfStateCodeRecordMatches()
        {
            allStateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodesFilePath, "serialNumber,tin,StateName,StateCode");
            int expected = 6, actual = allStateRecords.Count;
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        ///  Uc2 - Tc-2.2 - Test for Wrong File Extension
        /// </summary>
        [TestMethod]
        public void TestForStateCodeWrongFileExtension()
        {
            try
            {
                allStateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodeswrongExtensionFilePath, "serialNumber,tin,StateName,StateCode");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "Invalid file extension";

                Assert.AreEqual(ex.Message, expected);
            }

        }
        /// <summary>
        /// Uc2 - Tc-2.3 - Test for File not found exception
        /// </summary>
        [TestMethod]
        public void TestForStateCodeFileNotFound()
        {
            try
            {
                allStateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodeswrongFilePath, "serialNumber,tin,StateName,StateCode");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "File not found";

                Assert.AreEqual(ex.Message, expected);
            }

        }
        /// <summary>
        /// Uc2 - Tc-2.4 - Test for wrong headers exception
        /// </summary>
        [TestMethod]
        public void TestForStateCodeWrongHeaders()
        {
            try
            {
                allStateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodesWrongHeadersFilePath, "serialNumber,tin,StateName,StateCode");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "Invalid file headers";

                Assert.AreEqual(ex.Message, expected);
            }

        }
        /// <summary>
        /// Uc2 - Tc-2.5 - Test for wrong demlimiters
        /// </summary>
        [TestMethod]
        public void TestForStateCodeWrongDelimiters()
        {
            try
            {
                allStateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodesWrongDelimitersFilePath, "serialNumber,tin,StateName,StateCode");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "Invalid Delimiter";

                Assert.AreEqual(ex.Message, expected);
            }

        }
    }
}
