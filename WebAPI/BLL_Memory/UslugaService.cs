using BLL;
using DAL;
using BLL_Memory.Extensions;

namespace BLL_Memory
{
    public class UslugaService : IUslugaService
    {
        private static int gen = 1;
        private static List<UslugaEntity> lista = new List<UslugaEntity>()
        {
            new UslugaEntity()
            {
                id = gen++,
                nazwa = "Malowanie ścian",
                wykonawca = "Jan Kowalski",
                rodzaj = "Budowlana",
                rok = 2023
            },
            new UslugaEntity()
            {
                id = gen++,
                nazwa = "Naprawa laptopa",
                wykonawca = "TechFix Serwis",
                rodzaj = "Elektroniczna",
                rok = 2024
            },
            new UslugaEntity()
            {
                id = gen++,
                nazwa = "Projekt ogrodu",
                wykonawca = "Zielony Zakątek",
                rodzaj = "Projektowa",
                rok = 2022
            },
        };

        public List<UslugaEntity> get()
        {
            return lista;
        }

        public UslugaEntity getById(int id)
        {
            return lista.FirstOrDefault(e => e.id == id);
        }


        public void put(int id, UslugaDTO usluga)
        {
            var entity = lista.FirstOrDefault(e => e.id == id);
            if (entity != null)
            {
                entity.nazwa = usluga.nazwa;
                entity.wykonawca = usluga.wykonawca;
                entity.rodzaj = usluga.rodzaj;
                entity.rok = usluga.rok;
            }
        }

        public void delete(int id)
        {
            var entity = lista.FirstOrDefault(e => e.id == id);
            if (entity != null)
            {
                lista.Remove(entity);
            }
        }

        public void post(UslugaDTO usluga)
        {
            var entity = new UslugaEntity()
            {
                id = gen++,
                nazwa = usluga.nazwa,
                wykonawca = usluga.wykonawca,
                rodzaj = usluga.rodzaj,
                rok = usluga.rok
            };
            lista.Add(entity);
        }
    }
}
