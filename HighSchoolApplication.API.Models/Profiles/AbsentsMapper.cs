using HighSchoolApplication.API.Models.Profiles;
using HighSchoolApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Models
{
    public partial class AbsentsMapper : IMapper<Absents, AbsentsModel>
    {
        public LessonMapper lessonMapper = new LessonMapper();
        public UsersMapper usersMapper = new UsersMapper();

        public Absents dtoToEntity(AbsentsModel dto)
        {
            if (dto != null)
            {
                var lesson = lessonMapper.dtoToEntity(dto.Lesson);

                Absents absentsEntity = new Absents();
                absentsEntity.AbsentDate = dto.AbsentDate;
                absentsEntity.Id = dto.AbsentsId;
                absentsEntity.CreatedAt = dto.CreatedAt;
                absentsEntity.ModifiedAt = dto.ModifiedAt;
                absentsEntity.Id = dto.AbsentsId;
                absentsEntity.IsInClass = dto.IsInClass;
                absentsEntity.IsJustificated = dto.IsJustificated;
                absentsEntity.Lesson = lesson;
                absentsEntity.LessonId = lesson.Id;
                absentsEntity.Reason = dto.Reason;
                absentsEntity.User = usersMapper.dtoToEntity(dto.User);

                return absentsEntity;
            }
            return null;
        }

        public AbsentsModel EntityToDTO(Absents entity)
        {
            if(entity != null)
            {
                AbsentsModel absentsModel = new AbsentsModel();
                absentsModel.AbsentDate = entity.AbsentDate;
                absentsModel.AbsentsId = entity.Id;
                absentsModel.CreatedAt = entity.CreatedAt;
                absentsModel.IsInClass = entity.IsInClass;
                absentsModel.IsJustificated = entity.IsJustificated;
                absentsModel.Lesson = lessonMapper.EntityToDTO(entity.Lesson);
                absentsModel.LessonId = entity.LessonId;
                absentsModel.ModifiedAt = entity.ModifiedAt;
                absentsModel.Reason = entity.Reason;
                absentsModel.User = usersMapper.EntityToDTO(entity.User);
                absentsModel.UserId = entity.UserId;

                return absentsModel;
            }
            return null;
        }
    }
}
