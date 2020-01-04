using MAvha.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MAvha.Servicios
{
    public class ServicesMAvha
    {
        public void InsertTODO(MAvha.Modelo.TODO pEN)
        {
            using (var db = new Modelo.MAvhaEntities())
            {
                var entidad = new Modelo.TODO();
                entidad.Description = pEN.Description;
                entidad.Status = pEN.Status;
                entidad.Image = pEN.Image;
                db.TODO.Add(entidad);
                db.SaveChanges();
            }
        }
        public List<Modelo.TODO> GetAll()
        {
            using (var db = new Modelo.MAvhaEntities())
            {
                var list = from d in db.TODO select d;
                return list.ToList();
            }
        }
        public Modelo.TODO GetById(long Id)
        {
            using (var db = new Modelo.MAvhaEntities())
            {
                var todo = db.TODO.Find(Id);
                return todo;
            }
        }
        public List<TODO> GetByDescription(string description)
        {
            using (var db = new Modelo.MAvhaEntities())
            {
                var todo = from d in db.TODO where d.Description.Contains(description) select d;
                return todo.ToList();
            }
        }
        public List<Modelo.TODO> GetByStatus(int status)
        {
            using (var db = new Modelo.MAvhaEntities())
            {
                var todo = from d in db.TODO where d.Status == status select d;
                return todo.ToList();
            }
        }
        
    }
}