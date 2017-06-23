using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.Models;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            // TODO #1 - get the Job with the given ID and pass it into the view
            Job selectjob = jobData.Find(id);
            return View(selectjob);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            int emplid = newJobViewModel.EmployerID;
            int locid = newJobViewModel.LocationID;
            int compid = newJobViewModel.CoreCompetencyID;
            int posid = newJobViewModel.PositionTypeID;

            if (ModelState.IsValid)
            {
                /*Job newjob = new Job();
                newjob.Name = newJobViewModel.Name;
                newjob.Employer = jobData.Employers.Find(emplid);
                newjob.Location = newJobViewModel.Location;
                newjob.CoreCompetency = newJobViewModel.CoreCompetency;
                newjob.PositionType = newJobViewModel.PositionType;
                */

                Job newjob = new Job
                {
                    Name = newJobViewModel.Name,
                    Employer = jobData.Employers.Find(emplid),
                    Location = jobData.Locations.Find(locid),
                    CoreCompetency = jobData.CoreCompetencies.Find(compid),
                    PositionType = jobData.PositionTypes.Find(posid)
                };

                jobData.Jobs.Add(newjob);
                //int newid = newjob.ID;
                return Redirect("/job?id="+newjob.ID);/*use redirect not view*/
            }

            return View(newJobViewModel);

            // TODO #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.
        }

       /* [HttpPost]
        public IActionResult Edit(AddEditCheeseViewModel addEditCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                int chezid = addEditCheeseViewModel.CheeseId;
                Cheese editCheese = CheeseData.GetById(chezid);
                editCheese.Cheesename = addEditCheeseViewModel.Name;
                editCheese.Description = addEditCheeseViewModel.Description;
                editCheese.Type = addEditCheeseViewModel.Type;
            }

            return Redirect("/Cheese");




                [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                Cheese newCheese = new Cheese
                {
                    Cheesename = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Type = addCheeseViewModel.Type
                };

                Models.CheeseData.Add(newCheese);

                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);
}

        }*/
    }
}
