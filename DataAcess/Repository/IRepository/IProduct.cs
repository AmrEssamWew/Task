using Models;

namespace DataAcess.Repository.IReporsitory
{
	public interface IProduct : IRepository<Product>
	{
		public void Update(Product obj);
	}

}
