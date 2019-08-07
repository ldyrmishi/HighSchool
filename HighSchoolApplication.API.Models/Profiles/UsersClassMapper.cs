using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.API.Models
{
    public partial class UsersClassMapper : IMapper<UsersClass, UsersClassModel>
    {
        ClassMapper classMapper = new ClassMapper();
        UsersMapper usersMapper = new UsersMapper();

        public UsersClass dtoToEntity(UsersClassModel dto)
        {
            if (dto != null)
            {
                UsersClass usersClassEntity = new UsersClass()
                {
                    Class = classMapper.dtoToEntity(dto.Class),
                    ClassId = dto.Class.ClassId,
                    CreatedAt = dto.CreatedAt,
                    ModifiedAt = dto.ModifiedAt,
                    StudentId = dto.StudentId,
                    User = usersMapper.dtoToEntity(dto.User),
                    UserId = dto.User.UserId
                };

                return usersClassEntity;
            }
            return null;
        }

        public UsersClassModel EntityToDTO(UsersClass entity)
        {
            if (entity != null)
            {
                UsersClassModel usersClassModel = new UsersClassModel()
                {
                    Class = classMapper.EntityToDTO(entity.Class),
                    CreatedAt = entity.CreatedAt,
                    ModifiedAt = entity.ModifiedAt,
                    StudentId = entity.StudentId,
                    User = usersMapper.EntityToDTO(entity.User)
                };

                return usersClassModel;
            }
            return null;
        }
    }
}
