using ProgrammingClub.Models;
using ProgrammingClub.Models.DBObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingClub.Repositories
{
    public class MembershipTypeRepository
    {
        private ClubMembershipModelsDataContext dbContext;


        public MembershipTypeRepository()
        {
            this.dbContext = new ClubMembershipModelsDataContext();
        }

        public MembershipTypeRepository(ClubMembershipModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<MembershipTypeModel> GetAllMembershipTypes()
        {
            List<MembershipTypeModel> membershipTypesLists = new List<MembershipTypeModel>();
            foreach (var dbMembershipType in dbContext.MembershipTypes)
            {
                membershipTypesLists.Add(MapDbObjectToModel(dbMembershipType));
            }
            return membershipTypesLists;

        }

        public MembershipTypeModel GetMembershipTypeById(Guid id)
        {
            return MapDbObjectToModel(dbContext.MembershipTypes.FirstOrDefault(mem => mem.IDMembershipType == id));
        }

        private MembershipTypeModel MapDbObjectToModel(MembershipType membershipType)
        {
            MembershipTypeModel membershipTypeModel = new MembershipTypeModel();
            if (membershipType != null)
            {
                membershipTypeModel.IDMembershipType = membershipType.IDMembershipType;
                membershipTypeModel.Name = membershipType.Name;
                membershipTypeModel.Description = membershipType.Description;
                membershipTypeModel.SubscriptionLengthInMonths = membershipType.SubscriptionLengthInMonths;
                return membershipTypeModel;

            }
            return null;
        }

        public void InsertMembershipTypes(MembershipTypeModel membershipTypeModel)
        {
            membershipTypeModel.IDMembershipType = Guid.NewGuid();
            dbContext.MembershipTypes.InsertOnSubmit(MapModelToDbObject(membershipTypeModel));
            dbContext.SubmitChanges();
        }


        private MembershipType MapModelToDbObject(MembershipTypeModel membershipTypeModel)
        {
            MembershipType dbMembershipType = new MembershipType();
            if (membershipTypeModel != null)
            {
                dbMembershipType.IDMembershipType = membershipTypeModel.IDMembershipType;
                dbMembershipType.Name = membershipTypeModel.Name;
                dbMembershipType.Description = membershipTypeModel.Description;
                dbMembershipType.SubscriptionLengthInMonths = membershipTypeModel.SubscriptionLengthInMonths;
                return dbMembershipType;
            }
            return null;
        }

        public void UpdateMembershipType(MembershipTypeModel membershipTypeModel)
        {
            MembershipType existingMembershipType = dbContext.MembershipTypes.
     FirstOrDefault(x => x.IDMembershipType == membershipTypeModel.IDMembershipType);
            if (existingMembershipType != null)
            {
                existingMembershipType.IDMembershipType = membershipTypeModel.IDMembershipType;
                existingMembershipType.Name = membershipTypeModel.Name;
                existingMembershipType.Description = membershipTypeModel.Description;
                existingMembershipType.SubscriptionLengthInMonths = membershipTypeModel.SubscriptionLengthInMonths;
                dbContext.SubmitChanges();
            }
        }


        public void DeleteMembershipType(Guid id)
        {
            MembershipType membershipTypeToBeDeleted = dbContext.MembershipTypes.
                FirstOrDefault(mem => mem.IDMembershipType == id);
            if (membershipTypeToBeDeleted != null)
            {
                dbContext.MembershipTypes.DeleteOnSubmit(membershipTypeToBeDeleted);
                dbContext.SubmitChanges();

            }
        }
    }
}