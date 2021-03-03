using Blue_Badge_Project.Data;
using Blue_Badge_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Services
{
    public class AppUserService  //"The service layer is how our application interacts with the database. In this section, we will create the NoteService that will push and pull notes from the database"
    {
        private readonly int _userId;
        public AppUserService(int userId)
        {
            _userId = userId;
        }

        //CONSTRUCTOR - LAST NAME
        private readonly string _lastName;
        public AppUserService(string lastName)
        {
            _lastName = lastName;
        }

        //CONSTRUCTOR - GENDER
        private readonly GenderEnum _gender;
        public AppUserService(GenderEnum gender)
        {
            _gender = gender;
        }

        public bool CreateAppUser(AppUserCreate model) //4.02  THIS LIKELY WILL MOVE ELSEWHERE! "This will create an instance of [ApplicationUser]."
        {
            var entity =
                new ApplicationUser()
                {
                    UserId = model.UserId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    HeightInCentimeters = model.Height,
                    WeightInLbs = model.Weight,
                    Gender = model.Gender,
                    BodyType = model.BodyType,
                    Goal = model.Goal,
                    DateJoined = DateTime.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
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


        public IEnumerable<AppUserListItem> GetAppUsersByLastName(string LastName)  //Search by last name
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Users
                    .Where(e => e.LastName == _lastName)
                    .Select(
                        e =>
                        new AppUserListItem
                        {
                            AppUserId = e.UserId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Gender = e.Gender
                        }
                        );
                return query.ToArray();
            }
        }

        public AppUserDetail GetAppUserByGuid(int OwnerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users.Single(e => e.LastName == _lastName && e.UserId == _userId);
                return
                    new AppUserDetail
                    {
                        AppUserId = entity.UserId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        DateOfBirth = entity.DateOfBirth,
                        DateJoined = entity.DateJoined,
                        WeightInLbs = entity.WeightInLbs,
                        HeightInCentimeters = entity.HeightInCentimeters,
                        Gender = entity.Gender,
                        Goal = entity.Goal,
                        BodyType = entity.BodyType
                    };
            }
        }
    }
}
