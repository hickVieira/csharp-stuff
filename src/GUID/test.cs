using System;
using System.Collections.Generic;

namespace GUID;

/*
best options: 
    fnv32
        +super fast 
        +compact 
        -minor collisions (~100 at 1M) (~1 at 100k)
    sha132
        +fast
        +compact
        -minor collisions (~100 at 1M) (~1 at 100k)
    sha164
        +fast
        -not compact (long ints)
        +no 

overall I think that I will use fnv32 hashing for my game's guid system - I obviously will never ever reach 100k+ indexed prefabs/assets
*/
// note: some of the input/output are limited to 32bit/small-sequences

public static class test
{
    public static void run()
    {
        const int maxInputLength = 8;
        const int maxHashByteLength = 4;
        Console.WriteLine($"maxInputLength = {maxInputLength}");
        Console.WriteLine($"maxHashByteLength = {maxHashByteLength}");
        Console.Write("random inputs count = ");
        int randomInputsCount = int.Parse(Console.ReadLine());

        // guid_Int16
        {
            HashSet<Int16> hashes = new HashSet<Int16>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                var timer = System.Diagnostics.Stopwatch.StartNew();
                Int16 Int16 = Game.Hash.Generate.Int16();
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                if (hashes.Contains(Int16))
                    collisionCount++;
                else
                    hashes.Add(Int16);
            }
            Console.WriteLine($"Int16 - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // guid_Int32
        {
            HashSet<Int32> hashes = new HashSet<Int32>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                var timer = System.Diagnostics.Stopwatch.StartNew();
                Int32 Int32 = Game.Hash.Generate.Int32();
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                if (hashes.Contains(Int32))
                    collisionCount++;
                else
                    hashes.Add(Int32);
            }
            Console.WriteLine($"Int32 - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // guid_Int64
        {
            HashSet<Int64> hashes = new HashSet<Int64>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                var timer = System.Diagnostics.Stopwatch.StartNew();
                Int64 Int64 = Game.Hash.Generate.Int64();
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                if (hashes.Contains(Int64))
                    collisionCount++;
                else
                    hashes.Add(Int64);
            }
            Console.WriteLine($"Int64 - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        return;

        // guid_8
        {
            HashSet<string> hashes = new HashSet<string>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                var timer = System.Diagnostics.Stopwatch.StartNew();
                string guid_8 = System.Guid.NewGuid().ToString().Substring(0, 8);
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                if (hashes.Contains(guid_8))
                    collisionCount++;
                else
                    hashes.Add(guid_8);
            }
            Console.WriteLine($"guid_8 - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // guid_random_hex_string8
        {
            HashSet<string> hashes = new HashSet<string>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                var timer = System.Diagnostics.Stopwatch.StartNew();
                string guid_random_hex_string8 = Game.Hash.Generate.String(Game.Hash.Type.HexadecimalLower, 8, new Random(i));
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                if (hashes.Contains(guid_random_hex_string8))
                    collisionCount++;
                else
                    hashes.Add(guid_random_hex_string8);
            }
            Console.WriteLine($"guid_random_hex_string8 - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // guid_random_hex_long
        {
            HashSet<long> hashes = new HashSet<long>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                var timer = System.Diagnostics.Stopwatch.StartNew();
                long guid_random_hex_long = Convert.ToInt64(Game.Hash.Generate.String(Game.Hash.Type.HexadecimalLower, 16, new Random(i)), 16);
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                if (hashes.Contains(guid_random_hex_long))
                    collisionCount++;
                else
                    hashes.Add(guid_random_hex_long);
            }
            Console.WriteLine($"guid_random_hex_long - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // guid_random_hex_int
        {
            HashSet<int> hashes = new HashSet<int>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                var timer = System.Diagnostics.Stopwatch.StartNew();
                int guid_random_hex_int = Convert.ToInt32(Game.Hash.Generate.String(Game.Hash.Type.HexadecimalLower, 8, new Random(i)), 16);
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                if (hashes.Contains(guid_random_hex_int))
                    collisionCount++;
                else
                    hashes.Add(guid_random_hex_int);
            }
            Console.WriteLine($"guid_random_hex_int - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // guid_random_hex_short
        {
            HashSet<short> hashes = new HashSet<short>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                var timer = System.Diagnostics.Stopwatch.StartNew();
                short guid_random_hex_short = Convert.ToInt16(Game.Hash.Generate.String(Game.Hash.Type.HexadecimalLower, 4, new Random(i)), 16);
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                if (hashes.Contains(guid_random_hex_short))
                    collisionCount++;
                else
                    hashes.Add(guid_random_hex_short);
            }
            Console.WriteLine($"guid_random_hex_short - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // guid_random_hex_ulong
        {
            HashSet<ulong> hashes = new HashSet<ulong>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                var timer = System.Diagnostics.Stopwatch.StartNew();
                ulong guid_random_hex_ulong = Convert.ToUInt64(Game.Hash.Generate.String(Game.Hash.Type.HexadecimalLower, 16, new Random(i)), 16);
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                if (hashes.Contains(guid_random_hex_ulong))
                    collisionCount++;
                else
                    hashes.Add(guid_random_hex_ulong);
            }
            Console.WriteLine($"guid_random_hex_ulong - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // guid_random_hex_uint
        {
            HashSet<uint> hashes = new HashSet<uint>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                var timer = System.Diagnostics.Stopwatch.StartNew();
                uint guid_random_hex_uint = Convert.ToUInt32(Game.Hash.Generate.String(Game.Hash.Type.HexadecimalLower, 8, new Random(i)), 16);
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                if (hashes.Contains(guid_random_hex_uint))
                    collisionCount++;
                else
                    hashes.Add(guid_random_hex_uint);
            }
            Console.WriteLine($"guid_random_hex_uint - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // guid_random_hex_ushort
        {
            HashSet<ushort> hashes = new HashSet<ushort>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                var timer = System.Diagnostics.Stopwatch.StartNew();
                ushort guid_random_hex_ushort = Convert.ToUInt16(Game.Hash.Generate.String(Game.Hash.Type.HexadecimalLower, 4, new Random(i)), 16);
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                if (hashes.Contains(guid_random_hex_ushort))
                    collisionCount++;
                else
                    hashes.Add(guid_random_hex_ushort);
            }
            Console.WriteLine($"guid_random_hex_ushort - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // sha512
        {
            HashSet<string> hashes = new HashSet<string>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                string inputString = Game.Hash.Generate.String(Game.Hash.Type.AlphanumericAll, maxInputLength, new Random(i));
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(inputString);

                var timer = System.Diagnostics.Stopwatch.StartNew();
                byte[] hashBytes = GUID.hashers.SHA512(inputBytes);
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                Array.Resize(ref hashBytes, maxHashByteLength); string sha512 = Convert.ToHexString(hashBytes);

                if (hashes.Contains(sha512))
                    collisionCount++;
                else
                    hashes.Add(sha512);
            }
            Console.WriteLine($"sha512 - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // sha256
        {
            HashSet<string> hashes = new HashSet<string>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                string inputString = Game.Hash.Generate.String(Game.Hash.Type.AlphanumericAll, maxInputLength, new Random(i));
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(inputString);

                var timer = System.Diagnostics.Stopwatch.StartNew();
                byte[] hashBytes = GUID.hashers.SHA256(inputBytes);
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                Array.Resize(ref hashBytes, maxHashByteLength); string sha256 = Convert.ToHexString(hashBytes);

                if (hashes.Contains(sha256))
                    collisionCount++;
                else
                    hashes.Add(sha256);
            }
            Console.WriteLine($"sha256 - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // sha1
        {
            HashSet<string> hashes = new HashSet<string>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                string inputString = Game.Hash.Generate.String(Game.Hash.Type.AlphanumericAll, maxInputLength, new Random(i));
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(inputString);

                var timer = System.Diagnostics.Stopwatch.StartNew();
                byte[] hashBytes = GUID.hashers.SHA1(inputBytes);
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                Array.Resize(ref hashBytes, maxHashByteLength); string sha1 = Convert.ToHexString(hashBytes);

                if (hashes.Contains(sha1))
                    collisionCount++;
                else
                    hashes.Add(sha1);
            }
            Console.WriteLine($"sha1 - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // md5
        {
            HashSet<string> hashes = new HashSet<string>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                string inputString = Game.Hash.Generate.String(Game.Hash.Type.AlphanumericAll, maxInputLength, new Random(i));
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(inputString);

                var timer = System.Diagnostics.Stopwatch.StartNew();
                byte[] hashBytes = GUID.hashers.MD5(inputBytes);
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                Array.Resize(ref hashBytes, maxHashByteLength); string md5 = Convert.ToHexString(hashBytes);

                if (hashes.Contains(md5))
                    collisionCount++;
                else
                    hashes.Add(md5);
            }
            Console.WriteLine($"md5 - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // fnv32
        {
            HashSet<uint> hashes = new HashSet<uint>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                string inputString = Game.Hash.Generate.String(Game.Hash.Type.AlphanumericAll, maxInputLength, new Random(i));
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(inputString);

                var timer = System.Diagnostics.Stopwatch.StartNew();
                uint fnv32 = GUID.hashers.FNV32(inputBytes);
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                if (hashes.Contains(fnv32))
                    collisionCount++;
                else
                    hashes.Add(fnv32);
            }
            Console.WriteLine($"fnv32 - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // crc32
        {
            HashSet<uint> hashes = new HashSet<uint>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                string inputString = Game.Hash.Generate.String(Game.Hash.Type.AlphanumericAll, maxInputLength, new Random(i));
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(inputString);

                var timer = System.Diagnostics.Stopwatch.StartNew();
                uint crc32 = GUID.hashers.CRC32(inputBytes);
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                if (hashes.Contains(crc32))
                    collisionCount++;
                else
                    hashes.Add(crc32);
            }
            Console.WriteLine($"crc32 - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // fletcher64
        {
            HashSet<string> hashes = new HashSet<string>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                string inputString = Game.Hash.Generate.String(Game.Hash.Type.AlphanumericAll, maxInputLength, new Random(i));
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(inputString);

                var timer = System.Diagnostics.Stopwatch.StartNew();
                string fletcher64 = Convert.ToHexString(GUID.hashers.Fletcher(inputBytes, 64));
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                if (hashes.Contains(fletcher64))
                    collisionCount++;
                else
                    hashes.Add(fletcher64);
            }
            Console.WriteLine($"fletcher64 - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // fletcher32
        {
            HashSet<string> hashes = new HashSet<string>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                string inputString = Game.Hash.Generate.String(Game.Hash.Type.AlphanumericAll, maxInputLength, new Random(i));
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(inputString);

                var timer = System.Diagnostics.Stopwatch.StartNew();
                string fletcher32 = Convert.ToHexString(GUID.hashers.Fletcher(inputBytes, 32));
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                if (hashes.Contains(fletcher32))
                    collisionCount++;
                else
                    hashes.Add(fletcher32);
            }
            Console.WriteLine($"fletcher32 - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // fletcher16
        {
            HashSet<string> hashes = new HashSet<string>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                string inputString = Game.Hash.Generate.String(Game.Hash.Type.AlphanumericAll, maxInputLength, new Random(i));
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(inputString);

                var timer = System.Diagnostics.Stopwatch.StartNew();
                string fletcher16 = Convert.ToHexString(GUID.hashers.Fletcher(inputBytes, 16));
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                if (hashes.Contains(fletcher16))
                    collisionCount++;
                else
                    hashes.Add(fletcher16);
            }
            Console.WriteLine($"fletcher16 - timeMS:{elapsedMS} collisions:{collisionCount}");
        }

        // adler32
        {
            HashSet<uint> hashes = new HashSet<uint>();
            long elapsedMS = 0;
            uint collisionCount = 0;
            for (int i = 0; i < randomInputsCount; i++)
            {
                string inputString = Game.Hash.Generate.String(Game.Hash.Type.AlphanumericAll, maxInputLength, new Random(i));
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(inputString);

                var timer = System.Diagnostics.Stopwatch.StartNew();
                uint adler32 = GUID.hashers.Adler32(inputBytes);
                timer.Stop();

                elapsedMS += timer.ElapsedMilliseconds;

                if (hashes.Contains(adler32))
                    collisionCount++;
                else
                    hashes.Add(adler32);
            }
            Console.WriteLine($"adler32 - timeMS:{elapsedMS} collisions:{collisionCount}");
        }
    }
}