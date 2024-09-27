using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DbCvEntities db = new DbCvEntities();

        public List<T> List() //T değeri bütün tablolar olabilir.
        {
            return db.Set<T>().ToList();
        }

        public void TAdd(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public void TRemove(T entity)
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }

        public void TUpdate(T entity)
        {
            db.SaveChanges();
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where); //Hangisini sileceğimizi bulmak için bunu kullanacağız Bir şart ekliyoruz biz bunu id yapacağız.
        }

       

    }
}
