using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Mock
{
    public class ContactUsRepositoryMock : IContactUsRepository
    {
        private List<ContactUs> _contactUs;
        public ContactUsRepositoryMock()
        {
            _contactUs = new List<ContactUs>()
            {
                new ContactUs
                {
                    VehicleInquiryId = 1,
                    Phone = "55555555",
                    Name = "MockBoi Number One",
                    Email = "a@a.com",
                    Message = "Howdy."
                },
                new ContactUs
                {
                    VehicleInquiryId = 2,
                    Phone = "55555555pt2",
                    Name = "MockBoi Number Two",
                    Email = "a@a.com",
                    Message = "Here's another one"
                }
            };
        }
        public void Add(ContactUs contactUs)
        {
            _contactUs.Add(contactUs);
        }

        public List<ContactUs> GetAll()
        {
            return _contactUs;
        }
    }
}
