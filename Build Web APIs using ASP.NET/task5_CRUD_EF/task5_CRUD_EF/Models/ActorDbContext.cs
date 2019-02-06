using Microsoft.EntityFrameworkCore;

namespace task5_CRUD_EF.Models
{
	public class ActorDbContext : DbContext
	{
		public DbSet<Actor> Actor { get; set; }

		public ActorDbContext(DbContextOptions<ActorDbContext> options) : base(options)
		{

		}
	}

	public class ActorDbContextFactory
		{
		public static ActorDbContext Create(string connection)
		{
			var optionsBuilder = new DbContextOptionsBuilder<ActorDbContext>();
			optionsBuilder.UseSqlServer(connection);
			return new ActorDbContext(optionsBuilder.Options);
		}
	}
}
