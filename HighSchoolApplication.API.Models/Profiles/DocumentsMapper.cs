using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.API.Models
{
    public partial class DocumentsMapper : IMapper<Documents, DocumentsModel>
    {
        DocumentCategoryMapper documentCategoryMapper = new DocumentCategoryMapper();
        SubjectsMapper subjectsMapper = new SubjectsMapper();
        UsersMapper usersMapper = new UsersMapper();

        public Documents dtoToEntity(DocumentsModel dto)
        {
            if (dto != null)
            {
                Documents documentsEntity = new Documents()
                {
                    Id = dto.DocumentId,
                    CreatedAt = dto.CreatedAt,
                    DocumentCategory = documentCategoryMapper.dtoToEntity(dto.DocumentCategory),
                    DocumentCategoryId = dto.DocumentCategory.DocumentCategoryId,
                    DocumentDescription = dto.DocumentDescription,
                    DocumentUrl = dto.DocumentUrl,
                    ModifiedAt = dto.ModifiedAt,
                    Subject = subjectsMapper.dtoToEntity(dto.Subject),
                    SubjectId = dto.Subject.SubjectId,
                    User = usersMapper.dtoToEntity(dto.User),
                    UserId = dto.User.UserId
                };

                return documentsEntity;

            }
            return null;
        }

        public DocumentsModel EntityToDTO(Documents entity)
        {
            if (entity != null)
            {
                DocumentsModel documentsModel = new DocumentsModel()
                {
                    DocumentId = entity.Id,
                    CreatedAt = entity.CreatedAt,
                    DocumentCategory = documentCategoryMapper.EntityToDTO(entity.DocumentCategory),
                    DocumentDescription = entity.DocumentDescription,
                    DocumentUrl = entity.DocumentUrl,
                    ModifiedAt = entity.ModifiedAt,
                    Subject = subjectsMapper.EntityToDTO(entity.Subject),
                    User = usersMapper.EntityToDTO(entity.User)
                };

                return documentsModel;
            }
            return null;
        }
    }
}
