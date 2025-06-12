using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public interface IUslugaService
    {
        public List<UslugaEntity> get();
        public UslugaEntity getById(int id);
        public void delete(int id);

        public void put(int id, UslugaDTO usluga);

        public void post(UslugaDTO usluga);
    }
}
