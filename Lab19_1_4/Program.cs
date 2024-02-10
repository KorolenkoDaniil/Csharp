using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19_1_4
{
    internal class Program
    {
        Hashtable hashtable = new Hashtable();

        static void Main(string[] args)
        {
            List<Disk> disks = new List<Disk>();
            for (; ; )
            {
                int num = 0, number = 0; ;
                do
                {
                    Console.WriteLine("выберите пункт меню");
                    Console.WriteLine("1 - добавить диск");
                    Console.WriteLine("2 - удалить диск");
                    Console.WriteLine("3 - добавить песню");
                    Console.WriteLine("4 - удалить песню");
                    Console.WriteLine("5 - показать все песни");
 
                    num = int.Parse(Console.ReadLine());
                } while (num < 0);


                switch (num)
                {
                    case 1:
                        {
                            Console.WriteLine("введите название для нового диска");
                            disks.Add(new Disk(Console.ReadLine()));
                            break;
                        }
                    case 2:
                        {
                            
                            Disk diskForDelete = SelectDisk(disks,out number);
                            disks = DeleteDisk(disks, diskForDelete);

                            break;
                        }
                    case 3:
                        {
                            AddSong1(disks);
                            break;
                        }
                    case 4:
                        {
                            DeleteSong(disks);
                            break;
                        }
                    case 5:
                        {
                            Print(disks);
                            break;
                        }
                }
            }
        }

        public static void Print(List<Disk> disks)
        {
            int n = 0, number = 0;
            do
            {
                Console.WriteLine("выберите пункт меню");
                Console.WriteLine("1 - выбрать диск");
                Console.WriteLine("2 - просмотреть весь каталог");

                n = int.Parse(Console.ReadLine());
            } while (n < 0 || n > 2);
            if (disks.Count == 0) Console.WriteLine("у вас нету дисков");
            else {
                if (n == 1)
                {
                    Disk c = SelectDisk(disks, out number);
                    PrintDisk(c);
                }
                else
                {
                    foreach (Disk d in disks)
                    {
                        Console.WriteLine($"Песни диска {d._name}");
                        Console.WriteLine("-------------------------");
                        PrintDisk(d);
                        Console.WriteLine("-------------------------");
                    }
                }
            }
        }

        public static void PrintDisk(Disk disk)
        {
            disk.PrtntSongs();
        }


        public static List <Disk> DeleteSong(List<Disk> disks)
        {
            int number = 0;
            Disk a = SelectDisk(disks, out number);
            if (SelectDisk(disks, out number) != null)
            {
                Console.WriteLine("введите название песни для удаления");
                string SongName = Console.ReadLine();
                a.DeleteSong(SongName);
                disks[number] = a;
                Console.WriteLine("песня удалилась");
            }
            return disks;
        }




        public static List<Disk> AddSong1(List<Disk> disks)
        {
            int number = 0;
            Disk a = SelectDisk(disks, out number);
            if (a != null)
            {
                Console.WriteLine("введите авзание песни ");
                string SongName = Console.ReadLine();
                Console.WriteLine("введите авзание исполнителя ");
                string Singer = Console.ReadLine();
                disks[number] = AddSong2(a, SongName, Singer);
            }
            return disks;
        }


        public static Disk SelectDisk(List<Disk> disks, out int number)
        {
            if (disks.Count == 0)
            {
                Console.WriteLine("добавьте диски для продолжения");
                number = -1;
                return null;
            }
            else
            {
                for (int i = 0; i < disks.Count; i++)
                {
                    Console.WriteLine(i + " - " + disks[i]);
                }

                int diskName;
                do
                {
                    Console.WriteLine("Введите номер выбранного диска:");
                    diskName = int.Parse(Console.ReadLine());

                } while (diskName < 0 );
                number = diskName;
                return disks[diskName];
            }
        }



        public static Disk AddSong2(Disk disk, string songName, string singer)
        {
            disk.AddSong(songName, singer);
            return disk;
        }

        public static List<Disk> DeleteDisk(List<Disk> disks, Disk diskforDelete)
        {
            disks.Remove(diskforDelete);
            return disks;
        }


                
    }
}
