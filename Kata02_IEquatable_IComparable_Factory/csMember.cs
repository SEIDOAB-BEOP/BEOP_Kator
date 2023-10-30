using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;

namespace Kata02_IEquatable_IComparable_Factory
{
    class csMember : IMember
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public enMemberLevel Level { get; set; }
        public DateTime Since { get; set; }
        public override string ToString() => $"{FirstName} {LastName} is a {Level} member since {Since.Year}";

        #region Implement IComparable
        public int CompareTo(IMember other)
        {
            if (Level != other.Level)
                return Level.CompareTo(other.Level);

            return Since.CompareTo(other.Since);
        }
        #endregion

        #region Implement IEquatable
        public bool Equals(IMember other) => (this.FirstName, this.LastName, this.Level, this.Since) == 
            (other.FirstName, other.LastName, other.Level, other.Since);

        // legacy .NET compliance
        public override bool Equals(object obj) => Equals(obj as IMember);
        public override int GetHashCode() => (this.FirstName, this.LastName, this.Level, this.Since).GetHashCode();
        #endregion

        public IMember Seed(csSeedGenerator _seeder)
        {
            FirstName = _seeder.FirstName;
            LastName = _seeder.LastName;
            Level = _seeder.FromEnum<enMemberLevel>();
            Since = _seeder.DateAndTime(1990, 2022);

            return this;
        }

        public csMember() { }

        #region Copy Constructor
        public csMember(IMember src)
        {
            FirstName = src.FirstName;
            LastName = src.LastName;
            Level = src.Level;
            Since = src.Since;
        }
        #endregion
    }
}
