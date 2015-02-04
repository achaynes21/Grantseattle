using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using InventoryERP.Core;
using InventoryERP.Data;
using InventoryERP.Data.Implementations;
using InventoryERP.Data.Mapping;
using InventoryERP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Tester
{
    [TestClass]
    public class DataInitializer
    {
        private MongoDatabase Database { get; set; }

        protected IRepository<Member> MemberRepository { get; private set; }

        [TestInitialize]
        public void InitializeDatabase()
        {
            EntityMap.Register();

            MongoUrl url = new MongoUrl(App.Configurations.ConnectionString.Value);
            MongoClientSettings settings = MongoClientSettings.FromUrl(url);

            MongoClient client = new MongoClient(settings);
            MongoServer server = client.GetServer();

            Database = server.GetDatabase(App.Configurations.DatabaseName.Value);

            MemberRepository = new MongoRepository<Member>(Database);
        }

        [TestMethod]
        public void InserUser()
        {
            var member = new Member
            {
                FirstName = "Nowshad",
                LastName = "Rahaman",
                Password = "123456",
                Email = "nowshad.rahaman@gmail.com",
                EmailVerified = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            MemberRepository.Save(member);
        }
    }
}
