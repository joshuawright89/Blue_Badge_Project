using Blue_Badge_Project.Data;
using Blue_Badge_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blue_Badge_Project.Data.ApplicationUser;

namespace Blue_Badge_Project.Services
{
    public class AppUserService
    {
        private readonly string _userId;
        public AppUserService(string userId)
        {
            _userId = userId;
            
        }

        
        public bool CreateAppUser(AppUserCreate model) 
        {
            var entity =
                new ApplicationUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    WeightInLbs = model.Weight,
                    HeightInCentimeters = model.Height,
                    DateOfBirth = (DateTime) model.DateOfBirth,
                    Gender = (Data.GenderEnum)model.Gender,
                    BodyType = (Data.BodyTypeEnum)model.BodyType,
                    Goal = (Data.GoalEnum)model.Goal,
                    DateJoined = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AppUserListItem> GetAllUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Users
                    //.Where(e => e.Id == _userId)
                    .Select(
                        e =>
                            new AppUserListItem
                            {
                                UserId = e.Id,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                DateOfBirth = e.DateOfBirth,
                                Gender = e.Gender,
                                BodyType = e.BodyType,
                                Goal = e.Goal,
                                DateJoined = e.DateJoined,
                            }
                        );
                return query.ToArray();
            }
        }

        /*public IEnumerable<AppUserListItem> GetAppUsersBySystemPlan()  //"This method will allow us to see all the [AppUsers] that belong to a specific [SystemPlan]." (((4.02)))
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Users
                    .Where(e => e.SystemPlan == _systemPlan)
                    .Select(
                        e =>
                        new AppUserListItem
                        {
                            AppUserId = e.AppUserId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Gender = e.Gender
                        }
                        );
                return query.ToArray();
            }
        }
        public IEnumerable<AppUserListItem> GetAppUsersByDietPlan()  //"This method will allow us to see all the [AppUsers] that belong to a specific [DietPlan]." (((4.02)))
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Users
                    .Where(e => e.DietPlan == _dietPlan)
                    .Select(
                        e =>
                        new AppUserListItem
                        {
                            AppUserId = e.AppUserId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Gender = e.Gender
                        }
                        );
                return query.ToArray();
            }
        }*/

       
        public AppUserDetail GetUserId(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .SingleOrDefault(e => e.Id == userId);
                return
                    new AppUserDetail
                    {
                        //Id = entity.Id,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        DateOfBirth = entity.DateOfBirth,
                        WeightInLbs = entity.WeightInLbs,
                        HeightInCentimeters = entity.HeightInCentimeters,
                        Gender = entity.Gender,
                        BodyType = entity.BodyType,
                        Goal = entity.Goal,
                        DateJoined = entity.DateJoined
                    };
            }
        }

        public bool UpdatePlan(AppUserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .SingleOrDefault(e => e.Id == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                entity.WeightInLbs = model.Weight;
                entity.HeightInCentimeters = model.Height;
                entity.DateOfBirth = (DateTime)model.DateOfBirth;
                entity.Gender = (Data.GenderEnum)model.Gender;
                entity.BodyType = (Data.BodyTypeEnum)model.BodyType;
                entity.Goal = (Data.GoalEnum)model.Goal;
                entity.DateJoined = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;

            }
        }
    }
    
}
