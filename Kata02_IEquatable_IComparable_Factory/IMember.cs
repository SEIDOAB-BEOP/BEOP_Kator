using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Seido.Utilities.SeedGenerator;

namespace Kata02_IEquatable_IComparable_Factory
{
    public enum enMemberLevel { Platinum, Gold, Silver, Blue}
    public interface IMember: IEquatable<IMember>, IComparable<IMember>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public enMemberLevel Level {get; set;}
        public DateTime Since { get; set; }
        public IMember Seed(csSeedGenerator _seeder);
    }
 }
