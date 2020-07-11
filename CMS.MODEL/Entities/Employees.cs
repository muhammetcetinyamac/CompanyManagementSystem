using CMS.CORE.Entity;
using CMS.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MODEL.Entities
{
    public class Employees : BaseEntity
    {
        public Employees()
        {
            Orders = new HashSet<Orders>();
            Tasks = new HashSet<Tasks>();
            Petitions = new HashSet<Petition>();
            Opinions = new HashSet<Opinions>();
            Announcements = new HashSet<Announcement>();
            VehicleFleets = new HashSet<VehicleFleet>();
        }
        
        public string TCKN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Title Title { get; set; }
        public Departments Department { get; set; }
        public string Gender { get; set; }
        public bool Holiday { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public decimal Price { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        public int VehicleFleetId { get; set; }
        public int OrdersId { get; set; }
        public int TasksId { get; set; }
        public int PetitionId { get; set; }
        public int OpinionsId { get; set; }
        public int AnnouncementId { get; set; }
        


        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
        public virtual ICollection<VehicleFleet> VehicleFleets { get; set; }
        public virtual ICollection<Petition> Petitions { get; set; }
        public virtual ICollection<Opinions> Opinions { get; set; }
        public virtual ICollection<Announcement> Announcements { get; set; }
    }


}
