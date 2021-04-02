using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectLib.Object;
namespace ProjectLib
{
    public class ProjectLibDbContext : DbContext
    {
        // protected override void OnConfiguring(DbContextOptionsBuilder options){
        //     options.UseSqlServer("Server=DESKTOP-HI0OTCU;Database=FirstWebAPI;Trusted_Connection=True;MultipleActiveResultSets=true");
        // }
        public ProjectLibDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
             modelBuilder.Entity<Member>().HasData(
             new Member() {  ID = 1 ,Name="Truong Cong Vinh",Phone="0123654789",Birthday="18/12/2001",Gender="Male",Email="asd12@gmail.com",BirthPlace="Hai Phong"}
            ,new Member() {  ID = 2 , Name="Truong Cong Minh",Phone="0123654789",Birthday="18/12/2000",Gender="Male",Email="asd2@gmail.com",BirthPlace="Ha Noi"}
            ,new Member() {  ID = 3 , Name="Truong Cong Tuan",Phone="0123654789",Birthday="18/12/1999",Gender="Male",Email="asd3@gmail.com" ,BirthPlace="Hai Phong"}
            ,new Member() { ID = 4 , Name="Truong Cong Tu",Phone="0123654789",Birthday="18/12/1998",Gender="Male",Email="asd4@gmail.com",BirthPlace="Ha Noi"}
            ,new Member() {  ID = 5 , Name="Truong Cong Duc",Phone="0123654789",Birthday="18/12/2000",Gender="Male",Email="asd5@gmail.com",BirthPlace="Ha Nam"}
             );
             modelBuilder.Entity<Role>().HasData(
                  new Role(){ID=1,RoleName="Admin"}
                 ,new Role(){ID=2,RoleName="User"}
             );
             modelBuilder.Entity<User>().HasData(
                 new User(){UserID=1,Username="Admin",Password="123",RoleID=1}
                ,new User(){UserID=2,Username="User",Password="123",RoleID=2}
             );
        }
        
    }
}