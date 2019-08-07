using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.API.Models.Profiles;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.API.Models
{
    public partial class ClassMapper : IMapper<Class, ClassModel>
    {
        public LessonListMapper lessonListMapper = new LessonListMapper();
        public UsersMapper usersMapper = new UsersMapper();
        public ClassListMapper classListMapper = new ClassListMapper();
        public SchoolMapper schoolMapper = new SchoolMapper();
        public UsersClassListMapper usersClassListMapper = new UsersClassListMapper();


        public Class dtoToEntity(ClassModel dto)
        {
            if (dto != null)
            {
                Class classEntity = new Class()
                {
                    ClassId = dto.ClassId,
                    ClassNo = dto.ClassNo,
                    ClassYear = dto.ClassYear,
                    CreatedAt = dto.CreatedAt,
                    Id = dto.ClassId,
                    Lesson = lessonListMapper.dtoToEntityCollection(dto.Lesson),
                    ModifiedAt = dto.ModifiedAt,
                    School = schoolMapper.dtoToEntity(dto.School),
                    SchoolId = dto.SchoolId,
                    User = usersMapper.dtoToEntity(dto.User),
                    UserId = dto.UserId,
                    UsersClass = usersClassListMapper.dtoToEntityCollection(dto.UsersClass)
                };
                return classEntity;
            }

            return null;
        }

        public ClassModel EntityToDTO(Class entity)
        {
            if (entity != null)
            {
                ClassModel classModel = new ClassModel()
                {
                    ClassId = entity.ClassId,
                    ClassNo = entity.ClassNo,
                    ClassYear = entity.ClassYear,
                    CreatedAt = entity.CreatedAt,
                    Lesson = lessonListMapper.entityToDTO(entity.Lesson),
                    ModifiedAt = entity.ModifiedAt,
                    School = schoolMapper.EntityToDTO(entity.School),
                    SchoolId = entity.SchoolId,
                    User = usersMapper.EntityToDTO(entity.User),
                    UserId = entity.UserId,
                    UsersClass = usersClassListMapper.entityToDTO(entity.UsersClass)
                };

                return classModel;
            }
            return null;
            
        }
    }
}
