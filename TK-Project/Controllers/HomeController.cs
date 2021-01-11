using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TK_Project.Models;

namespace TK_Project.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public async Task<ActionResult> Profile()
        {
            var user = await db.Users.Where(x => x.UserName == User.Identity.Name).SingleOrDefaultAsync();
            return View(user);
        }
        [HttpPost]
        public async Task<ActionResult> RegisterStudent(ViewModels.AddStudent addStudents)
        {
            if (addStudents != null)
            {
                try
                {
                    var searchUser = await UserManager.FindByNameAsync(addStudents.NIK);
                    if (searchUser == null)
                    {
                        var email = addStudents.FullName.ToLower();
                        var newEmail = email.Replace(" ", "");
                        var studentCount = await db.Students.ToListAsync();
                        var studentEmail = newEmail+"-" +studentCount.Count() + "@mutiarahatipedan.sch.id";
                        var citizen = new Students
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserName = addStudents.NIK,
                            Email = studentEmail,
                            FullName = addStudents.FullName,                        
                        };
                        var resultUserManager = await UserManager.CreateAsync(citizen, addStudents.Password);
                        var currentStudent = await UserManager.FindByEmailAsync(studentEmail);
                        var addToRoleResult = await UserManager.AddToRoleAsync(currentStudent.Id, "Student");
                        if (resultUserManager.Succeeded && addToRoleResult.Succeeded)
                        {
                            var addStudent = await db.Students.FindAsync(currentStudent.Id);
                            if (addStudent != null)
                            {
                                addStudent.NIK = addStudents.NIK;
                                addStudent.KKNumber = addStudents.KKNumber;
                                addStudent.City = addStudents.City;
                                addStudent.DeedNumber = addStudents.DeedNumber;
                                addStudent.Districts = addStudents.Districts;
                                addStudent.SubDistrict = addStudents.SubDistrict;
                                addStudent.RTRW = addStudents.RTRW;
                                addStudent.Status = Status.Pending;
                                addStudent.Province = addStudents.Province;
                                addStudent.FamilyHead = addStudents.FamilyHead;
                                addStudent.DOB = addStudents.DOB;
                                addStudent.Religion = Religion.Islam;
                                addStudent.Departement = addStudents.Roles;
                                addStudent.RegistrationStatus = RegistrationStatus.Pending;
                                addStudent.Citizenship = addStudents.Citizenship;
                                addStudent.Gender = addStudents.Gender;
                                addStudent.IsBanned = false;
                                addStudent.Address = addStudents.Address;
                                addStudent.EmailConfirmed = false;
                            }
                            db.Entry(addStudent).State = EntityState.Modified;
                            var result = await db.SaveChangesAsync();
                            if (result > 0)
                            {
                                return RedirectToAction("Login", "Account");

                            }
                        }
                    }
                    else
                    {
                        return RedirectToAction("RegisteredUser", "Account");
                    }
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.Message);
                    Trace.TraceError(ex.StackTrace);
                }
            }
            return View("Error");
        }
        [HttpPost]
        public async Task<ActionResult> RegisterAdmin(ViewModels.AddStudent addStudents)
        {
            if (addStudents != null)
            {
                try
                {
                    var searchUser = await UserManager.FindByNameAsync(addStudents.NIK);
                    if (searchUser == null)
                    {
                        var citizen = new Administrator
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserName = addStudents.NIK,
                            Email = addStudents.Email,
                            FullName = addStudents.FullName,
                        };
                        var resultUserManager = await UserManager.CreateAsync(citizen, addStudents.Password);
                        var currentStudent = await UserManager.FindByEmailAsync(addStudents.Email);
                        var addToRoleResult = await UserManager.AddToRoleAsync(currentStudent.Id, "Administrator");
                        if (resultUserManager.Succeeded && addToRoleResult.Succeeded)
                        {
                            var addStudent = await db.Administrators.FindAsync(currentStudent.Id);
                            if (addStudent != null)
                            {
                                addStudent.NIK = addStudents.NIK;
                                addStudent.KKNumber = addStudents.KKNumber;
                                addStudent.City = addStudents.City;
                                addStudent.Districts = addStudents.Districts;
                                addStudent.SubDistrict = addStudents.SubDistrict;
                                addStudent.RTRW = addStudents.RTRW;
                                addStudent.Status = Status.Approved;
                                addStudent.Province = addStudents.Province;
                                addStudent.DOB = addStudents.DOB;
                                addStudent.Religion = Religion.Islam;
                                addStudent.Departement = addStudents.Roles;
                                addStudent.RegistrationStatus = RegistrationStatus.Approved;
                                addStudent.EmailConfirmed = true;
                                addStudent.Citizenship = addStudents.Citizenship;
                                addStudent.Gender = addStudents.Gender;
                                addStudent.IsBanned = false;
                                addStudent.Address = addStudents.Address;
                            }
                            db.Entry(addStudent).State = EntityState.Modified;
                            var result = await db.SaveChangesAsync();
                            if (result > 0)
                            {
                                return RedirectToAction("Login", "Account");

                            }
                        }
                    }
                    else
                    {
                        return RedirectToAction("RegisteredUser", "Account");
                    }
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.Message);
                    Trace.TraceError(ex.StackTrace);
                }
            }
            return View("Error");
        }
    }
}