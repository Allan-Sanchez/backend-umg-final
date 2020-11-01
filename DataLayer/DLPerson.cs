using BackendWebUMG.Contexts;
using BackendWebUMG.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.DataLayer
{
    public class DLPerson
    {
        UMGDBContext _context;
        public DLPerson(UMGDBContext Context)
        {
            _context = Context;
        }

        public List<Person> GetAllPersons()
        {
            var Persons = _context.Person.Where(x => x.Status == true).ToList();
            return Persons;
        }

        public Person GetPersonById(int id)
        {
            var rol = _context.Person.Where(x => x.Status == true).Include(x=>x.Courses).Include(x=>x.FacultityCordinator).FirstOrDefault(x => x.personId == id);
            return rol;
        }


        public Person AddPerson(Person newPerson)
        {
            _context.Person.Add(newPerson);
            _context.SaveChanges();
            return newPerson;
        }

        public bool UpdatePerson(Person uPerson)
        {
            try
            {
                _context.Entry(uPerson).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeletePerson(Person deletePerson)
        {
            try
            {
                deletePerson.Status = false; //LogicDelete
                _context.Entry(deletePerson).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
