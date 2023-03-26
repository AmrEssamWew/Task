using DataAcess.Data;
using DataAcess.Repository.IReporsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
	public class UnitOFWork : IUnitOfWork
	{
		

		public IProduct Product { get; private set; }
		private AppDbContext _db;

		public UnitOFWork(AppDbContext db)
		{
			_db = db;
			
			Product = new ProductRepository(_db);
		

		}
		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
