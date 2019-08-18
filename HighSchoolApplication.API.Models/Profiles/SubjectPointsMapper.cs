using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.API.Models.Profiles;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.API.Models
{
    public partial class SubjectPointsMapper : IMapper<SubjectPoints, SubjectPointsModel>
    {
        SubjectsMapper subjectsMapper = new SubjectsMapper();
        UserSubjectPointsListMapper userSubjectPointsListMapper = new UserSubjectPointsListMapper();

        public SubjectPoints dtoToEntity(SubjectPointsModel dto)
        {
            if (dto != null)
            {
                SubjectPoints subjectPointsEntity = new SubjectPoints()
                {
                    CreatedAt = dto.CreatedAt,
                    Id = dto.SubjectPointsId,
                    MarkType = dto.MarkType,
                    ModifiedAt = dto.ModifiedAt,
                    Points = dto.Points,
                    PointsDate = dto.PointsDate,
                    PointsReason = dto.PointsReason,
                    Subject = subjectsMapper.dtoToEntity(dto.Subject),
                    SubjectId = dto.Subject.SubjectId,
                    UsersSubjectPoints = userSubjectPointsListMapper.dtoToEntityCollection(dto.UsersSubjectPoints)
                };

                return subjectPointsEntity;
            }
            return null;
        }

        public SubjectPointsModel EntityToDTO(SubjectPoints entity)
        {
            if (entity != null)
            {
                SubjectPointsModel subjectPointsModel = new SubjectPointsModel()
                {
                    CreatedAt = entity.CreatedAt,
                    MarkType = entity.MarkType,
                    ModifiedAt = entity.ModifiedAt,
                    Points = entity.Points,
                    PointsDate = entity.PointsDate,
                    PointsReason = entity.PointsReason,
                    Subject = subjectsMapper.EntityToDTO(entity.Subject),
                    SubjectPointsId = entity.Id,
                    UsersSubjectPoints = userSubjectPointsListMapper.entityToDTO(entity.UsersSubjectPoints)
                };

                return subjectPointsModel;
            }
            return null;
        }
    }
}
