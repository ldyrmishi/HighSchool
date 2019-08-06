using HighSchoolApplication.API.Models;
using HighSchoolApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Profiles
{
    public class AbsentsMapper : Mapper<Absents, AbsentsModel>
    {
        public Absents dtoToEntity(AbsentsModel dto)
        {
            throw new NotImplementedException();
        }

        public AbsentsModel EntityToDTO(Absents entity)
        {
            throw new NotImplementedException();
        }
    }
}
