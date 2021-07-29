using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusProblem
{
    public class StateCensusAnalyserException :Exception
    {
        public ExceptionType exception;
        //Enum for group pf constants exception types
        public enum ExceptionType
        {
            FILE_NOT_FOUND,INVALID_FILE_TYPE,INVALID_HEADER,INVALID_DELIMITER,NO_SUCH_COUNTRY
        }

        //constructor for exception class
        public StateCensusAnalyserException(ExceptionType exception, string message) : base(message) => this.exception = exception;
    }
}
