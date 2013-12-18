using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;



namespace Model
{
    public class EntityModelManagerRepository : Model.IModelRepository
    {
        private VolunteerOrgContext db = new VolunteerOrgContext();
        public IEnumerable<VolunteerProject> GetAllProjects()
        {
            return db.VolunteerProjects
                .Include("Location")
                .Include("Matches")
                .Include("Owner")
                .Include("ProjectTopics").ToList();
        }

        public IEnumerable<Volunteer> GetAllVolunteers()
        {
            return db.Volunteers
                .Include("Matches")
                .Include("VolunteerPreferences")
                .Include("Location").ToList();
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return db.Admins
                .Include("Association")
                .Include("Location")
                .Include("Association.VolunteerProjects").ToList();
        }

        public IEnumerable<Match> GetAllMatches()
        {
            return db.Matches
                .Include("Volunteer")
                .Include("Project").ToList();

        }


        public IEnumerable<Organization> GetAllOrganizations()
        {
            return db.Organizations
                .Include("VolunteerProjects")
                .Include("Location").ToList();
        }

        public VolunteerProject GetProject(int id)
        {
            return db.VolunteerProjects
                .Include("Owner")
                .Include("Location")
                .Include("ProjectTopics")
                .Include("Matches")
                .Include("Matches.Volunteer")
                .Where(v => v.Id == id)
                .FirstOrDefault();
        }

        public Organization GetOrganization(int id)
        {
            return db.Organizations
                .Include("VolunteerProjects")
                .Include("Location").FirstOrDefault(o => o.Id == id);
        }

        public Volunteer GetVolunteer(int id)
        {
            return db.Volunteers
                .Include("Matches")
                .Include("Matches.Project")
                .Include("Location")
                .Include("VolunteerPreferences")
                .Where(v => v.ID == id)
                .FirstOrDefault();
        }

        public void CreateOrganization(Organization organization)
        {
            db.Organizations.Add(organization);
        }

        public void VolunteerEdited(Volunteer volunteer)
        {
            db.Entry(volunteer).State = EntityState.Modified;
            foreach (Match match in volunteer.Matches)
            {
                db.Entry(match).State = EntityState.Modified;
            }
            db.Entry(volunteer.Location).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void AdminEdited(Admin admin)
        {
            
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
            
        }
    }
}
