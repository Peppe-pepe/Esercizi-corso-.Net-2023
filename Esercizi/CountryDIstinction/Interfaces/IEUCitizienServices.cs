using CountryDIstinction.Classes;
using System.Diagnostics.CodeAnalysis;

namespace CountryDIstinction.Interfaces
{
    public interface IEUCitizienServices : IAdministrativeEntity
    {
        public void HNSRequest(EuID id);
        public void Wellfare();
        public void EducationalSystem(EuID id);
    }
}