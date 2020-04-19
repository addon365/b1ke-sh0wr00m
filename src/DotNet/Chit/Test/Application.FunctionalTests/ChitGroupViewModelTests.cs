using addon365.Chit.Database.EfContext;
using addon365.Chit.DataService.Ef;
using addon365.Chit.ViewModel;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Threenine.Data;
using Xunit;

namespace Application.FunctionalTests
{
    public class ChitGroupViewModelTests
    {
        [Fact]
        public void InsertGroupTest()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<DatabaseContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new DatabaseContext(options))
                {
                    context.Database.EnsureCreated();
                }

                //Run the test against one instance of the context
                using (var context = new DatabaseContext(options))
                {
                    var viewModel = new ChitGroupViewModel(new ChitGroupDataService(new UnitOfWork<DatabaseContext>(context)));
                    viewModel.AccessId = "A1";
                    viewModel.GroupName = "Tamil Agent Test";
                    viewModel.DueAmount = 100;
                    viewModel.SaveChitGroup();


                }

                //Run the test against one instance of the context
                using (var context = new DatabaseContext(options))
                {
                    Assert.Equal(1, context.ChitGroups.Count());

                    

                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new DatabaseContext(options))
                {

                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
