using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Profiles
{
    public interface Mapper<ENTITY,DTO>
    {
         DTO EntityToDTO(ENTITY entity);
         ENTITY dtoToEntity(DTO dto);
    }
}
