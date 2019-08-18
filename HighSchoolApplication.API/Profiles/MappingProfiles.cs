using AutoMapper;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Infrastructure.Models;


namespace HighSchoolApplication.API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Roles, RolesModel>().ReverseMap();
            CreateMap<Absents, AbsentsModel>().ReverseMap();
            CreateMap<Address, AddressModel>().ReverseMap();
            CreateMap<Class, ClassModel>().ReverseMap();
            CreateMap<Diary, DiaryModel>().ReverseMap();
            CreateMap<DocumentCategory, DocumentCategoryModel>().ReverseMap();
            CreateMap<Documents, DocumentsModel>().ReverseMap();
            CreateMap<FinalExams, FinalExamsModel>().ReverseMap();
            CreateMap<Finances, FinancesModel>().ReverseMap();
            CreateMap<Lesson, LessonModel>().ReverseMap();
            CreateMap<School, SchoolModel>().ReverseMap();
            CreateMap<Users, UsersModel>().ReverseMap();
            CreateMap<SubjectPoints, SubjectPointsModel>().ReverseMap();
            CreateMap<Subjects, SubjectModel>().ReverseMap();
            CreateMap<UsersClass, UsersClassModel>().ReverseMap();
            CreateMap<UsersStatus, UsersStatusModel>().ReverseMap();
            CreateMap<UsersSubjectPoints, UsersSubjectPointsModel>().ReverseMap();
        }
    }
}
