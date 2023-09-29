namespace MonkeyShelter.Migrations
{
    using MonkeyShelter.Entities;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MonkeyShelterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MonkeyShelterContext context)
        {

            if (!context.Monkeys.Any())
            {

                string json = File.ReadAllText("monkeycollection.json");
                List<Monkey> data = JsonConvert.DeserializeObject<List<Monkey>>(json);

                context.Monkeys.AddRange(data);

                context.SaveChanges();
            }
        }
    }
}
