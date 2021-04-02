using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectLib.Object
{
    public interface IMembersRepository
    {
        List<Member> GetMembers();
        Member AddMember(Member member);
        void DeleteMember(int id);
        Member UpdateMember( Member member);
        Member GetMemberById(int id);
        List<Member> GetMembersByName(string name);
    }
}