/*
 * 03-10-2021
 * Демонстрация работы конфликта приодновременном изменении одной сущности разными потоками.
 * 
 * Оптимистическая блокировка.
 * Добавлено свойство отслеживания в EFTemplates.RowVersionExample.Models.Results (RowVersion)
 * 
 * Во время операции Update будет произведен поиск в т.ч. по ранее полученному RowVersion,
 * если такой записи найдено не будет, тогда будет вброшено исключение: DbUpdateConcurrencyException
 * 
 * Как воспроизвести:
 *  1. Запустить приложение, и создать первую операцию (например с именем Sam, и номером счета 123, любой суммой).
 *  2. Запустить приложение, и начать создавать вторую операцию с идентичным именем и номером счета
 *      , после ввода реквизитов операцию не завершать.
 *  3. Открыть второй экземпляр приложения, ввести и завершить новую операцию (с именем и номером из шага 2).
 *  4. Попытаться завершить операцию из п.2 (должно появиться сообщение об ошибке).
 */

using EFTemplates.RowVersionExample.Context;
using EFTemplates.RowVersionExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFTemplates.RowVersionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("New operation. Name: ");
            string name = Console.ReadLine();

            Console.Write("New operation. Account: ");
            string account = Console.ReadLine();

            Console.Write("New operation. Amount: ");
            decimal amount = Decimal.Parse(Console.ReadLine());

            NewOperation(name, account, amount);
        }

        static void NewOperation(string Name, string Account, decimal Amount)
        {
            var ctx = new RowVersionExampleDbContext();

            var result = ctx.Results
                .Where(i => i.Name == Name && i.Account == Account)
                .FirstOrDefault();

            if (result == null)
            {
                result = new Results() { Name = Name, Account = Account, TotalAmount = Amount };
                ctx.Results.Add(result);
            }

            PrintState(result);

            result.TotalAmount += Amount;

            var newOperation = new Operation() { Name = Name, Account = Account, Amount = Amount };
            ctx.Operations.Add(newOperation);

            Console.Write("Press enter to complete operation");
            string account = Console.ReadLine();

            try
            {
                ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var erroMsg = "The record you attempted to edit was modified by another user after you got the original value.";
                Console.WriteLine(erroMsg);
            }

            Console.Write("Operation complete.");
            Console.ReadLine();
        }

        static void PrintState(Results result)
        {
            Console.WriteLine($"Name: {result.Name}, Account: {result.Account}, Total amount: {result.TotalAmount}");

            var dataVersion = result.RowVersion != null ? BitConverter.ToString(result.RowVersion) : "n/a";
            Console.WriteLine($"Data version: {dataVersion}");
        }
    }
}
