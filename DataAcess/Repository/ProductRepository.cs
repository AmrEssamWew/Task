using DataAcess.Data;
using DataAcess.Repository.IReporsitory;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
	public class ProductRepository : Repository<Product>, IProduct
	{
		private AppDbContext _db;
		public ProductRepository(AppDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Product obj)
		{
			_db.Product.Update(obj);

		}





		
	}
}

