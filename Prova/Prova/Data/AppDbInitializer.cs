using Prova.Models;

namespace Prova.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppCont>();
                context.Database.EnsureCreated();

                //Criar tarefas
                if (!context.Clientes.Any())
                {
                    context.Clientes.AddRange(new List<Cliente>()
                    {
                        new Cliente()
                        {
                            Name = "Marcos Evangelista Junior",
                            Endereco = "sampa",

                        },
                    });
                    context.SaveChanges();
                }

            }
        }
    }
}
