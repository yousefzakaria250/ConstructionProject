using Data.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.ProjectRepo.ProjectRepos
{
    public interface IPublicInterface<TDto, RModel, RModelDto>
    {
        public RModel Insert(TDto entity);
        public RModel Update(int id, TDto entity);
        public IEnumerable<RModelDto> GetAll(string Lang);
        public RModelDto getById(int id,string lang);
        public bool Delete(int id);
    }
}
