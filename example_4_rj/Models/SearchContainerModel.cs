using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace example_4_rj.Models
{
    public class SearchContainerModel
    {
        public SearchContainerModel(List<ObitModel> obits, List<CensusModel> censuses, List<NaturalModel> nat)
        {
            obit = obits;
            census = censuses;
            nattyice = nat;
        }
        public List<ObitModel> obit { get; set; }
        public List<CensusModel> census { get; set; }
        public List<NaturalModel> nattyice { get; set; }
    }
}