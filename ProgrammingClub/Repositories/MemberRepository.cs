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
    }
}