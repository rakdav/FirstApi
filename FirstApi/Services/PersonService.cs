using FirstApi.Models;

namespace FirstApi.Services
{
    public class PersonService : AbstractionService, IService<Person>
    {
        private List<Person> People;
        public PersonService()
        {
            People = new List<Person>();
        }
        public PersonService(List<Person> list)
        {
            People = new List<Person>();
            People!.AddRange(list);
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return People;
        }

        public async Task<Person> GetById(string id)
        {
            return  People.FirstOrDefault(p=>p.Id == id)!;
        }

        bool IService<Person>.Create(Person entity)
        {
            bool result = DoAction(delegate ()
            {
                People.Add(entity);
            });
            return result;
        }

        bool IService<Person>.Delete(string id)
        {
            bool result = DoAction(delegate ()
            {
                Person person= People.FirstOrDefault(p=>p.Id==id)!;
                People.Remove(person);
            });
            return result;
        }

        bool IService<Person>.Update(Person entity)
        {
            bool result = DoAction(delegate ()
            {
                Person person = People.FirstOrDefault(p => p.Id == entity.Id)!;
                person.Name = entity.Name;
                person.Age= entity.Age;
            });
            return result;
        }
    }
}
