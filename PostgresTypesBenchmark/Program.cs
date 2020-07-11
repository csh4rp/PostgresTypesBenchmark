using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PostgresTypesBenchmark
{
    class Program
    {
        private const int RecordsCount = 1;
        private const int Iterations = 10_000;
        private static Context context;
        
        static void Main(string[] args)
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseNpgsql(
                "User ID=postgres;Password=Admin123;Host=localhost;Port=5432;Database=guid_test;");

            context = new Context(builder.Options);
            
            // warmup
            Console.WriteLine("Running warmup...");
            Benchmark(1);

            while (true)
            {
                Console.WriteLine("Press \"i\" to initialize, \"b\" - benchmark, \"e\" - exit");
                var value = Console.ReadKey();

                if (value.KeyChar == 'i')
                {
                    Console.WriteLine("\nStarting init...\n");
                    Init();
                }
                else if (value.KeyChar == 'b')
                {
                    Console.WriteLine("\nStarting benchmark...\n");
                    Benchmark(Iterations);
                }
                else
                {
                    Console.WriteLine("\nFinished");
                    return;
                }
            }
            

        }

        static void Benchmark(int iterations)
        {
            // Middle of the table ids
            var id1 = Guid.Parse("7fcee25e-f9a0-4eb8-948d-511028c852bd");
            var id2 = Guid.Parse("838e7370-c346-11ea-89c5-0242ac120002");
            
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                var item = context.TestInts.AsNoTracking().FirstOrDefault(x => x.Id == 250000);
            }
            
            sw.Stop();
            Console.WriteLine($"Int time: {sw.ElapsedMilliseconds}");

            sw.Restart();
            
            for (int i = 0; i < iterations; i++)
            {
                var item = context.TestLongs.AsNoTracking().FirstOrDefault(x => x.Id == 250000);
            }

            sw.Stop();
            Console.WriteLine($"Long time: {sw.ElapsedMilliseconds}");

            sw.Restart();
            
            for (int i = 0; i < iterations; i++)
            {
                var item = context.TestGuids.AsNoTracking().FirstOrDefault(x => x.Id == id1);
            }

            sw.Stop();
            Console.WriteLine($"Guid time: {sw.ElapsedMilliseconds}");

            sw.Restart();
            
            for (int i = 0; i < iterations; i++)
            {
                var item = context.TestGuidDefaults.AsNoTracking().FirstOrDefault(x => x.Id == id2);
            }

            sw.Stop();
            Console.WriteLine($"Guid Default time: {sw.ElapsedMilliseconds}");
        }

        static void Init()
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < RecordsCount; i++)
            {
                context.TestInts.Add(new TestInt
                {
                    Name = $"Name_{i}",
                    Value = i
                });
            }

            context.SaveChanges();
            
            sw.Stop();
            Console.WriteLine($"Int time: {sw.ElapsedMilliseconds}");

            sw.Restart();
            
            for (int i = 0; i < RecordsCount; i++)
            {
                                
                context.TestLongs.Add(new TestLong
                {
                    Name = $"Name_{i}",
                    Value = i
                });
            }
            
            context.SaveChanges();
            
            sw.Stop();
            Console.WriteLine($"Long time: {sw.ElapsedMilliseconds}");

            sw.Restart();
            
            for (int i = 0; i < RecordsCount; i++)
            {
                context.TestGuids.Add(new TestGuid
                {
                    Id = Guid.NewGuid(),
                    Name = $"Name_{i}",
                    Value = i
                });
            }
            
            context.SaveChanges();
            
            sw.Stop();
            Console.WriteLine($"Guid time: {sw.ElapsedMilliseconds}");

            sw.Restart();
            
            for (int i = 0; i < RecordsCount; i++)
            {
                context.TestGuidDefaults.Add(new TestGuidDefault
                {
                    Name = $"Name_{i}",
                    Value = i
                });
            }
            
            context.SaveChanges();
            
            sw.Stop();
            Console.WriteLine($"Guid Default time: {sw.ElapsedMilliseconds}");
        }
    }




}