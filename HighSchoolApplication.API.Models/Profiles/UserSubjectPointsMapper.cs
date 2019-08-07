using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.API.Models
{
    public partial class UserSubjectPointsMapper : IMapper<UsersSubjectPoints, UsersSubjectPointsModel>
    {
        UsersMapper usersMapper = new UsersMapper();
        SubjectPointsMapper subjectPointsMapper = new SubjectPointsMapper();

        public UsersSubjectPoints dtoToEntity(UsersSubjectPointsModel dto)
        {
            if (dto != null)
            {
                UsersSubjectPoints usersSubjectPointsEntity = new UsersSubjectPoints()
                {
                    CreatedAt = dto.CreatedAt,
                    Grade = dto.Grade,
                    ModifiedAt = dto.ModifiedAt,
                    SubjectPoints = subjectPointsMapper.dtoToEntity(dto.SubjectPoints),
                    SubjectPointsId = dto.SubjectPoints.SubjectPointsId,
                    Id = dto.UserSubjectPointsId,
                    User = usersMapper.dtoToEntity(dto.User),
                    UserId = dto.User.UserId,
                    UserSubjectPointsId = dto.UserSubjectPointsId
                };

                return usersSubjectPointsEntity;

            }
            return null;
        }

        public UsersSubjectPointsModel EntityToDTO(UsersSubjectPoints entity)
        {
            if (entity != null)
            {
                UsersSubjectPointsModel usersSubjectPointsModel = new UsersSubjectPointsModel()
                {
                    CreatedAt = entity.CreatedAt,
                    Grade = entity.Grade,
                    ModifiedAt = entity.ModifiedAt,
                    SubjectPoints = subjectPointsMapper.EntityToDTO(entity.SubjectPoints),
                    User = usersMapper.EntityToDTO(entity.User),
                    UserSubjectPointsId = entity.UserSubjectPointsId
                };

                return usersSubjectPointsModel;
            }
            return null;
        }
    }
}
