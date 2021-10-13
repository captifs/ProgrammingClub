using ProgrammingClub.Models;
using ProgrammingClub.Models.DBObject;
using ProgrammingClub.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingClub.Repositories
{
    public class MemberRepository
    {
        private ClubMembershipModelsDataContext dbContext;
        public MemberRepository()
        {
            this.dbContext = new ClubMembershipModelsDataContext();

        }
        public MemberRepository(ClubMembershipModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<MemberModel> GetAllMembers()
        {
            List<MemberModel> membersLists = new List<MemberModel>();
            foreach ( var dbMember in dbContext.Members)
            {
                membersLists.Add(MapDbObjectToModel(dbMember));
            }
            return membersLists;
        }

        private MemberModel MapDbObjectToModel(Member member)
        {
            MemberModel memberModel = new MemberModel();
            if (memberModel != null)
            {
                memberModel.IDMember = member.IDMember;
                memberModel.Name = member.Name;
                memberModel.Title = member.Title;
                memberModel.Position = member.Position;
                memberModel.Description = member.Description;
                memberModel.Resume = member.Resume;
                return memberModel;
            }
            return null;
        }

        public MemberCodeSnippetsViewModel GetMemberCodeSnippets(Guid memberID)
        {
            MemberCodeSnippetsViewModel memberCodeSnippetsViewModel = new MemberCodeSnippetsViewModel();
            Member member = dbContext.Members.FirstOrDefault(m => m.IDMember == memberID);

            if (member != null)
            {
                memberCodeSnippetsViewModel.Name = member.Name;
                memberCodeSnippetsViewModel.Position = member.Position;
                memberCodeSnippetsViewModel.Title = member.Title;

                IQueryable<CodeSnippet> memberCodeSnippets = dbContext.CodeSnippets.Where(c => c.IDMember == memberID);
                foreach (CodeSnippet code in memberCodeSnippets)
                {
                    CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
                    codeSnippetModel.Title = code.Title;
                    codeSnippetModel.ContentCode = code.ContentCode;
                    codeSnippetModel.Revision = code.Revision;
                    memberCodeSnippetsViewModel.CodeSnippets.Add(codeSnippetModel);
                }
            }
            return memberCodeSnippetsViewModel;
        }

        public void DeleteMember(Guid id)
        {
            Member memberToBeDeleted = dbContext.Members.
                FirstOrDefault(mem => mem.IDMember == id);
            if (memberToBeDeleted != null)
            {
                dbContext.Members.DeleteOnSubmit(memberToBeDeleted);
                dbContext.SubmitChanges();
            }
        }

        public void UpdateMember(MemberModel memberModel)
        {
            Member existingMember = dbContext.Members.
                FirstOrDefault(x => x.IDMember == memberModel.IDMember);
            if (existingMember != null)
            {
                existingMember.IDMember = memberModel.IDMember;
                existingMember.Name = memberModel.Name;
                existingMember.Title = memberModel.Title;
                existingMember.Position = memberModel.Position;
                existingMember.Description = memberModel.Description;
                existingMember.Resume = memberModel.Resume;
                dbContext.SubmitChanges();
            }
        }

        public MemberModel GetMemberById(Guid id)
        {
            return MapDbObjectToModel(dbContext.Members.FirstOrDefault(mem => mem.IDMember == id));
        }

        public void InsertMember(MemberModel memberModel)
        {
            memberModel.IDMember = Guid.NewGuid();
            dbContext.Members.InsertOnSubmit(MapModelToDbObject(memberModel));
            dbContext.SubmitChanges();
        }

        private Member MapModelToDbObject(MemberModel memberModel)
        {
            Member dbMember = new Member();
            if (memberModel != null)
            {
                dbMember.IDMember = memberModel.IDMember;
                dbMember.Name = memberModel.Name;
                dbMember.Title = memberModel.Title;
                dbMember.Position = memberModel.Position;
                dbMember.Description = memberModel.Description;
                dbMember.Resume = memberModel.Resume;
                return dbMember;
            }
            return null;
        }
    }
}