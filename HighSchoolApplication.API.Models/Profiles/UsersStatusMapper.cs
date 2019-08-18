using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.API.Models.Profiles;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.API.Models
{
    public partial class UsersStatusMapper : IMapper<UsersStatus, UsersStatusModel>
    {
        UsersListMapper usersListMapper = new UsersListMapper();

        public UsersStatus dtoToEntity(UsersStatusModel dto)
        {
            if (dto != null)
            {
                UsersStatus usersStatusEntity = new UsersStatus()
                {
                    CreatedAt = dto.CreatedAt,
                    Id = dto.UsersStatusId,
                    ModifiedAt = dto.ModifiedAt,
                    Status = dto.Status,
                    Users = usersListMapper.dtoToEntityCollection(dto.Users),
                };

                return usersStatusEntity;
            }
            return null;
        }

        public UsersStatusModel EntityToDTO(UsersStatus entity)
        {
            if (entity != null)
            {
                UsersStatusModel usersStatusModel = new UsersStatusModel()
                {
                    CreatedAt = entity.CreatedAt,
                    ModifiedAt = entity.ModifiedAt,
                    Status = entity.Status,
                    Users = usersListMapper.entityToDTO(entity.Users),
                    UsersStatusId = entity.Id
                };

                return usersStatusModel;
            }
            return null;
        }
    }
}
