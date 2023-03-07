using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Options
{
    public class DbOptions
    {
        public const string Key = nameof(DbOptions);

        public string ConnectionString { get; set; } = default!;
    }
}
