using System;
using System.Diagnostics;
using Memory;

namespace manual_alloc;

class Person
{
	public string Name;
	public int Age;

	~Person()
	{
		Console.WriteLine($"Person {this.Name} destroyed.");
	}
}

class Program
{
	unsafe public static void Main(string[] args)
	{
		Console.WriteLine($"start memory: {Process.GetCurrentProcess().PrivateMemorySize64 / 1024 / 1024}MB");
		for (int i = 0; i < 200000; i++)
		{
			mem.alloc(out Person person1);
			person1.Name = "Thomas";
			person1.Age = 42;
			// Console.WriteLine($"{person1.Name} is {person1.Age} years old.");

			var storage = stackalloc nint[sizeof(Person)];
			mem.bind(out Person person2, (nint)storage);
			person2.Name = "Max";
			person2.Age = 24;
			Console.WriteLine($"{person2.Name} is {person2.Age} years old.");

			mem.free(ref person1);

			// arrays
			{
				mem.alloc(out arr<int> array, 4);

				for (int j = 0; j < array.Length; j++)
					array[j] = j;

				for (int j = 0; j < array.Length; j++)
					// Console.WriteLine(array[j]);

					mem.free(ref array);
			}

			nint leak = mem.alloc(1024 * 1024);
			mem.free(leak);
		}
		Console.WriteLine($"end memory: {Process.GetCurrentProcess().PrivateMemorySize64 / 1024 / 1024}MB");
	}
}