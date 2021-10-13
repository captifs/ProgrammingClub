using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingClub.Models
{
    public class CodeSnippetModel
    {
        public Guid IDCodeSnippet { get; set; }
        public string Title { get; set; }
        public string ContentCode { get; set; }
        public Guid IDMember { get; set;  }
        public int Revision { get; set; }


    }
}