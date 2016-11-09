using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var store = new Raven.Client.Document.DocumentStore
            {
                Url = "http://localhost:8081/",
                DefaultDatabase = "tobi-test",
                ApiKey = "tobi/SukWxO6ne9By0hCawMFAc"
            };

            store.Initialize();
            
            using (var session = store.OpenSession())
            {
                session.Store(new Bug() { Name = "Tobi" }); // here is the exception
                session.SaveChanges();
            }
        }
    }

    public class Bug
    {
        public string Name { get; set; }
    }
}
