﻿using Blue_Badge_Project.Data;
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
                    HeightInCentimeters = model.Height,
                    WeightInLbs = model.Weight,
                    Gender = (Data.GenderEnum)model.Gender,
                    BodyType = (Data.BodyTypeEnum)model.BodyType,
                    Goal = (Data.GoalEnum)model.Goal,
                    DateJoined = DateTime.Now
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
                    .Where(e => e.Id == _userId)
                    .Select(
                        e =>
                            new AppUserListItem
                            {
                                UserId = e.Id,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                DateJoined = e.DateJoined,
                                Gender = e.Gender,
                                Goal = e.Goal
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

        public IEnumerable<AppUserListItem> GetAppUsersByLastName(string lastName)  //Search by last name
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Users
                    .Where(e => e.LastName == lastName)
                    .Select(
                        e =>
                        new AppUserListItem
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Gender = e.Gender
                        }
                        );
                return query.ToArray();
            }
        }


        public AppUserDetail GetUserId(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {

                
                var entity =
                    ctx
                    .Users.Single(e => e.Id == userId);
                return
                    new AppUserDetail
                    {
                        UserId = entity.Id,
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
