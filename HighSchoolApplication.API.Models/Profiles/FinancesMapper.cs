using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.API.Models
{
    public partial class FinancesMapper : IMapper<Finances, FinancesModel>
    {
        SchoolMapper schoolMapper = new SchoolMapper();
        public Finances dtoToEntity(FinancesModel dto)
        {
            if (dto != null)
            {
                Finances financesEntity = new Finances()
                {
                    Amount = dto.Amount,
                    CreatedAt = dto.CreatedAt,
                    Date = dto.Date,
                    Description = dto.Description,
                    FinanceId = dto.FinanceId,
                    Id = dto.FinanceId,
                    IsExpense = dto.IsExpense,
                    ModifiedAt = dto.ModifiedAt,
                    School = schoolMapper.dtoToEntity(dto.School),
                    SchoolId = dto.School.SchoolId
                };

                return financesEntity;
            }
            return null;
        }

        public FinancesModel EntityToDTO(Finances entity)
        {
            if (entity != null)
            {
                FinancesModel financesModel = new FinancesModel()
                {
                    Amount = entity.Amount,
                    CreatedAt = entity.CreatedAt,
                    Date = entity.Date,
                    Description = entity.Description,
                    FinanceId = entity.FinanceId,
                    IsExpense = entity.IsExpense,
                    ModifiedAt = entity.ModifiedAt,
                    School = schoolMapper.EntityToDTO(entity.School)
                };

                return financesModel;
            }
            return null;
        }
    }
}
