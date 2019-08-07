using System;
using System.Collections.Generic;
using System.Text;

namespace HighSchoolApplication.API.Models.Profiles
{
    public abstract class ListMapper<ENTITY, DTO>
    {
        private IMapper<ENTITY, DTO> mapper;

        public List<DTO> entityToDTO(List<ENTITY> entities)
        {
            List<DTO> objects = new List<DTO>();
            if (entities != null)
            {
                entities.ForEach(entity =>
                {
                    objects.Add(mapper.EntityToDTO(entity));
                });
            }

            return objects;
        }

        public List<ENTITY> dtoToEntity(List<DTO> objects)
        {
            List<ENTITY> entities = new List<ENTITY>();
            if (objects != null)
            {
                objects.ForEach(x =>
                {
                    entities.Add(mapper.dtoToEntity(x));
                });
            }

            return entities;
        }

        public ICollection<DTO> entityToDTO(ICollection<ENTITY> entities)
        {
            List<DTO> objects = new List<DTO>();
            if (entities != null)
            {
                foreach(var item in entities)
                {
                    objects.Add(mapper.EntityToDTO(item));
                }
            }

            return objects;
        }

        public ICollection<ENTITY> dtoToEntityCollection(ICollection<DTO> objects)
        {
            List<ENTITY> entities = new List<ENTITY>();
            if (objects != null)
            {
                foreach(var item in objects)
                {
                    entities.Add(mapper.dtoToEntity(item));
                }
            }
            return entities;
        }
    }
}
