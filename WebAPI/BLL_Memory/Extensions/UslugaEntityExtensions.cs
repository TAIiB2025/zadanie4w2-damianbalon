using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Memory.Extensions
{
    internal static class UslugaEntityExtensions
    {
        public static UslugaDTO ToUslugaDTO(this UslugaEntity osobaEntity)
        {
            return new UslugaDTO(osobaEntity.nazwa, osobaEntity.wykonawca, osobaEntity.rodzaj, osobaEntity.rok);
        }

    }
}
