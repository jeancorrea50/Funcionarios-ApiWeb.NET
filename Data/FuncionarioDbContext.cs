using Funcionario_ApiWeb.NET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Funcionario_ApiWeb.NET.Data
{
    public class FuncionarioDbContext : DbContext
    {
    
            public DbSet<FuncionarioModel> Funcionarios { get; set; }


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                // string C com o banco de dados sql server
                optionsBuilder.UseSqlServer("Password=Bf18102907;Persist Security Info=True;User ID=jeancpcorrea;Initial Catalog=FuncionarioWebApi;Data Source=DESKTOP-43O4B71\\SQLEXPRESS");

            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Caso não informe o nome da tabela como "Funcionario", o entity irá criar automaticamente no pural no sql server exemp. "Funciarios".
                modelBuilder.Entity<FuncionarioModel>().ToTable("Funcionario");
                modelBuilder.Entity<FuncionarioModel>().Property(s => s.Salario).HasPrecision(10, 2);


                modelBuilder.Entity<FuncionarioModel>().HasData(
                   new FuncionarioModel { IdFuncionario = 1, NomeCompleto = "Ronaldo Pereira Cruz", CPF = "063.485.221-32", Idade = 24, Telefone = "(65)98132-4241", Email = "ronaldopeira658@gmail.com", Cargo = "Analista de Logistisca JR", Salario = 3100.00M },
                   new FuncionarioModel { IdFuncionario = 2, NomeCompleto = "Carolline Hererro Souza", CPF = "026.752.421-25", Idade = 26, Telefone = "(65)98421-6532", Email = "carollineSouza123@gmail.com", Cargo = "Analista Financeiro Pleno ", Salario = 4200.00M },
                   new FuncionarioModel { IdFuncionario = 3, NomeCompleto = "Leandro Cardoso Monteiro", CPF = "542.481.263-78", Idade = 33, Telefone = "(65)98365-6421", Email = "Leandrocardosom5874@gmail.com", Cargo = "Analista de RH Senior", Salario = 5600.00M }

                  );
            }
        }
    }
