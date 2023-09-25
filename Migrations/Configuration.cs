namespace MonkeyShelter.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using MonkeyShelter.Entities;
    using Newtonsoft.Json;

    internal sealed class Configuration : DbMigrationsConfiguration<MonkeyShelterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MonkeyShelterContext context)
        {
            // Check if there is existing data in the table
            if (!context.Monkeys.Any())
            {
                // Read data from the JSON file
                string json = File.ReadAllText("monkeycollection.json");
                List<Monkey> data = JsonConvert.DeserializeObject<List<Monkey>>(json);

                // Add data to the database
                context.Monkeys.AddRange(data);

                context.SaveChanges();
            }
        }
    }
}
