using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.API.Models.Profiles;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.API.Models
{
    public partial class RolesMapper : IMapper<Roles, RolesModel>
    {
        UsersListMapper usersListMapper = new UsersListMapper();
        public Roles dtoToEntity(RolesModel dto)
        {
            if (dto != null)
            {
                Roles rolesEntity = new Roles()
                {
                    CreatedAt = dto.CreatedAt,
                    Id = dto.RoleId,
                    ModifiedAt = dto.ModifiedAt,
                    RoleDescription = dto.RoleDescription,
                    RoleId = dto.RoleId,
                    Users = usersListMapper.dtoToEntityCollection(dto.Users)
                };

                return rolesEntity;
            }
            return null;
        }

        public RolesModel EntityToDTO(Roles entity)
        {
            if (entity != null)
            {
                RolesModel rolesModel = new RolesModel()
                {
                    CreatedAt = entity.CreatedAt,
                    ModifiedAt = entity.ModifiedAt,
                    RoleDescription = entity.RoleDescription,
                    RoleId = entity.RoleId,
                    Users = usersListMapper.entityToDTO(entity.Users)
                };

                return rolesModel;
            }
            return null;
        }
    }
}
