using BenefitPro.Common.BaseClass;
using BenefitPro.Common.PageObjects.Administartion;
using BenefitPro.Common.PageObjects.Projects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro.Projects
{
    [TestFixture]
    public class ProjectAssignment : BaseTest
    {
        public ProjectAssignmentPage projectAssignmentPage;
        [Test]
        public void AddProjectAssignment()
        {
            Thread.Sleep(1000);
            projectAssignmentPage = new ProjectAssignmentPage(driver);
            projectAssignmentPage.ProjectsLink.Click();
            projectAssignmentPage.ProjectAssignmentLink.Click();
            projectAssignmentPage.AddButton.Click();
        }

    }
}
