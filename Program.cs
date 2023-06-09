﻿using LearningEntityFrameworkCore.Models;
using LearningEntityFrameworkCore.Data;
using LearningEntityFrameworkCore.Views;
using Microsoft.EntityFrameworkCore;
using LearningEntityFrameworkCore.Views.Menu;
using LearningEntityFrameworkCore.Views.User;
using LearningEntityFrameworkCore.Views.Dev;

using ContosoPizzaContext context = new ContosoPizzaContext();

try
{
    Outros.BlueMessage("  >  Menu  <  ");
    Console.WriteLine();
    Console.WriteLine("Verificando se a Database existe...");
    context.Database.OpenConnectionAsync().Wait();
    Outros.GreenMessage("Database existente!");
    Outros.YellowMessage("Deseja acessá-la?");
    Outros.YellowMessage("1 - Sim");
    Console.WriteLine();
    Outros.RedMessage("Caso queira deletar o banco de dados");
    Outros.RedMessage("Escreva 'deletar'");

    var escolha = Console.ReadLine().Replace(" ", "").ToLower();
    if (escolha == "1")
    {
        Console.WriteLine("Carregando aplicação...");
        Thread.Sleep(3000);
        MenuViews.Menu(context);
    }
    else if (escolha == "deletar")
    {
        Console.WriteLine("Deletando database...");
        context.Database.EnsureDeleted();
        Outros.GreenMessage("Database Deletada!");
        Outros.BlueMessage("Até a proxima!");
    }
    else
    {
        Console.WriteLine();
        Outros.BlueMessage("Até a próxima!");
    }
}
catch
{
    Outros.RedMessage("Database não encontrada, podemos criá-la?");
    Outros.YellowMessage("1 - Sim");
    Outros.YellowMessage("Caso Não, pressione qualquer botão");

    var escolha = Console.ReadKey();
    if (escolha.Key == ConsoleKey.D1)
    {
        Console.WriteLine();
        Console.WriteLine("Criando Database...");
        context.Database.EnsureCreated();
        Outros.GreenMessage("Database Criada.");
        Console.WriteLine("Carregando aplicação...");
        Thread.Sleep(3000);
        MenuViews.Menu(context);
    }
    else
    {
        Console.WriteLine();
        Outros.BlueMessage("Até a próxima!");
    }
}
finally { context.Database.CloseConnectionAsync().Wait(); }