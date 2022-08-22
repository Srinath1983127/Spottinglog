using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spottinglog.Models;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

namespace Spottinglog.DataAccess
{
    public class DalUser
    {
        private SpottinglogEntities db = new SpottinglogEntities();
        private static readonly object DocLock = new object();
        private static DalUser _instance;

        private DalUser()
        {
        }

        public static DalUser GetInstance
        {
            get
            {
                lock (DocLock)
                {
                    return _instance ?? (_instance = new DalUser());
                }
            }
        }

        public tblUser GetUser(string Username, string Password)
        {
            try

            {
                var User = (from u in db.tblUsers
                            where u.UserName == Username
                            select u).SingleOrDefault();
                var sysUser = new tblUser();
                if (User != null)
                {

                   
                        sysUser = new tblUser
                        {
                            Userid = User.Userid,
                            FullName = User.FullName,
                            UserName = User.UserName,
                            Password = User.Password,





                        };

                   
                  



                }





                return sysUser;

            }
            catch (Exception ex)
            {
                
                return null;


            }




        }






    }
}