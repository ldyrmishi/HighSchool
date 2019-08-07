using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Models
{
    public interface IMapper<ENTITY,DTO>
    {
         DTO EntityToDTO(ENTITY entity);
         ENTITY dtoToEntity(DTO dto);
    }
}
