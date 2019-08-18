using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.API.Models.Profiles;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.API.Models
{
    public partial class SubjectsMapper : IMapper<Subjects, SubjectModel>
    {
        DiaryListMapper diaryListMapper = new DiaryListMapper();
        DocumentsListMapper documentsListMapper = new DocumentsListMapper();
        FinalExamsListMapper finalExamsListMapper = new FinalExamsListMapper();
        LessonListMapper lessonListMapper = new LessonListMapper();
        SubjectPointsListMapper subjectPointsListMapper = new SubjectPointsListMapper();

        public Subjects dtoToEntity(SubjectModel dto)
        {
            if (dto != null)
            {
                Subjects subjectsEntity = new Subjects()
                {
                    CreatedAt = dto.CreatedAt,
                    Diary = diaryListMapper.dtoToEntityCollection(dto.Diary),
                    Documents = documentsListMapper.dtoToEntityCollection(dto.Documents),
                    FinalExams = finalExamsListMapper.dtoToEntityCollection(dto.FinalExams),
                    Id = dto.SubjectId,
                    Lesson = lessonListMapper.dtoToEntityCollection(dto.Lesson),
                    ModifiedAt = dto.ModifiedAt,
                    MaxPoints = dto.MaxPoints,
                    SubjectDescription = dto.SubjectDescription,
                    SubjectPoints = subjectPointsListMapper.dtoToEntityCollection(dto.SubjectPoints),
                    SubjectTitle = dto.SubjectTitle,
                    Term = dto.Term
                };

                return subjectsEntity;
            }
            return null;
        }

        public SubjectModel EntityToDTO(Subjects entity)
        {
            if (entity != null)
            {
                SubjectModel subjectsModel = new SubjectModel()
                {
                    CreatedAt = entity.CreatedAt,
                    Diary = diaryListMapper.entityToDTO(entity.Diary),
                    Documents = documentsListMapper.entityToDTO(entity.Documents),
                    FinalExams = finalExamsListMapper.entityToDTO(entity.FinalExams),
                    Lesson = lessonListMapper.entityToDTO(entity.Lesson),
                    ModifiedAt = entity.ModifiedAt,
                    MaxPoints = entity.MaxPoints,
                    SubjectDescription = entity.SubjectDescription,
                    SubjectId = entity.Id,
                    SubjectPoints = subjectPointsListMapper.entityToDTO(entity.SubjectPoints),
                    SubjectTitle = entity.SubjectTitle,
                    Term = entity.Term
                };

                return subjectsModel;
            }
            return null;
        }
    }
}
