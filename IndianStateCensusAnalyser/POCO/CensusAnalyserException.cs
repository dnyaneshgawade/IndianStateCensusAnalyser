using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.POCO
{
    public class CensusAnalyserException:Exception
    { 
        public ExceptionType eType;
        public enum ExceptionType
        {
            FILE_NOT_FOUND,INVALID_FILE_TYPE,INCORRECT_DELIMETER,INCORRECT_HEADER,NO_SUCH_COUNTRY
        }
        public CensusAnalyserException(string message,ExceptionType exceptionType) : base(message)
        {
            this.eType = exceptionType;
        }
    }
}
