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

        public bool Create(Person entity)
        {
            bool result = DoAction(delegate ()
            {
                entity.Id= Guid.NewGuid().ToString();
                People.Add(entity);
            });
            return result;
        }

        public bool Delete(string id)
        {
            bool result = DoAction(delegate ()
            {
                Person person= People.FirstOrDefault(p=>p.Id==id)!;
                People.Remove(person);
            });
            return result;
        }

        public bool Update(Person entity)
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
