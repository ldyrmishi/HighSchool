using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.API.Models.Profiles;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.API.Models
{
    public partial class DiaryMapper : IMapper<Diary, DiaryModel>
    {
        public LessonListMapper lessonListMapper = new LessonListMapper();
        public UsersMapper usersMapper = new UsersMapper();
        public SubjectsMapper subjectsMapper = new SubjectsMapper();

        public Diary dtoToEntity(DiaryModel dto)
        {

            if( dto != null)
            {
                Diary diaryEntity = new Diary()
                {
                    Id = dto.DiaryId,
                    CreatedAt = dto.CreatedAt,
                    Description = dto.Description,
                    DiaryDate = dto.DiaryDate,
                    Lesson = lessonListMapper.dtoToEntityCollection(dto.Lesson),
                    ModifiedAt = dto.ModifiedAt,
                    Subject = subjectsMapper.dtoToEntity(dto.Subject),
                    SubjectId = subjectsMapper.dtoToEntity(dto.Subject).Id,
                    Title = dto.Title,
                    User = usersMapper.dtoToEntity(dto.User),
                    UserId = usersMapper.dtoToEntity(dto.User).Id
                };

                return diaryEntity;

            }
            return null;
        }

        public DiaryModel EntityToDTO(Diary entity)
        {
            if (entity != null)
            {
                DiaryModel diaryModel = new DiaryModel()
                {
                    DiaryId = entity.Id,
                    CreatedAt = entity.CreatedAt,
                    Description = entity.Description,
                    DiaryDate = entity.DiaryDate,
                    Lesson = lessonListMapper.entityToDTO(entity.Lesson),
                    ModifiedAt = entity.ModifiedAt,
                    Subject = subjectsMapper.EntityToDTO(entity.Subject),
                    Title = entity.Title,
                    User = usersMapper.EntityToDTO(entity.User)
                };

                return diaryModel;
            }
            return null;
        }
    }
}
