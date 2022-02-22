using System;
using System.Linq;

namespace Weapon_AK_47
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int ReloadingAndRemovingAmmo = 30;
            const int FullPackage = 90;

            // Make a program that tracks the ammo in the weapon AK-47

            int magazineAmmo = 30;
            int restAmmo = 90;

            // TODO: Do the following commands:
            // Add the rest of the commands.

            //  Shooting x30
            //  Ammo: 30 / 60
            //  Shooting x30
            //  Ammo: 30 / 30
            //  Reload
            //  Magazine state: Full
            //  Shooting x3
            //  Ammo: 27 / 30
            //  Reload
            //  Ammo: 57 / 0

            // commands:
            // Shoot - Remove 1 ammo from the magazine
            // Shooting x{n - Times} - Remove {n} bullets from the magazine
            // Reload - Reloads the magazine back to 30 and removes the taken ammo from the storage
            // Playtime - Remove all ammo from the magazine
            // Buy new AK-47 - Refill all ammo

            // Copy:
            // Shooting x30

            string command = Console.ReadLine();
            while (true)
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];

                if (action == "Shoot")
                {
                    magazineAmmo -= 1;
                }
                else if (action == "Shooting")
                {
                    string times = cmdArgs[1];
                    string shootTimes = string.Empty;

                    for (int i = 0; i < times.Length; i++)
                    {
                        if (char.IsDigit(times[i]))
                        {
                            shootTimes += times[i];
                        }
                    }

                    int shootTimesAsInt = int.Parse(shootTimes);
                    // Here we have (Shooting x) >>12<< times (the number 12).

                    magazineAmmo -= shootTimesAsInt;
                }
                else if (action == "Reload")
                {
                    if (magazineAmmo == 30)
                    {
                        Console.WriteLine($"Magazine state: Full");

                        command = Console.ReadLine();
                        continue;
                    }

                    if (magazineAmmo < 30 && restAmmo == 0)
                    {
                        Console.WriteLine($"Not enough bullets to reload");

                        command = Console.ReadLine();
                        continue;
                    }
                    else if (restAmmo - ReloadingAndRemovingAmmo < 0)
                    {
                        magazineAmmo = ReloadingAndRemovingAmmo;
                        restAmmo = 0;
                    }
                    else
                    {
                        restAmmo -= ReloadingAndRemovingAmmo - magazineAmmo;
                        magazineAmmo = ReloadingAndRemovingAmmo;
                    }
                }
                else if (action == "Playtime")
                {
                    magazineAmmo = 0;
                }
                else if (action == "Buy" && cmdArgs[1] == "new" && cmdArgs[2] == "AK-47")
                {
                    magazineAmmo = ReloadingAndRemovingAmmo;
                    restAmmo = FullPackage;

                    Console.WriteLine("You have bought AK-47.");
                    command = Console.ReadLine();
                    continue;
                }
                else
                {
                    Console.WriteLine($"Invalid command!");
                    command = Console.ReadLine();
                    continue;
                }

                if (magazineAmmo == 0)
                {
                    // Here comes the auto reload:

                    // restAmo = 26

                    if (restAmmo - ReloadingAndRemovingAmmo <= 0)
                    {
                        magazineAmmo += restAmmo;
                        restAmmo = 0;
                    }
                    else
                    {
                        magazineAmmo += ReloadingAndRemovingAmmo;
                        restAmmo -= ReloadingAndRemovingAmmo;
                    }
                }

                if (restAmmo == 0 && magazineAmmo == 0)
                {
                    break;
                }

                Console.WriteLine($"Ammo: {magazineAmmo} / {restAmmo}");
                command = Console.ReadLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Magazine State: Empty");
            Console.WriteLine($"Nice shooting!\nKills: 20\n:D");
        }
    }
}
