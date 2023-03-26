using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository.IReporsitory
{
	public interface IUnitOfWork
	{
		
		public IProduct Product { get; }
		void Save();

	}
}
