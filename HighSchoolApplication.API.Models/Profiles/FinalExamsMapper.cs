using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.API.Models
{
    public partial class FinalExamsMapper : IMapper<FinalExams, FinalExamsModel>
    {
        SubjectsMapper subjectsMapper = new SubjectsMapper();
        UsersMapper usersMapper = new UsersMapper();

        public FinalExams dtoToEntity(FinalExamsModel dto)
        {
            if (dto != null)
            {
                FinalExams finalExamsEntity = new FinalExams()
                {
                    CreatedAt =  dto.CreatedAt,
                    Id = dto.FinalExamId,
                    Grade = dto.Grade,
                    MaxPoints = dto.MaxPoints,
                    ModifiedAt = dto.ModifiedAt,
                    PointsDate = dto.PointsDate,
                    Subject = subjectsMapper.dtoToEntity(dto.Subject),
                    SubjectId = dto.Subject.SubjectId,
                    User = usersMapper.dtoToEntity(dto.User),
                    UserId = dto.User.UserId
                };

                return finalExamsEntity;
            }
            return null;
        }

        public FinalExamsModel EntityToDTO(FinalExams entity)
        {
            if (entity != null)
            {
                FinalExamsModel finalExamsModel = new FinalExamsModel()
                {
                    CreatedAt = entity.CreatedAt,
                    FinalExamId = entity.Id,
                    Grade = entity.Grade,
                    MaxPoints = entity.MaxPoints,
                    ModifiedAt = entity.ModifiedAt,
                    PointsDate = entity.PointsDate,
                    Subject = subjectsMapper.EntityToDTO(entity.Subject),
                    User = usersMapper.EntityToDTO(entity.User)
                };

                return finalExamsModel;
            }
            return null;
        }
    }
}
