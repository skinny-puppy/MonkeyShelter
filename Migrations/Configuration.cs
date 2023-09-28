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
            
            if (!context.Monkeys.Any())
            {
                
                string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "monkeycollection.json");
                string json = File.ReadAllText(jsonFilePath);
                List<Monkey> data = JsonConvert.DeserializeObject<List<Monkey>>(json);

                
                context.Monkeys.AddRange(data);

                context.SaveChanges();
            }
        }
    }
}
