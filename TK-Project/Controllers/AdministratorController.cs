using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TK_Project.Models;

namespace TK_Project.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : BaseController
    {
        // GET: Administrator
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Dashboard()
        {
            var allStudents = await db.Students.Where(x => x.IsBanned == false).ToListAsync();
            if (allStudents != null)
            {
                try
                {
                    List<ViewModels.DataPointStudents> dataStudent = new List<ViewModels.DataPointStudents>();
                    //Canvas JS Peserta Yang Datang
                    var studentPending = await db.Students
                    .Where(x => x.RegistrationStatus == RegistrationStatus.Pending || x.Status == Status.Pending)
                    .ToListAsync();
                    if (studentPending != null && studentPending.Count() > 0)
                    {
                        dataStudent.Add(new ViewModels.DataPointStudents("Menunggu Di Terima", studentPending.Count()));
                    }

                    var studentApproved = await db.Students
                    .Where(x => x.RegistrationStatus == RegistrationStatus.Approved || x.Status == Status.Approved)
                    .ToListAsync();
                    if (studentApproved != null && studentApproved.Count() > 0)
                    {
                        dataStudent.Add(new ViewModels.DataPointStudents("Di Terima", studentApproved.Count()));
                    }

                    var studentRejected = await db.Students
                    .Where(x => x.RegistrationStatus == RegistrationStatus.Rejected || x.Status == Status.Rejected)
                        .ToListAsync();
                    if (studentRejected != null && studentRejected.Count() > 0)
                    {
                        dataStudent.Add(new ViewModels.DataPointStudents("Di Tolak", studentRejected.Count()));
                    }
                    //Send To View With ViewBag
                    ViewBag.DataPointAllStudent = JsonConvert.SerializeObject(dataStudent);

                    return View(allStudents);
                }
                catch (NullReferenceException e)
                {

                }
            }
            return View("Error");
        }
        public async Task<ActionResult> DetailsStudent(string id)
        {
            var myStudents = await db.Students.Where(x => x.Id == id).SingleOrDefaultAsync();
            return View(myStudents);
        }
        public async Task<ActionResult> MyStudents()
        {
            var myStudents = await db.Students.Where(x => x.Status == Status.Approved).ToListAsync();
            return View(myStudents);
        }
        public async Task<ActionResult> RejectedStudents()
        {
            var myStudents = await db.Students.Where(x => x.Status == Status.Rejected).ToListAsync();
            return View(myStudents);
        }
        public async Task<ActionResult> WaitingApprovment()
        {
            var myStudents = await db.Students.Where(x => x.Status == Status.Pending).ToListAsync();
            return View(myStudents);
        }
        [HttpPost]
        public async Task<ActionResult> ApproveRegistration(string id)
        {
            var student = await db.Students.Where(x => x.Id == id).SingleOrDefaultAsync();
            var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                .SingleOrDefaultAsync();
            if (currentUser != null && student != null)
            {
                student.Approved = DateTime.UtcNow;
                student.ApprovedBy = currentUser;
                student.Status = Status.Approved;
                student.RegistrationStatus = RegistrationStatus.Approved;
                student.EmailConfirmed = true;
                try
                {
                    db.Entry(student).State = EntityState.Modified;
                    var result = await db.SaveChangesAsync();
                    if (result > 0)
                    {
                        return Json("OK", JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.Message);
                    Trace.TraceError(ex.StackTrace);
                    return Json("KO", JsonRequestBehavior.AllowGet);
                }
            }
            return Json("KO", JsonRequestBehavior.AllowGet);

        }
        public async Task<ActionResult> RejectRegistration(string id)
        {
            var student = await db.Students.Where(x => x.Id == id).SingleOrDefaultAsync();
            var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                .SingleOrDefaultAsync();
            if (currentUser != null && student != null)
            {
                student.Approved = DateTime.UtcNow;
                student.ApprovedBy = currentUser;
                student.Status = Status.Rejected;
                student.RegistrationStatus = RegistrationStatus.Rejected;
                try
                {
                    db.Entry(student).State = EntityState.Modified;
                    var result = await db.SaveChangesAsync();
                    if (result > 0)
                    {
                        return Json("OK", JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.Message);
                    Trace.TraceError(ex.StackTrace);
                    return Json("KO", JsonRequestBehavior.AllowGet);
                }
            }
            return Json("KO", JsonRequestBehavior.AllowGet);

        }
    }
}