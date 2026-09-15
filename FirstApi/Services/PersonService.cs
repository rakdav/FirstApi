using FirstApi.Models;

namespace FirstApi.Services
{
    public class PersonService : IService<Person>
    {
        private List<Person> People;
        public PersonService()
        {
            People = new List<Person>();
        }
        public async Task Create(Person entity)
        {
            People.Add(entity);
        }

        public async Task Delete(string id)
        {
            Person person = People.FirstOrDefault(p => p.Id == id)!;
            People.Remove(person);
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return People;
        }

        public async Task<Person> GetById(string id)
        {
            return  People.FirstOrDefault(p=>p.Id == id)!;
        }

        public async Task Update(Person entity)
        {
            Person person= People.FirstOrDefault(p => p.Id == entity.Id)!;
            person.Name = entity.Name;
            person.Age= entity.Age;
        }
    }
}
