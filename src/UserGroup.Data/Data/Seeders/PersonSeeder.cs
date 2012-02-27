using System;
using System.Collections.Generic;
using UserGroup.Entities;
using UserGroup.Services;

namespace UserGroup.Data.Seeders
{


    public class PeopleSeeder
    {
        public IEnumerable<Person> GetPeople()
        {
            var person = new Person("der-albert.com");
            person.PromoteToAdministrator();
            yield return person;
        }
    }
}