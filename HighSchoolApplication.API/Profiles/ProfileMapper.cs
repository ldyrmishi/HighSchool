using AutoMapper;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Profiles
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<Absents, AbsentsModel>();
            CreateMap<Address, AddressModel>();
            CreateMap<Class, ClassModel>();
            CreateMap<Diary, DiaryModel>();
            CreateMap<DocumentCategory, DocumentCategoryModel>();
            CreateMap<Documents, DocumentsModel>();
            CreateMap<FinalExams, FinalExamsModel>();
            CreateMap<Finances, FinancesModel>();
            CreateMap<Lesson, LessonModel>();
            CreateMap<Roles, RolesModel>();
            CreateMap<School, SchoolModel>();
            CreateMap<Subjects, SubjectModel>();
            CreateMap<SubjectPoints, SubjectPointsModel>();
            CreateMap<UsersClass, UsersClassModel>();
            CreateMap<Users, UsersModel>();
            CreateMap<UsersStatus, UsersStatusModel>();
            CreateMap<UsersSubjectPoints, UsersSubjectPoints>();
        }
    }
}
