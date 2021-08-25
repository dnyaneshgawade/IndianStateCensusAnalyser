using IndianStateCensusAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.DTO
{
    public class CensusDTO
    {
        public string state;
        public long population;
        public long area;
        public long density;
       
        public CensusDTO(CensusDataDTO stateDataDao)
        {
            this.state = stateDataDao.state;
            this.population = stateDataDao.population;
            this.area = stateDataDao.area;
            this.density = stateDataDao.density;
        }
    }
}
