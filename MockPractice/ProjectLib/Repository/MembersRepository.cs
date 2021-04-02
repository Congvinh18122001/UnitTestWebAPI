using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLib.Object
{
    public class MembersRepository : IMembersRepository
    {
        private readonly ProjectLibDbContext _dbContext;

        public MembersRepository(ProjectLibDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public List<Member> GetMembersByName(string name){
            if (String.IsNullOrEmpty(name))
            {
                return GetMembers();
            }
            return _dbContext.Members.Where(m => m.Name.Contains(name)).ToList();
        }

        public Member AddMember(Member member){
            _dbContext.Members.Add(member);
            _dbContext.SaveChanges();
            return member;
        }

        public void DeleteMember(int id) {
            _dbContext.Members.Remove(_dbContext.Members.SingleOrDefault(p=>p.ID==id));
            _dbContext.SaveChanges();
        }
        public Member UpdateMember(Member member){
            Member getMember = _dbContext.Members.Find(member.ID);
            getMember.Name = member.Name;
            getMember.Gender = member.Gender;
            getMember.Birthday = member.Birthday;
            getMember.Phone = member.Phone;
            getMember.Email = member.Email;
            getMember.BirthPlace = member.BirthPlace;
            _dbContext.SaveChanges();
            return getMember;
        } 

        public List<Member> GetMembers() {
            return _dbContext.Members.ToList();
        }

        public Member GetMemberById(int id) => _dbContext.Members.SingleOrDefault(p=>p.ID == id);
        
            
    }
}