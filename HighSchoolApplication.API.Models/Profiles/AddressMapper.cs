using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models.Profiles;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.API.Models
{
    public partial class AddressMapper : IMapper<Address, AddressModel>
    {
        public UsersMapper usersMapper = new UsersMapper();
        public UsersListMapper usersListMapper = new UsersListMapper();

        public Address dtoToEntity(AddressModel dto)
        {
            if (dto != null)
            {
                Address addressEntity = new Address();
                addressEntity.Id = dto.AddressId;
                addressEntity.City = dto.City;
                addressEntity.CreatedAt = dto.CreatedAt;
                addressEntity.Id = dto.AddressId;
                addressEntity.ModifiedAt = dto.ModifiedAt;
                addressEntity.State = dto.State;
                addressEntity.StreetAddress = dto.StreetAddress;
                addressEntity.Users = usersListMapper.dtoToEntityCollection(dto.Users);
                addressEntity.ZipCode = dto.ZipCode;

                return addressEntity;
            }
            return null;
        }

        public AddressModel EntityToDTO(Address entity)
        {
            if (entity != null)
            {
                AddressModel addressModel = new AddressModel();
                addressModel.AddressId = entity.Id;
                addressModel.City = entity.City;
                addressModel.CreatedAt = entity.CreatedAt;
                addressModel.ModifiedAt = entity.ModifiedAt;
                addressModel.State = entity.State;
                addressModel.StreetAddress = entity.StreetAddress;
                addressModel.Users = usersListMapper.entityToDTO(entity.Users);
                addressModel.ZipCode = entity.ZipCode;

                return addressModel;
            }

            return null;
        }
    }
}
