using ITVerket.FinalCut.Domain.Entities.Enum;

namespace ITVerket.FinalCut.Domain.Entities
{
    public class Search
    {
        public SearchCriteria SearchCriteria { get; set; }
        public string SearchText { get; set; }
    }
}