using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.API.Models.Profiles;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.API.Models
{
    public partial class UsersMapper : IMapper<Users, UsersModel>
    {
        AbsentsListMapper absentsListMapper = new AbsentsListMapper();
        AddressMapper addressMapper = new AddressMapper();
        ClassListMapper classListMapper = new ClassListMapper();
        DiaryListMapper diaryListMapper = new DiaryListMapper();
        DocumentsListMapper documentsListMapper = new DocumentsListMapper();
        FinalExamsListMapper finalExamsListMapper = new FinalExamsListMapper();
        RolesMapper rolesMapper = new RolesMapper();
        SchoolMapper schoolMapper = new SchoolMapper();
        UsersStatusMapper usersStatusMapper = new UsersStatusMapper();
        UsersClassListMapper usersClassListMapper = new UsersClassListMapper();
        UserSubjectPointsListMapper userSubjectPointsListMapper = new UserSubjectPointsListMapper();

        public Users dtoToEntity(UsersModel dto)
        {
            if (dto != null)
            {
                Users usersEntity = new Users()
                {
                    Absents = absentsListMapper.dtoToEntityCollection(dto.Absents),
                    Address = addressMapper.dtoToEntity(dto.Address),
                    AddressId = dto.Address.AddressId,
                    Birthdate = dto.Birthdate,
                    Class = classListMapper.dtoToEntityCollection(dto.Class),
                    CreatedAt = dto.CreatedAt,
                    IsActive = dto.IsActive,
                    ModifiedAt = dto.ModifiedAt,
                    NrAmze = dto.NrAmze,
                    ConfirmPassword = dto.ConfirmPassword,
                    Diary = diaryListMapper.dtoToEntityCollection(dto.Diary),
                    Documents = documentsListMapper.dtoToEntityCollection(dto.Documents),
                    Email = dto.Email,
                    FinalExams = finalExamsListMapper.dtoToEntityCollection(dto.FinalExams),
                    Firstname = dto.Firstname,
                    Gender = dto.Gender,
                    Id = dto.UserId,
                    Lastname = dto.Lastname,
                    Notes =dto.Notes,
                    Password = dto.Password,
                    PhoneNumber = dto.PhoneNumber,
                    RegistrationDate = dto.RegistrationDate,
                    Role = rolesMapper.dtoToEntity(dto.Role),
                    RoleId = dto.Role.RoleId,
                    School = schoolMapper.dtoToEntity(dto.School),
                    SchoolId = dto.School.SchoolId,
                    Status  = usersStatusMapper.dtoToEntity(dto.Status),
                    StatusId = dto.Status.UsersStatusId,
                    UserId = dto.UserId,
                    Username = dto.Username,
                    UsersClass = usersClassListMapper.dtoToEntityCollection(dto.UsersClass),
                    UsersSubjectPoints = userSubjectPointsListMapper.dtoToEntityCollection(dto.UsersSubjectPoints)
                };
                return usersEntity;
            }
            return null;
        }

        public UsersModel EntityToDTO(Users entity)
        {
            if (entity != null)
            {
                UsersModel usersEntity = new UsersModel()
                {
                    Absents = absentsListMapper.entityToDTO(entity.Absents),
                    Address = addressMapper.EntityToDTO(entity.Address),
                    Birthdate = entity.Birthdate,
                    Class = classListMapper.entityToDTO(entity.Class),
                    CreatedAt = entity.CreatedAt,
                    IsActive = entity.IsActive,
                    ModifiedAt = entity.ModifiedAt,
                    NrAmze = entity.NrAmze,
                    ConfirmPassword = entity.ConfirmPassword,
                    Diary = diaryListMapper.entityToDTO(entity.Diary),
                    Documents = documentsListMapper.entityToDTO(entity.Documents),
                    Email = entity.Email,
                    FinalExams = finalExamsListMapper.entityToDTO(entity.FinalExams),
                    Firstname = entity.Firstname,
                    Gender = entity.Gender,
                    Lastname = entity.Lastname,
                    Notes = entity.Notes,
                    Password = entity.Password,
                    PhoneNumber = entity.PhoneNumber,
                    RegistrationDate = entity.RegistrationDate,
                    Role = rolesMapper.EntityToDTO(entity.Role),
                    School = schoolMapper.EntityToDTO(entity.School),
                    Status = usersStatusMapper.EntityToDTO(entity.Status),
                    UserId = entity.UserId,
                    Username = entity.Username,
                    UsersClass = usersClassListMapper.entityToDTO(entity.UsersClass),
                    UsersSubjectPoints = userSubjectPointsListMapper.entityToDTO(entity.UsersSubjectPoints)
                };
                return usersEntity;
            }
            return null;
        }
    }
}
