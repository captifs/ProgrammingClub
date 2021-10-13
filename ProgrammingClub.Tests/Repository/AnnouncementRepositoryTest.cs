using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingClub.Models;
using ProgrammingClub.Models.DBObject;
using ProgrammingClub.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingClub.Tests.Repository
{
    [TestClass]
    public class AnnouncementRepositoryTest
    {
        private ClubMembershipModelsDataContext dbContext;
        private string testConnectionString;
        private AnnouncementRepository announcementRepository;

        [TestInitialize]
        public void Initialize()
        {
            testConnectionString = ConfigurationManager.
                ConnectionStrings["clubmembershipConnectionStringTest"]
                                    .ConnectionString;
            dbContext = new ClubMembershipModelsDataContext(testConnectionString);
            announcementRepository = new AnnouncementRepository(dbContext);
        }


        [TestMethod]
        public void GetAnnouncementById_AnnouncementsExists()
        {
            ///AAA -> Arrange,Act,Assert. Setup all objects. Invoke the method under test.
            Guid ID = Guid.NewGuid();
            Announcement expectedAnnouncement = new Announcement
            {
                IDAnnouncement = ID,
                ValidFrom = new DateTime(2021, 1, 1),
                ValidTo = new DateTime(2021, 1, 1),
                Tags = "test tag",
                Text = "Announcement",
                Title = "Important"
            };

            dbContext.Announcements.InsertOnSubmit(expectedAnnouncement);
            dbContext.SubmitChanges();

            AnnouncementModel result = announcementRepository.GetAnnouncementById(ID);
            Assert.AreEqual(result.IDAnnouncement, expectedAnnouncement.IDAnnouncement);
            Assert.AreEqual(result.Text, expectedAnnouncement.Text);
            Assert.AreEqual(result.Title, expectedAnnouncement.Title);
            Assert.AreEqual(result.EventDateTime, expectedAnnouncement.EventDateTime);
            Assert.AreEqual(result.ValidFrom, expectedAnnouncement.ValidFrom);
            Assert.AreEqual(result.ValidTo, expectedAnnouncement.ValidTo);
            Assert.AreEqual(result.Tags, expectedAnnouncement.Tags);

            

        }

        [TestMethod]
        public void GetAnouncementById_AnnouncementDoesntExist()
        {
            ///AAA -> Arrange,Act,Assert. Setup all objects. Invoke the method under test.
            //Arrange
            Guid ID = Guid.NewGuid();
            Announcement expectedAnnouncement = new Announcement
            {
                IDAnnouncement = ID,
                ValidFrom = new DateTime(2021, 1, 1),
                ValidTo = new DateTime(2021, 1, 1),
                Tags = "test tag",
                Text = "Announcement",
                Title = "Important"
            };

            dbContext.Announcements.InsertOnSubmit(expectedAnnouncement);
            dbContext.SubmitChanges();

            //Act 
            AnnouncementModel result = announcementRepository.GetAnnouncementById(Guid.NewGuid());

            //Assert
            Assert.IsNull(result);

        }
    }
}
