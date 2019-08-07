using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.API.Models.Profiles;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.API.Models
{
    public partial class SchoolMapper : IMapper<School, SchoolModel>
    {
        ClassListMapper classListMapper = new ClassListMapper();
        FinancesListMapper financesListMapper = new FinancesListMapper();
        UsersListMapper usersListMapper = new UsersListMapper();

        public School dtoToEntity(SchoolModel dto)
        {
            if (dto != null)
            {
                School schoolEntity = new School()
                {
                    Address = dto.Address,
                    City = dto.City,
                    Class = classListMapper.dtoToEntityCollection(dto.Class),
                    CreatedAt = dto.CreatedAt,
                    Finances =financesListMapper.dtoToEntityCollection(dto.Finances),
                    Id = dto.SchoolId,
                    Logo = dto.Logo,
                    ModifiedAt = dto.ModifiedAt,
                    Name = dto.Name,
                    PhoneNumber = dto.PhoneNumber,
                    SchoolId = dto.SchoolId,
                    Users = usersListMapper.dtoToEntityCollection(dto.Users)
                };

                return schoolEntity;
            }
            return null;
        }

        public SchoolModel EntityToDTO(School entity)
        {
            if (entity != null)
            {
                SchoolModel schoolModel = new SchoolModel()
                {
                    Address = entity.Address,
                    City = entity.City,
                    Class = classListMapper.entityToDTO(entity.Class),
                    CreatedAt = entity.CreatedAt,
                    Finances = financesListMapper.entityToDTO(entity.Finances),
                    Logo = entity.Logo,
                    ModifiedAt = entity.ModifiedAt,
                    Name = entity.Name,
                    PhoneNumber = entity.PhoneNumber,
                    SchoolId = entity.SchoolId,
                    Users = usersListMapper.entityToDTO(entity.Users)
                };

                return schoolModel;

            }
            return null;
        }
    }
}
