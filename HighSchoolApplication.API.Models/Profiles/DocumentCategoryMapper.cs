using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.API.Models.Profiles;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.API.Models
{
    public partial class DocumentCategoryMapper : IMapper<DocumentCategory, DocumentCategoryModel>
    {
        DocumentsListMapper documentsListMapper = new DocumentsListMapper();

        public DocumentCategory dtoToEntity(DocumentCategoryModel dto)
        {
            if (dto != null)
            {
                DocumentCategory documentCategoryEntity = new DocumentCategory()
                {
                    CreatedAt = dto.CreatedAt,
                    Description = dto.Description,
                    Documents = documentsListMapper.dtoToEntityCollection(dto.Documents),
                    Id = dto.DocumentCategoryId,
                    ModifiedAt = dto.ModifiedAt
                };

                return documentCategoryEntity;
            }
            return null;
        }

        public DocumentCategoryModel EntityToDTO(DocumentCategory entity)
        {
            if (entity != null)
            {
                DocumentCategoryModel documentCategoryModel = new DocumentCategoryModel()
                {
                    CreatedAt = entity.CreatedAt,
                    Description = entity.Description,
                    Documents = documentsListMapper.entityToDTO(entity.Documents),
                    ModifiedAt = entity.ModifiedAt
                };

                return documentCategoryModel;

            }
            return null;
        }
    }
}
