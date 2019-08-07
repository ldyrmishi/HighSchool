using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.API.Models.Profiles;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.API.Models
{
    public partial class LessonMapper : IMapper<Lesson, LessonModel>
    {
        AbsentsListMapper absentsListMapper = new AbsentsListMapper();
        ClassMapper classMapper = new ClassMapper();
        DiaryMapper diaryMapper = new DiaryMapper();
        SubjectsMapper subjectsMapper = new SubjectsMapper();

        public Lesson dtoToEntity(LessonModel dto)
        {
            if (dto != null)
            {
                Lesson lessonEntity = new Lesson()
                {
                    Absents = absentsListMapper.dtoToEntityCollection(dto.Absents),
                    Class = classMapper.dtoToEntity(dto.Class),
                    ClassId = dto.Class.ClassId,
                    CreatedAt = dto.CreatedAt,
                    Description = dto.Description,
                    Diary = diaryMapper.dtoToEntity(dto.Diary),
                    DiaryId = dto.Diary.DiaryId,
                    EndDateTime = dto.EndDateTime,
                    Id = dto.LessonId,
                    LessonId = dto.LessonId,
                    ModifiedAt = dto.ModifiedAt,
                    StartDateTime = dto.StartDateTime,
                    Subject = subjectsMapper.dtoToEntity(dto.Subject),
                    SubjectId = dto.Subject.SubjectId
                };

                return lessonEntity;

            }
            return null;
        }

        public LessonModel EntityToDTO(Lesson entity)
        {
            if (entity != null)
            {
                LessonModel lessonModel = new LessonModel()
                {
                    Absents = absentsListMapper.entityToDTO(entity.Absents),
                    Class = classMapper.EntityToDTO(entity.Class),
                    CreatedAt = entity.CreatedAt,
                    Description = entity.Description,
                    Diary = diaryMapper.EntityToDTO(entity.Diary),
                    EndDateTime = entity.EndDateTime,
                    LessonId = entity.LessonId,
                    ModifiedAt = entity.ModifiedAt,
                    StartDateTime = entity.StartDateTime,
                    Subject = subjectsMapper.EntityToDTO(entity.Subject),
                };

                return lessonModel;
            }
            return null;
        }
    }
}
