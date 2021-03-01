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
        //CONSTRUCTOR - GUID
        private readonly Guid _ownerId;
        public AppUserService(Guid ownerId)
        {
            _ownerId = ownerId;
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

        public bool CreateAppUser(AppUserCreate model) //4.02  THIS LIKELY WILL MOVE ELSEWHERE! "This will create an instance of [AppUser]."
        {
            var entity =
                new AppUser()
                {
                    AppUserId = model.AppUserId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    HeightInCentimeters = model.Height,
                    WeightInLbs = model.Weight,
                    Gender = model.Gender,
                    BodyType = (BodyTypeEnum)model.BodyType,
                    Goal = model.Goal,
                    DateJoined = DateTime.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.AppUsers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AppUserListItem> GetAppUsersBySystemPlan()  //"This method will allow us to see all the [AppUsers] that belong to a specific [SystemPlan]." (((4.02)))
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .AppUsers
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
                    .AppUsers
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
        }


        public IEnumerable<AppUserListItem> GetAppUsersByLastName()  //Search by last name
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .AppUsers
                    .Where(e => e.LastName == _lastName)
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

        public AppUserDetail GetAppUserById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .AppUsers.Single(e => e.LastName == _lastName && e.OwnerId == _ownerId);
                return
                    new AppUserDetail
                    {
                        NoteId = entity.NoteId,
                        Title = entity.Title,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc,
                        ModifedUtc = entity.ModifiedUtc
                    };
            }
        }
    }
}
