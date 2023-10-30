using System;
using System.Collections.Generic;
using Helpers;

namespace Kata02_IEquatable_IComparable_Factory
{
    class csMemberList : IMemberList
    {
        List<IMember> _members = new List<IMember>();

        public IMember this[int idx] => _members[idx];
        public int Count() => _members.Count;
        public int Count(int year)
        {
            int c = 0;
            foreach (var item in _members)
            {
                if (item.Since.Year == year)
                    c++;
            }
            return c;
        }

        public void Sort() => _members.Sort();

        public override string ToString()
        {
            string sRet = "";
            for (int i = 0; i < _members.Count; i++)
            {
                sRet += $"{_members[i]}\n";
                if ((i + 1) % 10 == 0)
                {
                    sRet += "\n";
                }
            }
            return sRet;
        }

        #region Class Factory for creating an instance filled with Random data
        public static class Factory
        {
            public static csMemberList CreateRandom(int NrOfItems)
            {
                var rnd = new csSeedGenerator();

                var memberlist = new csMemberList();
                for (int i = 0; i < NrOfItems; i++)
                {
                    memberlist._members.Add(new csMember().Seed(rnd));
                }
                return memberlist;
            }
        }
        #endregion

        public csMemberList() { }

        //Copy constructorn has to take a parameter of type MemberList to be
        //able to access and copy _members which is private
        public csMemberList(csMemberList org)
        {
            //Shallow Copy
            _members = org._members;

            //Deep copy manual
            _members = new List<IMember>();
            foreach (var item in org._members)
            {
                _members.Add(new csMember(item));
            }
            
            //Deep copy using Linq
  //          _members = org._members.Select(o => new Member(o)).ToList<IMember>();
        }
    }
}
