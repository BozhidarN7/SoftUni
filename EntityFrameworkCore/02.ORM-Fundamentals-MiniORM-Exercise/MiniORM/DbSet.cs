using System.Collections.Generic;

namespace MiniORM
{
	internal class DbSet<TEntity>
    {
		internal IList<TEntity> Entities { get; set; }

    }
}