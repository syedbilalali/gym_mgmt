using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Models;

namespace gym_mgmt_01.Controllers
{   
    [Authorize]
    public class MemberController : Controller
    {
        // GET: Member
        MemberOperation mo = new MemberOperation();
        ContactOpration co = new ContactOpration();
        EmergencyContactOpt eco = new EmergencyContactOpt();
        AddtionalDetailsOpt ado = new AddtionalDetailsOpt();
        PropectusOperation po = new PropectusOperation();
        public ActionResult Index()
        {
            ViewBag.ID = mo.getMemberID();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection fc) {
            if (ModelState.IsValid) {

                string memberTypeCheck = fc["memberType"];
                Member m1 = new Member();

                    m1.FirstName = fc["FirstName"];
                    m1.LastName = fc["LastName"];   
                    m1.DOB = fc["dob"];
                    m1.Gender = fc["gender"];
                    m1.note = fc["note"];
                    m1.MemberType = "";
                    m1.ImgURL = "";
                string formID = mo.getMemberID();
                    mo.AddMemeber(m1);
                Contact ct = new Contact();
                ct.Email = fc["Email"];
                ct.MemberID = int.Parse(formID);
                ct.Cell = fc["Cell"];
                ct.Home = fc["Home"];
                ct.Work = fc["Work"];
                ct.Address = fc["Address"];
                ct.Suburb = fc["Suburb"];
                ct.City = fc["City"];
                ct.Zipcode = fc["Zipcode"];
                ct.Subscribed = "";
                co.AddContact(ct);
                AdditionalDetails ad = new AdditionalDetails();
                ad.Club = int.Parse(fc["Club"]);
                ad.MemberID = int.Parse(formID);
                ad.TrainerID = int.Parse(fc["TrainerID"]);
                ad.Occupation = fc["Occupation"];
                ad.Organisation = fc["Organisation"];
                ad.JoiningDate = fc["JoiningDate"];
                ad.SalesRepID = int.Parse(fc["SalesRepresentID"]);
                ad.SourcePromotionID =int.Parse( fc["SourcePromotionID"]);
                ad.ReferredMemberBy = int.Parse(fc["ReferredMemberBy"]);
                ad.InvolvementType = fc["InvolvementType"];
                ado.AddAddtionalDetails(ad);
                if (memberTypeCheck == "true")
                {
                    //Add Emergency Contact
                    Response.Write("MemberType Checked");
                    EmergencyContact ec = new EmergencyContact();
                    ec.FirstName = fc["ecFirstName"];
                    ec.MemberID = int.Parse(formID);
                    ec.LastName = fc["ecLastName"];
                    ec.Relationship = fc["ecRelationship"];
                    ec.Email = fc["ecEmail"];
                    ec.Cell = fc["ecCell"];
                    ec.Home = fc["ecHome"];
                    ec.Work = fc["ecWorks"];
                    ec.MedicalInfo = fc["ecMedicalInfo"];
                    ec.Age = fc["ecAge"];
                    eco.AddEmergencyContact(ec);

                   
                }
                else {
                    //Add 
                    Response.Write("MemberType Not Checked");
                    Prospectus prop = new Prospectus();
                    prop.MemberID = int.Parse(formID);
                    prop.ContactMethod = fc["pdContactMethods"];
                    prop.FitnessGoal = fc["pdFitnessGoal"];
                    prop.LeadStrength = fc["pdLeadStrength"];
                    prop.PreviousGym = fc["pdPreviousGym"];
                    prop.Created = fc["pdCreated"];
                    po.AddProspectus(prop);
                }
            }
            return View();
        }
        public ActionResult FindMember() {
            return View();
        }

    }
}