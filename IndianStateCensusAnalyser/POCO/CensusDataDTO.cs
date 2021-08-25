using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.POCO
{
    public class CensusDataDTO
    {
        public string state;
        public long population;
        public long area;
        public long density;

        public CensusDataDTO(string state,string population,string area,string density)
        {
            this.state = state;
            this.population = Convert.ToInt32(population);
            this.area = Convert.ToInt32(area); ;
            this.density= Convert.ToInt32(density);
        }
    }
}
