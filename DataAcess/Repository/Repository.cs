using DataAcess.Data;
using DataAcess.Repository.IReporsitory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAcess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private AppDbContext _db { get; set; }
		internal DbSet<T> dbset { get; set; }
		public Repository(AppDbContext db)
		{
			_db = db;
			this.dbset = _db.Set<T>();

		}
		public void Add(T entity)
		{
			dbset.Add(entity);
		}

		public IEnumerable<T> GetAll()
		{

			IQueryable<T> query = dbset;
			
			return query.ToList();
		}

		public void Remove(T entity)
		{
			dbset.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			dbset.RemoveRange(entities);
		}
		public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = dbset;
			
			return query.FirstOrDefault(filter);
		}

		
	}
}
